using UnityEngine;
using System.Collections.Generic;
using DontEatSand.Utils.BehaviourTrees;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;


namespace DontEatSand.Entities.Units
{
    public class Healer : Unit
    {
        #region Fields
        [SerializeField]
        private GameObject projectile;
        private readonly HashSet<Unit> allyUnitsInRange = new HashSet<Unit>();
        #endregion

        #region Properties
        /// <summary>
        /// Flag dictating if an enemy is within the aggro range
        /// </summary>
        public bool IsAllySeenFlag
        {
            get
            {
                return this.allyUnitsInRange.Count != 0;
            }
            set
            {

            }
        }


        /// <summary>
        /// If the unit can currently attack
        /// </summary>
        public override bool CanAttack
        {
            get
            {
                bool attackReady = false;
                if(Time.time > this.attackStart + this.attackInterval)
                {
                    this.attackStart = Time.time;
                    attackReady = true;
                }
                return attackReady && this.Target != null && Vector3.Distance(this.Position, this.Target.Position) < 10.0f;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Heal a given target
        /// </summary>
        private void Heal (Entity target)
        {
            // Set animator trigger for healing
            this.animator.SetTrigger(this.attackTriggerName);

            target.Damage(-10);
        }


        /// <summary>
        /// Find the closest enemy unit to this unit
        /// </summary>
        /// <returns></returns>
        private Unit FindClosestAlly()
        {
            int size = this.allyUnitsInRange.Count;
            if (size == 0) return null;

            //Get closest target
            Unit closestTarget = null;
            Vector3 position = this.transform.position;
            float distanceToClosest = float.PositiveInfinity;
            foreach (Unit ally in this.allyUnitsInRange)
            {
                float dist = Vector3.Distance(ally.Position, position);
                //Making sure it's a valid entity target
                if(dist < distanceToClosest) // && (!PhotonNetwork.IsConnected || entity.photonView.IsMine))
                {
                    distanceToClosest = dist;
                    closestTarget = ally;
                }
            }

            //Return it's entity
            return closestTarget;
        }

        public void Flee()
        {
            // Set destination away from enemy
            Destination = transform.position - FindClosestTarget().transform.position;
        }

        #endregion

        #region Methods
        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            if(this.IsSelected)
            {
                HasOrderFlag = true;
                // Acknowledge clicked entity as a target for this unit
                if (target is Entity entity) //&& !entity.IsControllable())
                {
                    this.Target = entity;
                }
            }
        }
        #endregion

        #region Functions

        protected override void OnAwake()
        {
            base.OnAwake();

            // Set throwing animation trigger
            attackTriggerName = Animator.StringToHash("Throwing");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            // if target exists and is within range
            if(CanAttack && Target != null)
            {
                Heal(Target);
            }

        }
        #endregion

        #region Collider Functions
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.isTrigger) { return; }

            if(collider.transform.parent.TryGetComponent(out Unit allyUnit)) // && !enemyUnit.IsControllable())
            {
                // Populate enemies
                this.allyUnitsInRange.Add(allyUnit);
            }

        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.isTrigger) { return; }

            if(collider.transform.parent.TryGetComponent(out Unit allyUnit) && this.allyUnitsInRange.Contains(allyUnit))
            {
                this.allyUnitsInRange.Remove(allyUnit);
            }
        }
        #endregion

        #region BehaviourTree

        /// <summary>
        /// Get the flag for the condition isEnemySeenFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("ally-seen")]
        public bool IsAllySeen() => this.IsAllySeenFlag;

        [BTLeaf("heal")]
        public BTCoroutine HealRoutine()
        {
            if(IsAllySeenFlag)
            {
                this.Target = FindClosestAlly();
                if(this.Target)
                {
                    this.Agent.SetDestination(this.Target.Position);
                    if(this.CanAttack) // using the same timer as attack
                    {
                        Heal(this.Target);
                        yield return BTNodeResult.NOT_FINISHED;
                    }
                }
            }
            else
            {
                yield return BTNodeResult.FAILURE;
            }

        }

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
