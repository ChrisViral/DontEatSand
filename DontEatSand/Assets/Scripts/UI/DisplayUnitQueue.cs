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
        
        private void OnUnitAddedToQueue(UnitInfo unit)
        {
            GameObject newUnit = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, queueParent.transform);
            //newIcon.GetComponent<Image>().sprite = unit.Icon;
            newUnit.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            newUnit.GetComponent<Button>().onClick.AddListener(delegate{RemoveUnitFromQueue();});
            unitQueue.Add(newUnit);
            newUnit.transform.SetParent(queueParent.transform);
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

        private void RemoveUnitFromQueue()
        {

        }
    
    }
}

