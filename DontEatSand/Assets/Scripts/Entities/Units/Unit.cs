using System;
using System.Collections.Generic;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using DontEatSand.Utils.BehaviourTrees;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Unit AI mode
    /// </summary>
    public enum Mode
    {
        ATTACK,
        DEFEND
    }

    /// <summary>
    /// Unit base class
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public abstract class Unit : Entity, IComparable<Unit>
    {
        #region Constants
        /// <summary>
        /// Maximum position offset from the cluster
        /// </summary>
        private const float OFFSET_MAGNITUDE = 5f;
        /// <summary>
        /// Velocity animator parameter hash
        /// </summary>
        private static readonly int velocityParam = Animator.StringToHash("Velocity");
        /// <summary>
        /// Animator attack trigger name
        /// </summary>
        protected int attackTriggerName = Animator.StringToHash("Attacking");
        #endregion

        #region Fields
        [SerializeField]
        private Image healthbar;
        [SerializeField]
        private Gradient healthGradient;
        [SerializeField]
        protected float attackRange = 1f;
        [SerializeField]
        private Renderer bodyRenderer;
        [SerializeField]
        private int[] tintIndices;
        public Mode behaviourMode;
        protected NavMeshAgent agent;
        protected Animator animator;
        protected BehaviourTree bt;
        private float smoothSpeed;
        private float healthPercent = 1f;
        protected readonly HashSet<Unit> enemyUnitsInRange = new HashSet<Unit>();
        protected float attackStart;
        protected float attackInterval = 1.0f;

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
        public bool HasOrderFlag { get; set; }

        /// <summary>
        /// Flag dictating if an enemy is within the aggro range
        /// </summary>
        public bool IsEnemySeenFlag
        {
            get
            {
                return this.enemyUnitsInRange.Count != 0;
            }
            set
            {

            }
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

        /// <summary>
        /// If the unit can currently attack
        /// </summary>
        public virtual bool CanAttack
        {
            get
            {
                bool attackReady = false;
                if(Time.time > this.attackStart + this.attackInterval)
                {
                    this.attackStart = Time.time;
                    attackReady = true;
                }
                return attackReady && this.Target != null && Vector3.Distance(this.Position, this.Target.Position) < this.attackRange;
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

            Vector3 positionDiff = this.transform.position - averagePosition;
            if (positionDiff.magnitude > OFFSET_MAGNITUDE)
            {
                positionDiff = Vector3.zero;
            }

            this.Destination = dest + positionDiff;
        }

        /// <inheritdoc cref="IComparable{T}.CompareTo"/>
        public int CompareTo(Unit other)
        {
            int c = this.Info.Type.CompareTo(other.Info.Type);
            if (c == 0)
            {
                c = StringComparer.InvariantCulture.Compare(this.EntityName, other.EntityName);
                if (c == 0)
                {
                    c = other.Health.CompareTo(this.Health);
                    return c == 0 ? GetInstanceID().CompareTo(other.GetInstanceID()) : c;
                }
            }

            return c;
        }

        /// <summary>
        /// Find the closest enemy unit to this unit
        /// </summary>
        /// <returns></returns>
        protected Unit FindClosestTarget()
        {
            int size = this.enemyUnitsInRange.Count;
            if (size == 0) return null;

            //Get closest target
            Unit closestTarget = null;
            Vector3 position = this.transform.position;
            float distanceToClosest = float.PositiveInfinity;
            foreach (Unit enemy in this.enemyUnitsInRange)
            {
                float dist = Vector3.Distance(enemy.Position, position);
                //Making sure it's a valid entity target
                if(dist < distanceToClosest) // && (!PhotonNetwork.IsConnected || !entity.photonView.IsMine))
                {
                    distanceToClosest = dist;
                    closestTarget = enemy;
                }
            }

            //Return it's entity
            return closestTarget;
        }
        #endregion

        #region Virtual methods
        /// <summary>
        /// Attacks the specified target
        /// </summary>
        /// <param name="target">Target to attack</param>
        public virtual void Attack(Entity target)
        {
            // Set animator trigger for attacking
            this.animator.SetTrigger(this.attackTriggerName);
        }

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
        protected virtual void OnUpdate()
        {
            if(this.Target == null && Vector3.Distance(this.Position, agent.destination) < 0.5f)
            {
                // no target and arrived to player-commanded destination
                HasOrderFlag = false;
            }
        }

        /// <summary>
        /// OnDestroy function, use this instead of OnDestroy()
        /// </summary>
        protected virtual void OnDestroyed() { }
        #endregion

        #region Collider Functions
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.isTrigger) { return; }

            if(collider.transform.parent.TryGetComponent(out Unit enemyUnit)) // && !enemyUnit.IsControllable())
            {
                // Populate enemies
                this.enemyUnitsInRange.Add(enemyUnit);
            }

        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.isTrigger) { return; }

            if(collider.transform.parent.TryGetComponent(out Unit enemyUnit) && this.enemyUnitsInRange.Contains(enemyUnit))
            {
                this.enemyUnitsInRange.Remove(enemyUnit);
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Make sure you inherit this and do not use Awake(), and call base.OnAwake() first
        /// </summary>
        protected override void OnAwake()
        {
            this.healthbar.gameObject.SetActive(false);
            Material team = this.IsControllable() ? GameLogic.Instance.PlayerMaterial : GameLogic.Instance.OpponentMaterial;
            Material[] materials = this.bodyRenderer.materials;
            foreach (int index in this.tintIndices)
            {
                materials[index] = team;
            }
            this.bodyRenderer.materials = materials;
            this.animator = GetComponent<Animator>();
            this.agent = GetComponent<NavMeshAgent>();

            if (this.IsControllable())
            {
                this.agent.stoppingDistance = this.attackRange * 0.6f;
                this.behaviourMode = Mode.DEFEND;
                this.bt = new BehaviourTree(DESUtils.BehaviourTreeLocation, this);
                this.bt.Start();
                GameEvents.OnActionRequested.AddListener(ProcessCommand);
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
            this.healthPercent = Mathf.SmoothDamp(this.healthPercent, this.HealthAmount, ref this.smoothSpeed, 0.2f);
            this.healthbar.fillAmount = this.healthPercent;
            if (this.healthbar.gameObject.activeInHierarchy)
            {
                this.healthbar.color = this.healthGradient.Evaluate(this.healthPercent);
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

            if(this.HasOrderFlag)
            {
                yield return BTNodeResult.SUCCESS;
            }
            else
            {
                yield return BTNodeResult.FAILURE;
            }

            // yield return BTNodeResult.NOT_FINISHED;
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
                    this.Target = FindClosestTarget();
                    if (this.Target)
                    {
                        this.agent.SetDestination(this.Target.Position);
                        if (this.CanAttack)
                        {
                            Attack(this.Target);
                            yield return BTNodeResult.NOT_FINISHED;
                        }
                    }
                    else
                    {
                        //Do we need to do something here? Can this happen at all?
                    }
                }
            }

            if (this.behaviourMode == Mode.DEFEND)
            {
                if(IsUnderAttack())
                {
                    this.Target = FindClosestTarget();
                    //NOTE: This was throwing when out of targets, so I'm guessing this is the way to handle it
                    if (this.Target)
                    {
                        this.agent.SetDestination(this.Target.Position);
                        if (this.CanAttack)
                        {
                            Attack(this.Target);
                            yield return BTNodeResult.NOT_FINISHED;
                        }
                    }
                    else
                    {
                        this.behaviourMode = Mode.DEFEND;
                    }
                }
                // should return to original position if wanders too far off
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