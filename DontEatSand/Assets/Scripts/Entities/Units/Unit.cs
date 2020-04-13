using UnityEngine;
using UnityEngine.AI;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Unit base class
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
    public class Unit : Entity
    {
        #region Constants
        private const float OFFSET_MAGNITUDE = 5f;
        #endregion

        #region Fields
        private NavMeshAgent agent;

        private BehaviorTree bt;
        #endregion

        #region Properties
        /// <summary>
        /// Current target of this unit
        /// </summary>
        public Transform Target { get; set; }

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
        public bool hasOrderFlag { get; set; }

        /// <summary>
        /// Flag dictating if an enemy is within the aggro range
        /// </summary>
        public bool isEnemySeenFlag { get; set; }

        /// <summary>
        /// Flag dictating if the enemy is under attack
        /// </summary>
        public bool isUnderAttackFlag { get; set; }
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
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            this.agent = GetComponent<NavMeshAgent>();

            InitBT();
            bt.Start();
        }

        private void Update()
        {
            if (this.Target)
            {
                this.agent.destination = this.Target.position;
            }
        }

        private void OnDestroy()
        {
            //Notify of death and give back sand
            GameEvents.OnUnitDestroyed.Invoke(this);
            GameEvents.OnCandyChanged.Invoke(-this.Info.CandyCost);
        }
        #endregion

        #region BehaviourTree
        /// <summary>
        /// Get the behaviour tree from the xml file
        /// </summary>
        private void InitBT()
        {
            bt = new BehaviorTree(Application.dataPath + "/Script/unit-behavior.xml", this);
        }

        /// <summary>
        /// Get the flag for the condition hasOrderFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("has-order")]
        public bool hasOrder()
        {
            return hasOrderFlag;
        }

        /// <summary>
        /// Get the flag for the condition isEnemySeenFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("enemy-seen")]
        public bool isEnemySeen()
        {
            return isEnemySeenFlag;
        }

        /// <summary>
        /// Get the flag for the condition isUnderAttackFlag
        /// </summary>
        /// <returns></returns>
        [BTLeaf("under-attack")]
        public bool isUnderAttack()
        {
            return isUnderAttackFlag;
        }

        /// <summary>
        /// Routine for the followOrder leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("follow-order")]
        public BTCoroutine followOrderRoutine()
        {
            /*
            * !isOrderCommanded
            *       yield return BTNodeResult.Fail
            * isOrderFinished
            *      yield return BTNodeResult.Success;
            * else
            *      
            */

            yield return BTNodeResult.NotFinished;
        }

        /// <summary>
        /// Routine for the attack leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("attack")]
        public BTCoroutine attackRoutine()
        {
            /*
            * isAttackMode
            * 
            * enemy in aggro?
            *   move to closest enemy in aggro range
            *   attack unit 
            *   yield return BTNodeResult.NotFinished;
            * 
            * 
            * isDefenseMode
            * 
            * store original position
            * received damage within last 2 seconds?
            *   move to attacking unit
            *   attack unit
            *   yield return BTNodeResult.NotFinished;
            * 
            * 
            * If no enemy in aggro
            * 
            *   if dist current to original pos > aggro range, return to original pos
            *      yield return BTNodeResult.Success;
            * 
            *      
            */

            yield return BTNodeResult.NotFinished;
        }

        /// <summary>
        /// Routine for the idle leaf
        /// </summary>
        /// <returns></returns>
        [BTLeaf("idle")]
        public BTCoroutine WanderRoutine()
        {
            yield return BTNodeResult.Success;
        }
        #endregion
    }
}