using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand.Entities.Units;


namespace DontEatSand.UI
{
    public class DisplayUnitQueue : MonoBehaviour
    {
        private LinkedList<(UnitInfo info, GameObject icon)> unitQueue = new LinkedList<(UnitInfo, GameObject)>();
        private float buildTimer;

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private GameObject progressBarPrefab;

        [SerializeField]
        private GameObject queueParent;

        private float ICON_GAP = 6f;
        
        private void OnUnitAddedToQueue(UnitInfo unitInfo)
        {
            GameObject newUnit = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, queueParent.transform);
            
            newUnit.GetComponent<Image>().sprite = unitInfo.Icon;
            newUnit.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            newUnit.GetComponent<Button>().onClick.AddListener(delegate{RemoveUnitFromQueue(newUnit);});

            // Add the unit to the queue visually
            unitQueue.AddLast((unitInfo, newUnit));
            UpdateIconPositions();
        }

        private void OnUnitRemovedFromQueue(int index)
        {
            int count = 0;
            var node = unitQueue.First;
            while(node != null)
            {
                var nextNode = node.Next;
                count++;
                if (count == index)
                {
                    unitQueue.Remove(node);
                }
                node = nextNode;
            }
            UpdateIconPositions();
        }

        private void OnUnitCreated(Unit unit)
        {
            LinkedListNode<(UnitInfo, GameObject icon)> toRemove = unitQueue.First;
            unitQueue.Remove(toRemove);
            Destroy(toRemove.Value.icon);
            UpdateIconPositions();
        }

        private void UpdateIconPositions()
        {
            int count = 0;
            foreach((UnitInfo info, GameObject unit) in unitQueue)
            {
                count++;
                float xPos = buttonPrefab.GetComponent<RectTransform>().rect.width + ICON_GAP;
                unit.GetComponent<RectTransform>().localPosition = new Vector3(-(xPos) * count, 0f, 0f);
            }
        }
        
        private void Awake()
        {
            GameEvents.OnUnitAddedToQueue.AddListener(OnUnitAddedToQueue);
            //GameEvents.OnUnitRemovedFromQueue.AddListener(OnUnitRemovedFromQueue);
            GameEvents.OnUnitCreated.AddListener(OnUnitCreated);
        }

        private void Update()
        {
            LinkedListNode<(UnitInfo info, GameObject icon)> currentlyBuilding = unitQueue.First;
            if(currentlyBuilding != null)
            {
                 UnityEngine.Debug.Log("currently building");
                 float timeToBuild = currentlyBuilding.Value.info.BuildTime;
                 currentlyBuilding.Value.icon.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime/timeToBuild;
            }
        }

        private void RemoveUnitFromQueue(GameObject iconToRemove)
        {
            int count = 0;
            LinkedListNode<(UnitInfo, GameObject icon)> node = unitQueue.First;
            while(node != null)
            {
                var nextNode = node.Next;
                if (node.Value.icon == iconToRemove)
                {
                    unitQueue.Remove(node);
                    Destroy(node.Value.icon);
                    UpdateIconPositions();
                    break;
                }
                count++;
                node = nextNode;
            }

            GameEvents.OnUnitRemovedFromQueue.Invoke(count);


        }
    
    }
}

