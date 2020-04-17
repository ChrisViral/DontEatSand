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
        /// <summary>
        /// Animator dig trigger name
        /// </summary>
        private static readonly int digParam = Animator.StringToHash("Digging");

        /// <summary>
        /// Animator build trigger name
        /// </summary>
        private static readonly int buildParam = Animator.StringToHash("Building");

        private const float DIG_INTERVAL = 3.0f;

        private const float BUILD_DISTANCE = 3f;

        private const float DIG_DISTANCE = 0.5f;
        #endregion

        #region Fields
        private float digStart;
        private bool isBuilding;
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
                if (Time.time > this.digStart + DIG_INTERVAL)
                {
                    this.digStart = Time.time;
                    digReady = true;
                }

                return digReady && Vector3.Distance(this.Position, this.Agent.destination) <= DIG_DISTANCE && this.BuildTarget == null;
            }
        }

        public void DoneBuilding()
        {
            this.isBuilding = false;

            // Reset stopping distance
            this.Agent.stoppingDistance = DIG_DISTANCE;

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
                this.Agent.stoppingDistance = BUILD_DISTANCE;

                this.BuildTarget = candyFactory;
                this.Destination = this.BuildTarget.Position;
            }
            // Farmer has arrived and will start building
            else if (!this.isBuilding && Vector3.Distance(this.Position, this.Agent.destination) <= BUILD_DISTANCE)
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
