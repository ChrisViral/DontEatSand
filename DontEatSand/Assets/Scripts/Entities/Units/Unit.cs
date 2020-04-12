using UnityEngine;
using UnityEngine.AI;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Unit base class
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
    public class Unit : Entity
    {
        #region Constants
        private const float OFFSET_MAGNITUDE = 5f;
        #endregion

        #region Fields
        private NavMeshAgent agent;
        #endregion

        #region Properties
        /// <summary>
        /// Current target of this unit
        /// </summary>
        public Transform Target { get; set; }

        /// <summary>
        /// Sprite representing this unit
        /// </summary>
        public Sprite Icon;

        /// <summary>
        /// Destination of this unit
        /// </summary>
        public Vector3 Destination
        {
            get => this.agent.destination;
            set
            {
                this.Target = null;
                this.agent.SetDestination(value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Moves unit to destination offset by the average position of the cluster
        /// if the unit is too far off of the cluster, it will simply move to the target location without an offset
        /// </summary>
        /// <param name="dest">Destination point user clicked</param>
        /// <param name="averagePosition">Average position of cluster</param>
        public void MoveUnit(Vector3 dest, Vector3 averagePosition)
        {
            Vector3 positionDiff = this.transform.position - averagePosition;
            if (positionDiff.magnitude > OFFSET_MAGNITUDE)
            {
                positionDiff = Vector3.zero;
            }

            this.Destination = dest + positionDiff;
        }
        #endregion

        #region Functions
        protected override void OnAwake() => this.agent = GetComponent<NavMeshAgent>();

        private void Update()
        {
            if (this.Target)
            {
                this.agent.destination = this.Target.position;
            }
        }

        private void Destroy()
        {
            //Notify of death and give back sand
            GameEvents.OnUnitDestroyed.Invoke(this);
            GameEvents.OnCandyChanged.Invoke(-this.Info.CandyCost);
        }
        #endregion
    }
}