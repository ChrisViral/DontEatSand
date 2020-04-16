using System.Collections.Generic;
using System.Linq;
using DontEatSand.Entities.Units;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand.Entities;
using DontEatSand.Entities.Buildings;
using DontEatSand.Extensions;

namespace DontEatSand.UI.Game
{
    /// <summary>
    /// Display selected units' health and icons in the management menu (middle)
    /// </summary>
    public class DisplayUnitInfo : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private DisplayHealthAndIcon buttonPrefab;
        [SerializeField]
        private GameObject multiUnitParent;
        [SerializeField]
        private GameObject singleUnitParent;
        [SerializeField]
        private GameObject queueParent;
        [SerializeField]
        private Text title, description;
        [SerializeField]
        private DisplayHealthAndIcon icon;
        private readonly List<DisplayHealthAndIcon> displayed = new List<DisplayHealthAndIcon>(16);
        #endregion

        #region Methods
        /// <summary>
        /// Handles displaying menus on unit selection
        /// </summary>
        /// <param name="selection"></param>
        private void DisplaySelectedUnitInfo(SelectionType selection)
        {
            switch (selection)
            {
                //Only listen to unit calls
                case SelectionType.UNITS:
                    // Hide queue
                    this.queueParent.SetActive(false);

                    SortedSet<Unit> units = RTSPlayer.Instance.SelectedUnits;
                    if(units.Count > 1)
                    {
                        DisplayMultipleUnitInfo(units);
                    }
                    else if (units.Count == 1)
                    {
                        DisplaySingleObject(units.First());
                    }

                    break;

                case SelectionType.OTHER:
                    this.queueParent.SetActive(RTSPlayer.Instance.Selected is Castle castle && castle.IsControllable());
                    DisplaySingleObject(RTSPlayer.Instance.Selected);
                    break;

                case SelectionType.NONE:
                    //Hide display
                    this.multiUnitParent.SetActive(false);
                    this.singleUnitParent.SetActive(false);
                    this.queueParent.SetActive(false);
                    break;
            }
        }

        /// <summary>
        /// Given a single selected building or unit, display its information
        /// </summary>
        /// <param name="selected">Object to display</param>
        private void DisplaySingleObject(ISelectable selected)
        {
            this.multiUnitParent.SetActive(false);
            this.singleUnitParent.SetActive(true);
            this.title.text = selected.Info.Name;
            this.description.text = selected.Info.Description;
            this.icon.Selected = selected;
        }

        /// <summary>
        /// Given a list of units, display their information in the management menu
        /// </summary>
        /// <param name="units"></param>
        public void DisplayMultipleUnitInfo(SortedSet<Unit> units)
        {
            this.multiUnitParent.SetActive(true);
            this.singleUnitParent.SetActive(false);

            //Remove extra icons
            if (units.Count < this.displayed.Count)
            {
                int i = this.displayed.Count - 1;
                while (units.Count != this.displayed.Count)
                {
                    DisplayHealthAndIcon toRemove = this.displayed[i];
                    Destroy(toRemove.gameObject);
                    this.displayed.RemoveAt(i);
                }
            }
            //Add missing icons
            else if (units.Count > this.displayed.Count)
            {
                while (units.Count != this.displayed.Count)
                {
                    this.displayed.Add(Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.multiUnitParent.transform));
                }
            }
            //Setup icons
            if (units.Count != 0)
            {
                int i = 0;
                foreach (Unit u in units)
                {
                    this.displayed[i++].Selected = u;
                }
            }
        }
        #endregion

        #region Functions
        private void Awake() => GameEvents.OnSelectionChanged.AddListener(DisplaySelectedUnitInfo);

        private void OnDestroy() => GameEvents.OnSelectionChanged.RemoveListener(DisplaySelectedUnitInfo);
        #endregion
    }
}

