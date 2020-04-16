using DontEatSand.Base;
using DontEatSand.Entities.Buildings;
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
            if (target is Sandpit sandpit)
            {
                this.HasOrderFlag = true;
                this.Destination = sandpit.transform.position;
                Dig(sandpit);
            }
            // Else if target is building, build
            else if (target is CandyFactory candyFactory)
            {
                this.HasOrderFlag = true;
                this.Target = candyFactory;
                Build(candyFactory);
            }
        }
        
        public void Dig(Sandpit sandpit)
        {
            if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                // Set animation bool for digging
                animator.SetBool(digTriggerName, true);
                
                // Take sand from sandpit
                sandpit.HarvestSand(10);
            }
        }

        public void Build(CandyFactory candyFactory)
        {
            if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                // Set animation boll for building
                animator.SetBool(buildTriggerName, true);
                
                // Build building
            }
        }
        #endregion
    }
}
