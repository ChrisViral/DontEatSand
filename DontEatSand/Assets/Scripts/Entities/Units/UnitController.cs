using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DontEatSand.Entities.Units
{
    public class UnitController : MonoBehaviour
    {

        private NavMeshAgent navAgent;
        private Transform currentTarget;
        private readonly float OFFSET_MAGNITUDE = 5f;

        // Start is called before the first frame update
        private void Start() => this.navAgent = GetComponent<NavMeshAgent>();

        // Update is called once per frame
        private void Update()
        {
            if (this.currentTarget != null)
            {
                this.navAgent.destination = this.currentTarget.position;
            }
        }

        /// <summary>
        /// Moves unit to destination offset by the average position of the cluster
        /// if the unit is too far off of the cluster, it will simply move to the target location without an offset
        /// </summary>
        /// <param name="dest">Destination point user clicked</param>
        /// <param name="averagePosition">Average position of cluster</param>
        public void MoveUnit(Vector3 dest, Vector3 averagePosition)
        {
            Vector3 positionDiff = transform.position - averagePosition;
            if (positionDiff.magnitude > OFFSET_MAGNITUDE)
            {
                positionDiff = Vector3.zero;
            }
            this.currentTarget = null;
            this.navAgent.destination = dest + positionDiff;
        }

        public void SetNewTarget(Transform enemy)
        {
            this.currentTarget = enemy;
        }
    }
}