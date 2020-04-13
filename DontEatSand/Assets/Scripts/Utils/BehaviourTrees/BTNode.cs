using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviourTrees
{
    public abstract class BTNode
    {
        #region Abstract methods
        public abstract BTCoroutine Procedure();
        #endregion
    }
}
