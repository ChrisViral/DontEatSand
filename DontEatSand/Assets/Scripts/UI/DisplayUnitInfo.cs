using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand.Entities.Units;

namespace DontEatSand.UI
{
    /// <summary>
    /// Display selected units' health and icons in the management menu (middle)
    /// </summary>
    public class DisplayUnitInfo : MonoBehaviour
    {

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private GameObject multiUnitParent;

        [SerializeField]
        private GameObject singleUnitParent;

        private float ICON_GAP = 6f;

        private void Awake()
        {
            GameEvents.OnSelectionChanged.AddListener(DisplaySelectedUnitInfo);
        }

        private void Update()
        {
            // Debug.Log(RTSPlayer.Instance.SelectedUnits.Count);
        }

        private void DisplaySelectedUnitInfo(SelectionType selection)
        {
            Debug.Log(selection);
            // Do nothing if nothing is selected
            if(selection == SelectionType.NONE || selection == SelectionType.OTHER)
            {
                return;
            }

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
            multiUnitParent.SetActive(true);
            singleUnitParent.SetActive(false);
            
            List<GameObject> iconsList = new List<GameObject>();

            foreach(Unit unit in units)
            {
                GameObject newIcon = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, multiUnitParent.transform);
                newIcon.GetComponent<Image>().sprite = unit.Info.Icon;
                newIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                newIcon.GetComponent<Button>().onClick.AddListener(delegate{DisplaySingleUnitInfo(unit);});
                
                iconsList.Add(newIcon);
            }

            // Space them out
            int count = 0;
            foreach(GameObject icon in iconsList)
            {
                float yPos = 0f;
                Vector3 newPos = new Vector3((buttonPrefab.GetComponent<RectTransform>().rect.width + ICON_GAP) * count, yPos, 0f);
                if(newPos.x >= multiUnitParent.GetComponent<RectTransform>().rect.width)
                {
                    yPos += buttonPrefab.GetComponent<RectTransform>().rect.height + ICON_GAP;
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
            multiUnitParent.SetActive(false);
            singleUnitParent.SetActive(true);
            UnitInfo unitInfo = UnitDatabase.GetInfo(unit.EntityName);
            foreach(Transform child in singleUnitParent.transform)
            {
                if(child.name == "Title")
                {
                    child.GetComponent<Text>().text = unitInfo.Name;
                }
                if(child.name == "Health")
                {
                    child.GetComponent<DisplayHealth>().SetUnitToDisplay(unit);
                }
                if(child.name == "Description")
                {
                    child.GetComponent<Text>().text = unitInfo.Description;
                }
            }

        }

    }
}

