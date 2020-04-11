using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand.Entities;

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

        [SerializeField]
        private List<TestUnit> list;

        [SerializeField]
        private Transform multiIconAnchor;

        private void Start()
        {
            List<GameObject> iconsList = GetUnitsWithButtons(list);
        }

        /// <summary>
        /// Given a list of units, display their information in the management menu
        /// </summary>
        /// <param name="units"></param>
        public List<GameObject> GetUnitsWithButtons(List<TestUnit> units)
        {
            List<GameObject> iconsList = new List<GameObject>();
            
            // Return an empty list if there are no units selected
            if(units == null)
            {
                return iconsList;
            }
            
            // Create button objects for each unit
            foreach(TestUnit unit in units)
            {
                GameObject newIcon = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, multiUnitParent.transform);
                newIcon.GetComponent<Image>().sprite = unit.icon;
                newIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero + new Vector3(42f, -55f, 0f);
                newIcon.GetComponent<Button>().onClick.AddListener(delegate{DisplaySingleUnitInfo(unit.EntityName);});
                iconsList.Add(newIcon);
                newIcon.transform.SetParent(multiUnitParent.transform);
            }

            // Space them out
            int count = 0;
            foreach(GameObject icon in iconsList)
            {
                float yPos = 0f;
                Vector3 newPos = new Vector3((buttonPrefab.GetComponent<RectTransform>().rect.width + 6f) * count, yPos, 0f);
                if(newPos.x >= multiUnitParent.GetComponent<RectTransform>().rect.width)
                {
                    yPos += buttonPrefab.GetComponent<RectTransform>().rect.height + 6f;
                }
                
                icon.GetComponent<RectTransform>().localPosition += newPos;
                count++;
            }

            return iconsList;

        }

        public void DisplaySingleUnitInfo(string entityName)
        {
            multiUnitParent.SetActive(false);
            singleUnitParent.SetActive(true);
            UnitInfo unitInfo = UnitDatabase.GetInfo(entityName);
            foreach(Transform child in singleUnitParent.transform)
            {
                if(child.name == "Title")
                {
                    child.GetComponent<Text>().text = unitInfo.Name;
                }
                if(child.name == "Description")
                {
                    child.GetComponent<Text>().text = unitInfo.Description;
                }
            }
            
        }

    }
}

