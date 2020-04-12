using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI
{
    public class DisplayUnitQueue : MonoBehaviour
    {
        private List<GameObject> unitQueue;

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private GameObject queueParent;

        private float ICON_GAP = 6f;
        
        private void OnUnitAddedToQueue(UnitInfo unitInfo)
        {
            GameObject newUnit = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, queueParent.transform);
            //newUnit.transform.SetParent(queueParent.transform);
            
            //newIcon.GetComponent<Image>().sprite = unit.Icon;
            newUnit.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            newUnit.GetComponent<Button>().onClick.AddListener(delegate{RemoveUnitFromQueue();});
            newUnit.GetComponent<RectTransform>().localPosition = new Vector3(-(buttonPrefab.GetComponent<RectTransform>().rect.width + ICON_GAP) * (unitQueue.Count + 1), 0f, 0f);

            // Add the unit to the queue visually
            unitQueue.Add(newUnit);
        }

        private void OnUnitRemovedFromQueue(int index)
        {
            unitQueue.RemoveAt(index);
        }
        
        private void Awake()
        {
            GameEvents.OnUnitAddedToQueue.AddListener(OnUnitAddedToQueue);
            GameEvents.OnUnitRemovedFromQueue.AddListener(OnUnitRemovedFromQueue);
        }

        private void Start()
        {
            unitQueue = new List<GameObject>();
        }

        private void RemoveUnitFromQueue()
        {

        }
    
    }
}

