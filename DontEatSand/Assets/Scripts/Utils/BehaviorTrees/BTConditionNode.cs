using System;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviorTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviorTrees
{
    public class BTConditionNode : BTNode
    {
        #region Fields
        private readonly Func<bool> condition;
        #endregion

        #region Constructors
        public BTConditionNode(Func<bool> condition) => this.condition = condition;
        #endregion

        #region Methods
        public override BTCoroutine Procedure()
        {
            yield return this.condition() ? BTNodeResult.SUCCESS : BTNodeResult.FAILURE;
        }
        #endregion
    }
}