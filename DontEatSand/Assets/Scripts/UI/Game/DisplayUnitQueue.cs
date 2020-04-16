using System.Collections.Generic;
using DontEatSand.Entities.Units;
using UnityEngine;

namespace DontEatSand.UI.Game
{
    public class DisplayUnitQueue : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private QueueIcon buttonPrefab;
        private readonly LinkedList<QueueIcon> unitQueue = new LinkedList<QueueIcon>();
        #endregion

        #region Methods
        private void OnUnitAddedToQueue(UnitInfo unitInfo)
        {
            QueueIcon newUnit = Instantiate(this.buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
            newUnit.Setup(unitInfo, () => RemoveUnitFromQueue(newUnit));
            // Add the unit to the queue visually
            this.unitQueue.AddLast(newUnit);
        }

        private void OnUnitCreated(Unit unit)
        {
            Destroy(this.unitQueue.First.Value.gameObject);
            this.unitQueue.RemoveFirst();
        }

        private void RemoveUnitFromQueue(QueueIcon iconToRemove)
        {
            int i;
            LinkedListNode<QueueIcon> node = this.unitQueue.First;
            for (i = 0; node != null && node.Value != iconToRemove; i++)
            {
                node = node.Next;
            }

            Destroy(node?.Value.gameObject);
            GameEvents.OnUnitRemovedFromQueue.Invoke(i);
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
            //Set build progress
            LinkedListNode<QueueIcon> top = this.unitQueue.First;
            if (top != null)
            {
                top.Value.FillAmount = RTSPlayer.Instance.Castle.BuildProgress;
            }
        }

        private void OnDestroy()
        {
            GameEvents.OnUnitAddedToQueue.RemoveListener(OnUnitAddedToQueue);
            GameEvents.OnUnitCreated.RemoveListener(OnUnitCreated);
        }
        #endregion

    }
}

