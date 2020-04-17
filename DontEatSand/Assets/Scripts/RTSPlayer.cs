using System.Collections.Generic;
using System.Linq;
using DontEatSand.Base;
using DontEatSand.Entities;
using DontEatSand.Entities.Buildings;
using DontEatSand.Entities.Units;
using DontEatSand.Extensions;
using Photon.Pun;
using RTSCam;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DontEatSand
{
    /// <summary>
    /// Types of possible screen selections
    /// </summary>
    public enum SelectionType
    {
        NONE,
        UNITS,
        OTHER
    }

    /// <summary>
    /// RTS RTSPlayer class
    /// </summary>
    [DisallowMultipleComponent]
    public class RTSPlayer : Singleton<RTSPlayer>
    {
        #region Constants
        /// <summary>
        /// The maximum time for a mouse down-up sequence for actions to be registered
        /// </summary>
        private const float CLICK_TIME = 0.5f;
        #endregion

        #region Fields
        [SerializeField, Tooltip("The amount of sand the rtsPlayer starts with")]
        private int startingSand = 500;
        [SerializeField, Tooltip("The amount of candy available from the rtsPlayer's main base")]
        private int baseCandy = 30;
        [SerializeField]
        private RectTransform selection;
        private new RTSCamera camera;
        private readonly LinkedList<Unit> units = new LinkedList<Unit>();
        private Vector2 startPoint, endPoint;
        private HashSet<Unit> inBox = new HashSet<Unit>();
        private float clickTime;
        private bool dragging;
        #endregion

        #region Properties
        /// <summary>
        /// Total sand the rtsPlayer has available
        /// </summary>
        public int Sand { get; private set; }

        /// <summary>
        /// Max candy at the rtsPlayer's disposition
        /// </summary>
        public int MaxCandy { get; private set; }

        /// <summary>
        /// Candy used by the rtsPlayer's unit
        /// </summary>
        public int UsedCandy { get; private set; }

        /// <summary>
        /// Available candy for extra unit creation
        /// </summary>
        public int AvailableCandy => this.MaxCandy - this.UsedCandy;

        /// <summary>
        /// The castle associated to this player
        /// </summary>
        public Castle Castle { get; internal set; }

        /// <summary>
        /// The current selection Rect
        /// </summary>
        private Rect Selection
        {
            get
            {
                float x, y, w, h;
                if (this.startPoint.x < this.endPoint.x)
                {
                    x = this.startPoint.x;
                    w = this.endPoint.x - x;
                }
                else
                {
                    x = this.endPoint.x;
                    w = this.startPoint.x - x;
                }

                if (this.startPoint.y < this.endPoint.y)
                {
                    y = this.startPoint.y;
                    h = this.endPoint.y - y;
                }
                else
                {
                    y = this.endPoint.y;
                    h = this.startPoint.y - y;
                }
                return new Rect(x, y, w, h);
            }
        }

        private ISelectable selected;
        /// <summary>
        /// The currently selected singular object
        /// </summary>
        public ISelectable Selected
        {
            get => this.selected;
            set
            {
                if (this.selected != value)
                {
                    //Clear out selection flags
                    if (this.selected != null)
                    {
                        this.selected.IsSelected = false;
                    }
                    if (value != null)
                    {
                        value.IsSelected = true;
                    }
                    //Swap values
                    this.selected = value;
                }
            }
        }

        private ISelectable hovered;
        /// <summary>
        /// Currently hovered object
        /// </summary>
        public ISelectable Hovered
        {
            get => this.hovered;
            set
            {
                if (this.hovered != value)
                {
                    if (this.hovered != null)
                    {
                        //Remove hovered status on previous
                        this.hovered.IsHovered = false;
                    }
                    if (value != null)
                    {
                        //Add hovered status on current
                        value.IsHovered = true;
                    }
                    this.hovered = value;
                }
            }
        }

        /// <summary>
        /// This currently selected grouped objects
        /// </summary>
        public SortedSet<Unit> SelectedUnits { get; private set; } = new SortedSet<Unit>();

        /// <summary>
        /// Average position of the currently selected units
        /// </summary>
        public Vector3 AveragePosition { get; private set; }

        private SelectionType selectionType;
        /// <summary>
        /// Type of screen selection for this player
        /// </summary>
        public SelectionType SelectionType
        {
            get => this.selectionType;
            set
            {
                this.selectionType = value;
                GameEvents.OnSelectionChanged.Invoke(value);
                this.Log(value);
            }
        }

        /// <summary>
        /// Make sure this Singleton is not immortal
        /// </summary>
        protected override bool Immortal { get; } = false;
        #endregion

        #region Methods
        /// <summary>
        /// Checks if the specified resources are available
        /// </summary>
        /// <param name="sand">Sand amount to request</param>
        /// <param name="candy">Candy amount to request</param>
        /// <returns>True if the resources are available, false otherwise</returns>
        public bool CheckResourcesAvailable(int sand, int candy) => sand <= this.Sand && candy <= this.AvailableCandy;

        /// <summary>
        /// Change in candy total
        /// </summary>
        /// <param name="amount"></param>
        private void OnCandyMaxChanged(int amount) => this.MaxCandy += amount;

        /// <summary>
        /// Change in sand amount
        /// </summary>
        /// <param name="amount">Amount of sand added or removed</param>
        private void OnSandChanged(int amount) => this.Sand += amount;

        /// <summary>
        /// Change in used candy amount
        /// </summary>
        /// <param name="amount">Candy used or freed</param>
        private void OnCandyChanged(int amount) => this.UsedCandy += amount;

        /// <summary>
        /// Adds this unit to the current list of units
        /// </summary>
        /// <param name="unit">Unit being added</param>
        private void OnUnitCreated(Unit unit)
        {
            if (unit.IsControllable())
            {
                this.units.AddLast(unit);
            }
        }

        /// <summary>
        /// Removes this unit from the current list of units
        /// </summary>
        /// <param name="unit"></param>
        private void OnUnitDestroyed(Unit unit)
        {
            if (unit.IsControllable())
            {
                this.units.Remove(unit);
                switch (this.SelectionType)
                {
                    case SelectionType.UNITS:
                        int count = this.SelectedUnits.Count;
                        this.SelectedUnits.Remove(unit);
                        if (count != this.SelectedUnits.Count)
                        {
                            this.SelectionType = this.SelectedUnits.Count == 0 ? SelectionType.NONE : SelectionType.UNITS;
                        }
                        break;

                    case SelectionType.OTHER:
                        if (this.Selected as Unit == unit)
                        {
                            this.Selected = null;
                            this.SelectionType = SelectionType.NONE;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Selects units and other objects from the screen using the mouse
        /// </summary>
        /// <param name="currentlyHovered">The currently hovered selectable object</param>
        /// <param name="overUI">If the mouse is currently hovering the UI</param>
        private void SelectFromScreen(ISelectable currentlyHovered, bool overUI)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Make sure not hovering UI
                this.dragging = !overUI;
                if (this.dragging)
                {
                    //Begin drag
                    this.startPoint = this.endPoint = Input.mousePosition;
                    this.selection.gameObject.SetActive(true);
                    this.selection.anchoredPosition = this.selection.sizeDelta = Vector2.zero;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //Reset dragging flag
                if (!this.dragging) { this.dragging = false; }
                else
                {
                    //End drag
                    this.selection.gameObject.SetActive(false);
                    //Get all selectable units
                    HashSet<Unit> withinRect = new HashSet<Unit>(this.camera.GetWithinRect(this.Selection, this.units));

                    //If there are non, check for single click
                    if (withinRect.Count == 0 && currentlyHovered is Unit unit && unit.IsControllable())
                    {
                        withinRect.Add(unit);
                    }

                    //If multiple friendly units selected
                    if (withinRect.Count != 0)
                    {
                        //Make sure to mark new ones as selected
                        withinRect.ForEach(u => u.IsSelected = true);

                        //If pressing ctrl, add to list
                        if (Input.GetKey(KeyCode.LeftControl))
                        {
                            //Make sure to ignore already selected units
                            withinRect.ExceptWith(this.SelectedUnits);
                            if (withinRect.Count > 0)
                            {
                                withinRect.ForEach(u => this.SelectedUnits.Add(u));
                                this.SelectionType = SelectionType.UNITS;
                            }
                        }
                        else
                        {
                            //Otherwise switch out and clear previous
                            if (!withinRect.SetEquals(this.SelectedUnits))
                            {
                                this.SelectedUnits.Where(s => !withinRect.Contains(s)).ForEach(u => u.IsSelected = false);
                                this.SelectedUnits = new SortedSet<Unit>(withinRect);
                                this.SelectionType = SelectionType.UNITS;
                            }
                        }

                        //Clear out single selected if necessary
                        if (this.Selected != null)
                        {
                            this.Selected = null;
                        }

                        //Clear out hovered box
                        foreach (Unit u in this.inBox)
                        {
                            u.IsHovered = false;
                        }
                    }
                    //Deselection if no units are selected, or control isn't held
                    else if (this.SelectedUnits.Count == 0 || !Input.GetKey(KeyCode.LeftControl))
                    {
                        bool selectionChanged = false;

                        //Else, single selectable object
                        if (this.Selected != currentlyHovered)
                        {
                            this.Selected = currentlyHovered;
                            selectionChanged = true;
                        }

                        //Clear out group selected if necessary
                        if (this.SelectedUnits.Count > 0)
                        {
                            this.SelectedUnits.ForEach(u => u.IsSelected = false);
                            this.SelectedUnits.Clear();
                            selectionChanged = true;
                        }

                        //Update selection
                        if (selectionChanged)
                        {
                            this.SelectionType = currentlyHovered == null ? SelectionType.NONE : SelectionType.OTHER;
                        }
                    }
                }
            }
            else if (Input.GetMouseButton(0) && this.dragging)
            {
                //Update drag rect
                this.endPoint = Input.mousePosition;
                Rect rect = this.Selection;
                this.selection.anchoredPosition = rect.position;
                this.selection.sizeDelta = rect.size;

                //Update hovered as all those currently in box
                HashSet<Unit> newBox = new HashSet<Unit>(this.camera.GetWithinRect(this.Selection, this.units));
                this.inBox.ExceptWith(newBox);
                foreach (Unit u in this.inBox)
                {
                    u.IsHovered = false;
                }
                foreach (Unit u in newBox)
                {
                    u.IsHovered = true;
                }
                this.inBox = newBox;
            }

            //If no units are selected, make sure anything hovered is highlighted
            this.Hovered = this.selection.gameObject.activeSelf && this.inBox.Count > 0 ? null : currentlyHovered;
        }

        /// <summary>
        /// Processes any player actions
        /// </summary>
        /// <param name="currentlyHovered">The currently hovered selectable object</param>
        private void ProcessActions(ISelectable currentlyHovered)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Time.time - this.clickTime <= CLICK_TIME)
                {
                    Vector3? pos = this.camera.MouseWorldPosition;
                    if (pos != null)
                    {
                        Vector3 destination = pos.Value;
                        this.Log($"Command requested at ({destination.x:F2}, {destination.y:F2}, {destination.z:F2})");
                        GameEvents.OnActionRequested.Invoke(destination, currentlyHovered);
                        this.clickTime = 0f;
                    }
                    else { this.clickTime = Time.time; }
                }
                else { this.clickTime = Time.time; }
            }
        }

        /// <summary>
        /// Forces the selection of the passed selectable object
        /// </summary>
        /// <param name="newSelection"></param>
        public void ForceSelect(ISelectable newSelection)
        {
            //Clear selected units
            if (this.SelectedUnits.Count > 0)
            {
                Unit newUnit = newSelection as Unit;
                this.SelectedUnits.Where(u => u != newUnit).ForEach(u => u.IsSelected = false);
                this.SelectedUnits.Clear();
            }

            //Set selection
            this.Selected = newSelection;
            this.SelectionType = newSelection == null ? SelectionType.NONE : SelectionType.OTHER;
        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            //Setup
            this.Sand = this.startingSand;
            this.MaxCandy = this.baseCandy;
            //ReSharper disable once PossibleNullReferenceException
            this.camera = Camera.main.GetComponent<RTSCamera>();
            if (!PhotonNetwork.IsConnected)
            {
                this.Castle = FindObjectsOfType<Castle>().First(g => g.name == "Sandcastle A");
                //Testing with units on map
                foreach (Unit u in FindObjectsOfType<Unit>())
                {
                    this.units.AddLast(u);
                }
            }
            else
            {
                //Disable when connected
                this.enabled = false;
            }

            //Event registering
            GameEvents.OnCandyMaxChanged.AddListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.AddListener(OnSandChanged);
            GameEvents.OnCandyChanged.AddListener(OnCandyChanged);
            GameEvents.OnUnitCreated.AddListener(OnUnitCreated);
            GameEvents.OnUnitDestroyed.AddListener(OnUnitDestroyed);
        }

        private void Update()
        {
            //Get currently hovered object
            ISelectable currentlyHovered = this.camera.Selected;
            bool overUI = EventSystem.current.IsPointerOverGameObject();
            //Do selection
            SelectFromScreen(currentlyHovered, overUI);

            //Calculate average position
            this.AveragePosition = Vector3.zero;
            if (this.SelectedUnits.Count > 0)
            {
                foreach (Unit unit in this.SelectedUnits)
                {
                    this.AveragePosition += unit.transform.position;
                }

                this.AveragePosition /= this.SelectedUnits.Count;
            }

            if (!overUI)
            {
                //Do movement
                ProcessActions(currentlyHovered);
            }
        }

        private void OnDestroy()
        {
            //Remove event listeners
            GameEvents.OnCandyMaxChanged.RemoveListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.RemoveListener(OnSandChanged);
            GameEvents.OnCandyChanged.RemoveListener(OnCandyChanged);
            GameEvents.OnUnitCreated.RemoveListener(OnUnitCreated);
            GameEvents.OnUnitDestroyed.RemoveListener(OnUnitDestroyed);
        }
        #endregion
    }
}
