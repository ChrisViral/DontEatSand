using System;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviourTrees
{
    public class BTLeafNode : BTNode
    {
        #region Fields
        private readonly Func<BTCoroutine> actionFunc;
        #endregion

        #region Constructors
        public BTLeafNode(Func<BTCoroutine> actionFunc) => this.actionFunc = actionFunc;
        #endregion

        #region Methods
        public override BTCoroutine Procedure()
        {
            return this.actionFunc();
        }
        #endregion
    }
}