using DontEatSand.Entities.Buildings;
using DontEatSand.Utils;
using DontEatSand.Utils.BehaviourTrees;
using Photon.Pun;
using UnityEngine;
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
        protected override string BehaviourTreeLocation => DESUtils.FarmerBehaviourTreeLocation;

        private Sandpit SandPitTarget { get; set; }

        public CandyFactory BuildTarget { get; set; }

        /// <summary>
        /// If the unit can currently dig
        /// </summary>
        private bool CanDig
        {
            get
            {
                bool digReady = false;
                if (Time.time > this.digStart + this.digInterval)
                {
                    this.digStart = Time.time;
                    digReady = true;
                }

                return digReady && Vector3.Distance(this.Position, this.Agent.destination) <= this.digDistance && this.BuildTarget == null;
            }
        }

        public void DoneBuilding()
        {
            this.isBuilding = false;

            // Reset stopping distance
            this.Agent.stoppingDistance = this.digDistance;

            // Set animation bool for digging
            this.animator.SetBool(buildParam, false);
            this.BuildTarget = null;
        }

        #endregion

        #region Methods

        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            // If target is wet sand, dig
            if (this.BuildTarget == null && target is Sandpit sandpit)
            {
                this.HasOrderFlag = true;
                //this.digDistance = this.digDistance; <- Useless
                this.SandPitTarget = sandpit;
            }
        }

        public void Dig(Sandpit sandpit)
        {
            if (this.CanDig)
            {
                // Set animation bool for digging
                this.animator.SetBool(digParam, true);

                // Take sand from sandpit
                GameEvents.OnSandChanged.Invoke(sandpit.HarvestSand(10));
            }
            else
            {
                // Set animation bool for digging
                this.animator.SetBool(digParam, false);
            }
        }

        public void Build(CandyFactory candyFactory)
        {
            // Farmer just started building
            if (this.BuildTarget == null && !this.isBuilding)
            {
                // Set new stopping distance for building
                this.Agent.stoppingDistance = this.buildDistance;

                this.BuildTarget = candyFactory;
                this.Destination = this.BuildTarget.Position;
            }
            // Farmer has arrived and will start building
            else if (!this.isBuilding && Vector3.Distance(this.Position, this.Agent.destination) <= this.buildDistance)
            {
                // Set animation bool for building
                this.animator.SetBool(buildParam, true);

                // Tell CandyFactory
                this.BuildTarget.StartBuilding();

                this.isBuilding = true;
            }
        }

        public void Flee()
        {
            // Set destination away from enemy
            this.Destination = this.transform.position - FindClosestTarget().transform.position;
        }

        #endregion

        #region Functions
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (this.BuildTarget != null)
            {
                Build(this.BuildTarget);
            }
            else if (this.SandPitTarget != null)
            {
                Dig(this.SandPitTarget);
            }
        }

        protected override void OnDestroyed()
        {
            base.OnDestroyed();

            if (this.isBuilding)
            {
                // Destroy building too
                PhotonNetwork.Destroy(this.BuildTarget.gameObject);
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
            if (this.IsUnderAttackFlag)
            {
                Flee();
                yield return BTNodeResult.NOT_FINISHED;
            }
            yield return BTNodeResult.SUCCESS;
        }

        #endregion
    }
}
