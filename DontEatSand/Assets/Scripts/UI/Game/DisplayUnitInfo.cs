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
        private GameObject buttonPrefab;
        [SerializeField]
        private GameObject multiUnitParent;
        [SerializeField]
        private GameObject singleUnitParent;
        [SerializeField]
        private GameObject queueParent;
        [SerializeField]
        private Text title, description;
        [SerializeField]
        private DisplayHealthAndIcon health;
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
            this.health.Selected = selected;
        }

        /// <summary>
        /// Given a list of units, display their information in the management menu
        /// </summary>
        /// <param name="units"></param>
        public void DisplayMultipleUnitInfo(SortedSet<Unit> units)
        {
            this.multiUnitParent.SetActive(true);
            this.singleUnitParent.SetActive(false);

            // First, clear all the children in the parent transform
            foreach(Transform child in this.multiUnitParent.transform)
            {
                Destroy(child.gameObject);
            }

            // Then, create a new list
            List<GameObject> iconsList = new List<GameObject>();

            // Populate the list with buttons
            foreach(Unit unit in units)
            {
                GameObject newIcon = Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.multiUnitParent.transform);
                //newIcon.GetComponent<Image>().sprite = unit.Info.Icon;
                newIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                newIcon.GetComponent<Button>().onClick.AddListener(() => DisplaySingleObject(unit));
                newIcon.GetComponent<DisplayHealthAndIcon>().Selected = unit;
                iconsList.Add(newIcon);
            }
        }
        #endregion

        #region Functions
        private void Awake() => GameEvents.OnSelectionChanged.AddListener(DisplaySelectedUnitInfo);

        private void OnDestroy() => GameEvents.OnSelectionChanged.RemoveListener(DisplaySelectedUnitInfo);
        #endregion
    }
}

