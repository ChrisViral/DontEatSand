using System.Collections.Generic;
using DontEatSand.Entities.Units;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    /// <summary>
    /// Display selected units' health and icons in the management menu (middle)
    /// </summary>
    public class DisplayUnitInfo : MonoBehaviour
    {
        #region Constants
        /// <summary>
        /// Gap between icons
        /// </summary>
        private const float ICON_GAP = 6f;
        #endregion

        #region Fields
        [SerializeField]
        private GameObject buttonPrefab;
        [SerializeField]
        private GameObject multiUnitParent;
        [SerializeField]
        private GameObject singleUnitParent;
        #endregion

        #region Methods
        private void DisplaySelectedUnitInfo(SelectionType selection)
        {
            Debug.Log(selection);

            //Only listen to unit calls
            if(selection == SelectionType.UNITS)
            {
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
        }

        /// <summary>
        /// Given a list of units, display their information in the management menu
        /// </summary>
        /// <param name="units"></param>
        public void DisplayMultipleUnitInfo(List<Unit> units)
        {
            this.multiUnitParent.SetActive(true);
            this.singleUnitParent.SetActive(false);

            List<GameObject> iconsList = new List<GameObject>();

            foreach(Unit unit in units)
            {
                GameObject newIcon = Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.multiUnitParent.transform);
                newIcon.GetComponent<Image>().sprite = unit.Info.Icon;
                newIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                newIcon.GetComponent<Button>().onClick.AddListener(() => DisplaySingleUnitInfo(unit));
                iconsList.Add(newIcon);
            }

            //TODO: Use an auto-layout function, you really shouldn't have to space them manually
            //Space them out
            int count = 0;
            foreach(GameObject icon in iconsList)
            {
                float yPos = 0f;
                Vector3 newPos = new Vector3((this.buttonPrefab.GetComponent<RectTransform>().rect.width + ICON_GAP) * count, yPos, 0f);
                if(newPos.x >= this.multiUnitParent.GetComponent<RectTransform>().rect.width)
                {
                    //TODO: You're not using this yPos after?
                    yPos += this.buttonPrefab.GetComponent<RectTransform>().rect.height + ICON_GAP;
                }

                icon.GetComponent<RectTransform>().localPosition += newPos;
                count++;
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
                if(child.name == "Health")
                {
                    child.GetComponent<DisplayHealth>().UnitToDisplay = unit;
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

