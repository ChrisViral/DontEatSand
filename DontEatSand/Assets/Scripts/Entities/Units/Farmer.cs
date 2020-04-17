using DontEatSand.Base;
using DontEatSand.Entities.Buildings;
using DontEatSand.Utils;
using DontEatSand.Utils.BehaviourTrees;
using UnityEngine;
using UnityEngine.AI;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Entities.Units
{
    public class Farmer : Unit
    {
        #region Constants
        /// Animator dig trigger name
        /// </summary>
        private static readonly int digParam = Animator.StringToHash("Digging");
        /// Animator build trigger name
        /// </summary>
        private static readonly int buildParam = Animator.StringToHash("Building");
        #endregion

        #region Fields
        private float digStart;
        private float digInterval = 3.0f;
        #endregion

        #region Properties

        /// <summary>
        /// If the unit can currently attack
        /// </summary>
        private bool CanDig {
            get
            {
                bool digReady = false;
                if(Time.time > this.digStart + this.digInterval)
                {
                    this.digStart = Time.time;
                    digReady = true;
                }
                return digReady && this.Target != null && Vector3.Distance(this.Position, this.Target.Position) < 1.0f;
            }
        }

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
            if (CanDig)
            {
                // Set animation bool for digging
                animator.SetBool(digParam, true);
                
                // Take sand from sandpit
                sandpit.HarvestSand(10);
            }
        }

        public void Build(CandyFactory candyFactory)
        {
            if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                // Set animation boll for building
                animator.SetBool(buildParam, true);
                
                // Build building
                // TODO building factories
            }
        }

        public void Flee()
        {
            // Set destination away from enemy
            Destination = transform.position - FindClosestTarget().transform.position;
        }
        
        #endregion

        #region Functions

        protected override void OnAwake()
        {
            base.OnAwake();
            
            // This probably doesn't work. Need to load farmer behavior tree
            bt = new BehaviourTree(DESUtils.FarmerBehaviourTreeLocation, this);
        }

        #endregion

        #region BehaviourTree

        /// <summary>
        /// Routine for the flee leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("flee")]
        public BTCoroutine FleeRoutine()
        {
            if (IsUnderAttackFlag)
            {
                Flee();
                yield return BTNodeResult.NOT_FINISHED;
            }
            yield return BTNodeResult.SUCCESS;
        }

        #endregion
    }
}
