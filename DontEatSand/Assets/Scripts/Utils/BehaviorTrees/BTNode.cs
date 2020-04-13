using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviorTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviorTrees
{
    public abstract class BTNode
    {
        #region Abstract methods
        public abstract BTCoroutine Procedure();
        #endregion
    }
}
