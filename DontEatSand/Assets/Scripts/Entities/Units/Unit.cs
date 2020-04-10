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
        #region Fields
        private NavMeshAgent agent;
        #endregion

        #region Properties
        /// <summary>
        /// Current target of this unit
        /// </summary>
        public Transform Target { get; set; }

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