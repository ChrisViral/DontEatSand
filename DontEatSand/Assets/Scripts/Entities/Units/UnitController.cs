using UnityEngine;
using UnityEngine.AI;

namespace DontEatSand.Entities.Units
{
    public class UnitController : MonoBehaviour
    {

        private NavMeshAgent navAgent;
        private Transform currentTarget;

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

        public void MoveUnit(Vector3 dest)
        {
            this.currentTarget = null;
            this.navAgent.destination = dest;
        }

        public void SetNewTarget(Transform enemy)
        {
            this.currentTarget = enemy;
        }
    }
}