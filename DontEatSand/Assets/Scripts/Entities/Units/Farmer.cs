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
        private bool isBuilding;
        private float buildDistance = 2f;
        private float digDistance = 0.5f;
        #endregion

        #region Properties

        private Sandpit SandPitTarget { get; set; }
        public CandyFactory BuildTarget { get; set; }

        /// <summary>
        /// If the unit can currently dig
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

                return digReady && Vector3.Distance(this.Position, this.Agent.destination) <= digDistance && BuildTarget == null;
            }
        }

        public void DoneBuilding()
        {
            isBuilding = false;
            
            // Reset stopping distance
            this.Agent.stoppingDistance = digDistance;
                
            // Set animation bool for digging
            animator.SetBool(buildParam, false);
            BuildTarget = null;
        }

        #endregion

        #region Methods

        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            // If target is wet sand, dig
            if (BuildTarget == null && target is Sandpit sandpit)
            {
                this.HasOrderFlag = true;
                this.digDistance = digDistance;
                this.SandPitTarget = sandpit;
            }
        }

        public void Dig(Sandpit sandpit)
        {
            if (CanDig)
            {
                // Set animation bool for digging
                animator.SetBool(digParam, true);

                // Take sand from sandpit
                GameEvents.OnSandChanged.Invoke(sandpit.HarvestSand(10));
            }
            else
            {
                // Set animation bool for digging
                animator.SetBool(digParam, false);
            }
        }

        public void Build(CandyFactory candyFactory)
        {
            // Farmer just started building
            if (BuildTarget == null && !isBuilding)
            {
                // Set new stopping distance for building
                this.Agent.stoppingDistance = buildDistance;

                BuildTarget = candyFactory;
                Destination = BuildTarget.Position;
            }
            // Farmer has arrived and will start building
            else if (!isBuilding && Vector3.Distance(Position, Agent.destination) <= buildDistance)
            {
                // Set animation bool for building
                animator.SetBool(buildParam, true);
                
                // Tell CandyFactory
                BuildTarget.StartBuilding();

                isBuilding = true;
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

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (BuildTarget != null)
            {
                Build(BuildTarget);
            }
            else if (SandPitTarget != null)
            {
                Dig(SandPitTarget);
            }
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
