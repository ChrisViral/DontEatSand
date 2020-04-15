using System.Collections.Generic;
using DontEatSand.Entities.Units;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    public class DisplayUnitQueue : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject buttonPrefab;

        private readonly LinkedList<(UnitInfo info, GameObject icon)> unitQueue = new LinkedList<(UnitInfo, GameObject)>();
        private float buildTimer;
        #endregion

        #region Methods
        private void OnUnitAddedToQueue(UnitInfo unitInfo)
        {
            GameObject newUnit = Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);

            newUnit.GetComponent<Image>().sprite = unitInfo.Icon;
            newUnit.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            newUnit.GetComponent<Button>().onClick.AddListener(() => RemoveUnitFromQueue(newUnit));

            // Add the unit to the queue visually
            this.unitQueue.AddLast((unitInfo, newUnit));
        }

        private void OnUnitCreated(Unit unit)
        {
            LinkedListNode<(UnitInfo, GameObject icon)> toRemove = this.unitQueue.First;
            this.unitQueue.Remove(toRemove);
            Destroy(toRemove.Value.icon);
        }

        private void RemoveUnitFromQueue(GameObject iconToRemove)
        {
            int count = 0;
            LinkedListNode<(UnitInfo, GameObject icon)> node = this.unitQueue.First;
            while(node != null)
            {
                var nextNode = node.Next;
                if (node.Value.icon == iconToRemove)
                {
                    this.unitQueue.Remove(node);
                    Destroy(node.Value.icon);
                    break;
                }
                count++;
                node = nextNode;
            }

            GameEvents.OnUnitRemovedFromQueue.Invoke(count);
        }
        #endregion

        #region Functions
        private void Awake()
        {
            GameEvents.OnUnitAddedToQueue.AddListener(OnUnitAddedToQueue);
            GameEvents.OnUnitCreated.AddListener(OnUnitCreated);
        }

        private void Update()
        {
            LinkedListNode<(UnitInfo info, GameObject icon)> currentlyBuilding = this.unitQueue.First;
            if(currentlyBuilding != null)
            {
                 float timeToBuild = currentlyBuilding.Value.info.BuildTime;
                 Image icon = currentlyBuilding.Value.icon.transform.GetChild(0).GetComponent<Image>();
                 icon.fillAmount -= Time.deltaTime / timeToBuild;
            }
        }
        #endregion

    }
}

