using System.Collections.Generic;
using DontEatSand.Entities.Units;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    public class DisplayUnitQueue : MonoBehaviour
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
        private GameObject progressBarPrefab;
        [SerializeField]
        private GameObject queueParent;
        private readonly LinkedList<(UnitInfo info, GameObject icon)> unitQueue = new LinkedList<(UnitInfo, GameObject)>();
        private float buildTimer;
        #endregion

        #region Methods
        private void OnUnitAddedToQueue(UnitInfo unitInfo)
        {
            GameObject newUnit = Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.queueParent.transform);

            newUnit.GetComponent<Image>().sprite = unitInfo.Icon;
            newUnit.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            newUnit.GetComponent<Button>().onClick.AddListener(delegate{RemoveUnitFromQueue(newUnit);});

            // Add the unit to the queue visually
            this.unitQueue.AddLast((unitInfo, newUnit));
            UpdateIconPositions();
        }

        private void OnUnitRemovedFromQueue(int index)
        {
            int count = 0;
            var node = this.unitQueue.First;
            while(node != null)
            {
                var nextNode = node.Next;
                count++;
                if (count == index)
                {
                    this.unitQueue.Remove(node);
                }
                node = nextNode;
            }
            UpdateIconPositions();
        }

        private void OnUnitCreated(Unit unit)
        {
            LinkedListNode<(UnitInfo, GameObject icon)> toRemove = this.unitQueue.First;
            this.unitQueue.Remove(toRemove);
            Destroy(toRemove.Value.icon);
            UpdateIconPositions();
        }

        private void UpdateIconPositions()
        {
            int count = 0;
            foreach((UnitInfo info, GameObject unit) in this.unitQueue)
            {
                count++;
                float xPos = this.buttonPrefab.GetComponent<RectTransform>().rect.width + ICON_GAP;
                unit.GetComponent<RectTransform>().localPosition = new Vector3(-(xPos) * count, 0f, 0f);
            }
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
                    UpdateIconPositions();
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
            //GameEvents.OnUnitRemovedFromQueue.AddListener(OnUnitRemovedFromQueue);
            GameEvents.OnUnitCreated.AddListener(OnUnitCreated);
        }

        private void Update()
        {
            LinkedListNode<(UnitInfo info, GameObject icon)> currentlyBuilding = this.unitQueue.First;
            if(currentlyBuilding != null)
            {
                 UnityEngine.Debug.Log("currently building");
                 float timeToBuild = currentlyBuilding.Value.info.BuildTime;
                 currentlyBuilding.Value.icon.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime/timeToBuild;
            }
        }
        #endregion

    }
}

