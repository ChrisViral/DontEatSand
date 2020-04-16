using System;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using DontEatSand.Utils.BehaviourTrees;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Unit base class
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public abstract class Unit : Entity, IComparable<Unit>
    {
        /// <summary>
        /// Unit AI mode
        /// </summary>
        public enum Mode
        {
            ATTACK,
            DEFEND
        }

        #region Constants
        /// <summary>
        /// Maximum position offset from the cluster
        /// </summary>
        private const float OFFSET_MAGNITUDE = 5f;
        /// <summary>
        /// Overlap sphere hit buffer
        /// </summary>
        private static readonly Collider[] hits = new Collider[128];
        /// <summary>
        /// Velocity animator parameter hash
        /// </summary>
        private static readonly int velocityParam = Animator.StringToHash("Velocity");
        #endregion

        #region Fields
        [SerializeField]
        private Image healthbar;
        public Mode behaviourMode;
        protected NavMeshAgent agent;
        protected Animator animator;
        private BehaviourTree bt;
        private SphereCollider aggroSphere;
        private LayerMask unitsMask;
        private float smoothSpeed;
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
            //Can't be setting to the property and returning an expression
            //get => this.agent.pathStatus != NavMeshPathStatus.PathComplete;
            get;
            set;
        }

        /// <summary>
        /// Flag dictating if an enemy is within the aggro range
        /// </summary>
        public bool IsEnemySeenFlag
        {
            get; set;
            /*{
                return aggroSphere.bounds.Contains(Target.transform.position);
            }*/
        }

        /// <summary>
        /// Flag dictating if the enemy is attacking this unit
        /// </summary>
        public bool IsUnderAttackFlag { get; set; } //needs to be set

        /// <summary>
        /// If the unit is currently selected or not
        /// </summary>
        public override bool IsSelected
        {
            get => base.IsSelected;
            set
            {
                base.IsSelected = value;
                //Change activation of healthbar if not hovered or selected
                if (!this.IsHovered)
                {
                    this.healthbar.gameObject.SetActive(value);
                }
            }
        }

        /// <summary>
        /// If the unit is currently hovered or not
        /// </summary>
        public override bool IsHovered
        {
            get => base.IsHovered;
            set
            {
                base.IsHovered = value;
                //Change activation of healthbar if not hovered or selected
                if (!this.IsSelected)
                {
                    this.healthbar.gameObject.SetActive(value);
                }
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
            this.HasOrderFlag = true;

            Vector3 positionDiff = this.transform.position - averagePosition;
            if (positionDiff.magnitude > OFFSET_MAGNITUDE)
            {
                positionDiff = Vector3.zero;
                this.HasOrderFlag = false;
            }

            this.Destination = dest + positionDiff;
        }

        /// <inheritdoc cref="IComparable{T}.CompareTo"/>
        public int CompareTo(Unit other)
        {
            int c = this.Info.Type.CompareTo(other.Info.Type);
            return c == 0 ? StringComparer.InvariantCulture.Compare(this.EntityName, other.EntityName) : c;
        }

        /// <summary>
        /// Attacks the specified target
        /// </summary>
        /// <param name="target">Target to attack</param>
        public virtual void Attack(Entity target)
        {
            //Do the animator thingy
        }

        /// <summary>
        /// Find the closest target to this unit
        /// </summary>
        /// <returns></returns>
        private Entity FindClosestTarget()
        {
            //Use non allocating, check up to 128 possible targets
            //NOTE: You really don't want to be doing this, it'd be much better to instead just keep track of who is in range using OnTriggerEnter/Exit
            int size = Physics.OverlapSphereNonAlloc(this.transform.position, this.aggroSphere.radius, hits, this.unitsMask, QueryTriggerInteraction.Ignore);
            if (size == 0) return null;

            //Get closest target
            Entity closestTarget = null;
            Vector3 position = this.transform.position;
            float distanceToClosest = float.PositiveInfinity;
            for (int i = 0; i < size; i++)
            {
                Collider hit = hits[i];
                float dist = Vector3.Distance(hit.transform.position, position);
                //Making sure it's a valid entity target
                if(dist < distanceToClosest && hit.gameObject.TryGetComponent(out Entity entity) && (!PhotonNetwork.IsConnected || !entity.photonView.IsMine))
                {
                    distanceToClosest = dist;
                    closestTarget = entity;
                }
            }

            //Return it's entity
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
            this.healthbar.gameObject.SetActive(false);
            if (this.IsControllable())
            {
                this.agent = GetComponent<NavMeshAgent>();
                this.animator = GetComponent<Animator>();
                this.aggroSphere = GetComponent<SphereCollider>();
                this.unitsMask = LayerUtils.GetMask(Layers.VISIBLE_UNIT);
                this.behaviourMode = Mode.DEFEND;
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

            //Send velocity to animator
            this.animator.SetFloat(velocityParam, this.agent.velocity.magnitude);
            //Set healthbar
            if (this.healthbar.gameObject.activeInHierarchy)
            {
                this.healthbar.fillAmount = Mathf.SmoothDamp(this.healthbar.fillAmount, this.HealthAmount, ref this.smoothSpeed, 0.2f);
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
            if (this.behaviourMode == Mode.ATTACK)
            {
                if (IsEnemySeen())
                {
                    this.agent.SetDestination(this.Target.Position);
                    if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
                    {
                        Attack(this.Target);
                        yield return BTNodeResult.NOT_FINISHED;
                    }
                }
            }

            if (this.behaviourMode == Mode.DEFEND)
            {
                if(IsUnderAttack())
                {
                    this.agent.SetDestination(this.Target.Position);
                    if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
                    {
                        Attack(this.Target);
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
                this.Target = FindClosestTarget();
                this.agent.SetDestination(this.Target.Position);
                Attack(this.Target);
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