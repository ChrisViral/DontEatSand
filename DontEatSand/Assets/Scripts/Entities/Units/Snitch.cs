using UnityEngine;
using System.Collections.Generic;
using DontEatSand.Utils.BehaviourTrees;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;


namespace DontEatSand.Entities.Units
{
    public class Snitch : Unit
    {

        #region Methods

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

            // Scout runs faster than everyone else
            this.Agent.speed += this.Agent.speed * 0.2f;
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
