using System.Collections.Generic;
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
        #endregion

        #region Methods
        /// <summary>
        /// Handles displaying menus on unit selection
        /// </summary>
        /// <param name="selection"></param>
        private void DisplaySelectedUnitInfo(SelectionType selection)
        {
            //Only listen to unit calls
            if(selection == SelectionType.UNITS)
            {
                // Hide queue
                queueParent.SetActive(false);

                List<Unit> units = RTSPlayer.Instance.SelectedUnits;
                if(units.Count > 1)
                {
                    DisplayMultipleUnitInfo(units);
                }
                else if (units.Count == 1)
                {
                    DisplaySingleUnitInfo(units[0]);
                }
            }
            
            if(selection == SelectionType.OTHER)
            {
                
                if(RTSPlayer.Instance.Selected is Castle castle && castle.IsControllable())
                {
                    // Display queue
                    queueParent.SetActive(true);
                }
                else
                {
                    queueParent.SetActive(false);
                }
                Entity selected = (Entity) RTSPlayer.Instance.Selected;
                DisplaySelectedBuildingInfo(selected);
            }

            if(selection == SelectionType.NONE)
            {
                // Hide single unit info display
                //this.singleUnitParent.SetActive(false);
            }
        }

        /// <summary>
        /// Given a selected building, display its information
        /// </summary>
        /// <param name="building"></param>
        private void DisplaySelectedBuildingInfo(Entity building)
        {
            this.multiUnitParent.SetActive(false);
            this.singleUnitParent.SetActive(true);
            UnitInfo unitInfo = UnitDatabase.GetInfo(building.EntityName);
            foreach(Transform child in this.singleUnitParent.transform)
            {
                if(child.name == "Title")
                {
                    child.GetComponent<Text>().text = unitInfo.Name;
                }
                if(child.name == "Entity Icon")
                {
                    child.GetComponent<Image>().sprite = unitInfo.Icon;
                    // Display health
                    child.GetComponent<DisplayHealthAndIcon>().EntityToDisplay = building;
                }
                if(child.name == "Description")
                {
                    child.GetComponent<Text>().text = unitInfo.Description;
                }
            }
        }


        /// <summary>
        /// Given a list of units, display their information in the management menu
        /// </summary>
        /// <param name="units"></param>
        public void DisplayMultipleUnitInfo(List<Unit> units)
        {
            this.multiUnitParent.SetActive(true);
            this.singleUnitParent.SetActive(false);
            
            // First, clear all the children in the parent transform
            foreach(Transform child in multiUnitParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            // Then, create a new list
            List<GameObject> iconsList = new List<GameObject>();

            // Populate the list with buttons
            foreach(Unit unit in units)
            {
                GameObject newIcon = Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.multiUnitParent.transform);
                //newIcon.GetComponent<Image>().sprite = unit.Info.Icon;
                newIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                newIcon.GetComponent<Button>().onClick.AddListener(() => DisplaySingleUnitInfo(unit));
                newIcon.GetComponent<DisplayHealthAndIcon>().EntityToDisplay = unit;
                iconsList.Add(newIcon);

                // TODO: show unit health bars
            }

        }

        /// <summary>
        /// Given a single unit, display its info in the single unit info menu
        /// </summary>
        /// <param name="unit"></param>
        public void DisplaySingleUnitInfo(Unit unit)
        {
            this.multiUnitParent.SetActive(false);
            this.singleUnitParent.SetActive(true);
            UnitInfo unitInfo = UnitDatabase.GetInfo(unit.EntityName);
            foreach(Transform child in this.singleUnitParent.transform)
            {
                if(child.name == "Title")
                {
                    child.GetComponent<Text>().text = unitInfo.Name;
                }
                if(child.name == "Entity Icon")
                {
                    child.GetComponent<Image>().sprite = unitInfo.Icon;
                    // Display health
                    child.GetComponent<DisplayHealthAndIcon>().EntityToDisplay = unit;
                }
                if(child.name == "Description")
                {
                    child.GetComponent<Text>().text = unitInfo.Description;
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

