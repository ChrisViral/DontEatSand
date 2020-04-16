using DontEatSand.Base;
using UnityEngine;
using UnityEngine.AI;

namespace DontEatSand.Entities.Units
{
    public class Farmer : Unit
    {
        #region Constants
        /// Animator dig trigger name
        /// </summary>
        private int digTriggerName = Animator.StringToHash("Digging");
        /// Animator build trigger name
        /// </summary>
        private int buildTriggerName = Animator.StringToHash("Building");
        #endregion


        #region Methods

        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            // If target is wet sand, dig
            if (target is Discoverable discoverable)
            {
                this.HasOrderFlag = true;
                this.Destination = discoverable.transform.position;
                Dig();
            }
            // Else if target is building, build
            else if (target is Entity entity)
            {
                this.HasOrderFlag = true;
                this.Target = entity;
                Build();
            }
        }
        
        public void Dig()
        {
            if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                // Set animation trigger
                animator.SetTrigger(digTriggerName);
                
                // Take sand from sandpit
            }
        }

        public void Build()
        {
            if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                // Set animation trigger
                animator.SetTrigger(buildTriggerName);
                
                // Build building
            }
        }
        #endregion
    }
}
