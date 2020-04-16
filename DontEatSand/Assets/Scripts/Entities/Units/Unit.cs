using System;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using DontEatSand.Utils.BehaviourTrees;
using UnityEngine;
using UnityEngine.AI;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Unit base class
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Unit : Entity, IComparable<Unit>
    {
        #region Constants
        private const float OFFSET_MAGNITUDE = 5f;
        private enum Mode { ATTACK, DEFEND }

        #endregion

        #region Fields
        private NavMeshAgent agent;
        private BehaviourTree bt;
        private Mode behaviourMode;
        private SphereCollider aggroSphere;
        #endregion

        #region Properties
        /// <summary>
        /// Current target of this unit
        /// </summary>
        public Entity Target { get; set; }

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

        /// <summary>
        /// Flag dictating if the unit is following an order
        /// </summary>
        public bool HasOrderFlag
        {
            get
            {
                return agent.pathStatus == NavMeshPathStatus.PathComplete ? false : true;
            }
            set { }
        }

        /// <summary>
        /// Flag dictating if an enemy is within the aggro range
        /// </summary>
        public bool IsEnemySeenFlag
        {
            get
            {
                return aggroSphere.bounds.Contains(Target.transform.position);
            }
        }

        /// <summary>
        /// Flag dictating if the enemy is attacking this unit
        /// </summary>
        public bool IsUnderAttackFlag { get; set; } //needs to be set
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
            HasOrderFlag = true;

            Vector3 positionDiff = this.transform.position - averagePosition;
            if (positionDiff.magnitude > OFFSET_MAGNITUDE)
            {
                positionDiff = Vector3.zero;
                HasOrderFlag = false;
            }

            this.Destination = dest + positionDiff;
        }

        /// <inheritdoc cref="IComparable{T}.CompareTo"/>
        public int CompareTo(Unit other)
        {
            int c = this.Info.Type.CompareTo(other.Info.Type);
            return c == 0 ? StringComparer.InvariantCulture.Compare(this.EntityName, other.EntityName) : c;
        }

        public virtual void Attack(Entity target)
        {
            Target = target;
            HasOrderFlag = true; // shouldn't be here

            //Do the animator thingy

            //Make the target take damage
            target.Damage(10);
        }

        public Entity FindClosestTarget()
        {
            Collider[] targets = Physics.OverlapSphere(this.transform.position, aggroSphere.radius);
            Entity closestTarget = null;
            float distanceToClosest = float.MaxValue;
            int i = 0;
            while(i < targets.Length)
            {
                float dist = Vector3.Distance(targets[i].transform.position, this.transform.position);
                if(dist < distanceToClosest)
                {
                    distanceToClosest = dist;
                    closestTarget = targets[i].gameObject.GetComponent<Entity>();
                }
            }

            return closestTarget;
        }

        #endregion

        #region Virtual methods
        /// <summary>
        /// Processes commands from the player
        /// Make sure to call base.ProcessCommand if overriding!
        /// </summary>
        /// <param name="destination">Position in the world of the command</param>
        /// <param name="target">Target of the command</param>
        protected virtual void ProcessCommand(Vector3 destination, ISelectable target)
        {
            if (this.IsSelected)
            {
                MoveUnit(destination, RTSPlayer.Instance.AveragePosition);
            }
        }

        /// <summary>
        /// Update function, only called on non-networked units. Use this instead of Update()
        /// </summary>
        protected virtual void OnUpdate() { }

        /// <summary>
        /// OnDestroy function, use this instead of OnDestroy()
        /// </summary>
        protected virtual void OnDestroyed() { }
        #endregion

        #region Functions
        /// <summary>
        /// Make sure you inherit this and do not use Awake(), and call base.OnAwake() first
        /// </summary>
        protected override void OnAwake()
        {
            if (this.IsControllable())
            {
                this.agent = GetComponent<NavMeshAgent>();
                this.aggroSphere = GetComponent<SphereCollider>();
                this.bt = new BehaviourTree(DESUtils.BehaviourTreeLocation, this);
                this.bt.Start();
                GameEvents.OnActionRequested.AddListener(ProcessCommand);
            }
            else
            {
                Destroy(GetComponent<NavMeshAgent>());
            }
        }

        private void Update()
        {
            if (this.IsControllable())
            {
                if (this.Target)
                {
                    this.agent.destination = this.Target.transform.position;
                }
                OnUpdate();
            }
        }

        private void OnDestroy()
        {
            if (this.IsControllable())
            {
                //Notify of death and give back sand
                GameEvents.OnUnitDestroyed.Invoke(this);
                GameEvents.OnCandyChanged.Invoke(-this.Info.CandyCost);
                GameEvents.OnActionRequested.RemoveListener(ProcessCommand);
            }

            OnDestroyed();
        }
        #endregion

        #region BehaviourTree
        /// <summary>
        /// Get the flag for the condition hasOrderFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("has-order")]
        public bool HasOrder() => this.HasOrderFlag;

        /// <summary>
        /// Get the flag for the condition isEnemySeenFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("enemy-seen")]
        public bool IsEnemySeen() => this.IsEnemySeenFlag;

        /// <summary>
        /// Get the flag for the condition isUnderAttackFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("under-attack")]
        public bool IsUnderAttack() => this.IsUnderAttackFlag;

        /// <summary>
        /// Routine for the followOrder leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("follow-order")]
        public BTCoroutine FollowOrderRoutine()
        {
            /*
             * !HasOrder()
             *       yield return BTNodeResult.Fail
             * HasOrder()
             *      yield return BTNodeResult.SUCCESS;
             * else
             *
             */

            yield return BTNodeResult.NOT_FINISHED;
        }

        /// <summary>
        /// Routine for the attack leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("attack")]
        public BTCoroutine AttackRoutine()
        {
            if (behaviourMode == Mode.ATTACK)
            {
                if (IsEnemySeen())
                {
                    agent.SetDestination(Target.Position);
                    if (agent.pathStatus == NavMeshPathStatus.PathComplete)
                    {
                        Attack(Target);
                        yield return BTNodeResult.NOT_FINISHED;
                    }
                }
            }

            if (behaviourMode == Mode.DEFEND)
            {
                if(IsUnderAttack())
                {
                    agent.SetDestination(Target.Position);
                    if (agent.pathStatus == NavMeshPathStatus.PathComplete)
                    {
                        Attack(Target);
                        yield return BTNodeResult.NOT_FINISHED;
                    }
                }
            }
            
            if(!IsEnemySeen())
            {
                /*if(Vector3.Distance(originalPos, this.transform.position) > this.aggroSphere.radius)
                {
                    agent.SetDestination(originalPos);
                }*/
            }

            if(IsUnderAttack())
            {
                Target = FindClosestTarget();
                agent.SetDestination(Target.Position);
                Attack(Target);
                yield return BTNodeResult.NOT_FINISHED;
            }
            
            
            
            /*
            *   move to closest enemy in aggro range
            *   attack unit
            *   yield return BTNodeResult.NOT_FINISHED;
            *
            *
            * if(behaviourMode == Mode.DEFEND)
            *
            * if(isUnderAttackFlag())
            *   agent.SetDestination(Target.position);
            *   Attack(Target);
            * 
            * 
            * store original position
            * received damage within last 2 seconds?
            *   move to attacking unit
            *   attack unit
            *   yield return BTNodeResult.NOT_FINISHED;
            *
            *
            *
            * 
            * If no enemy in aggro
            *
            *   if dist current to original pos > aggro range, return to original pos
            *      yield return BTNodeResult.SUCCESS;
            *
            *
            */

            yield return BTNodeResult.NOT_FINISHED;
        }

        /// <summary>
        /// Routine for the idle leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("idle")]
        public BTCoroutine WanderRoutine()
        {
            yield return BTNodeResult.SUCCESS;
        }
        #endregion
    }
}