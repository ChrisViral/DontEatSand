using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviourTrees
{
    public class BTNotNode : BTNode
    {
        #region Fields
        private readonly BTNode childNode;
        #endregion

        #region Constructors
        public BTNotNode(BTNode childNode) => this.childNode = childNode;
        #endregion

        #region Methods
        public override BTCoroutine Procedure()
        {
            BTCoroutine routine = this.childNode.Procedure();

            while (routine.MoveNext())
            {
                BTNodeResult result = routine.Current;

                if (result == BTNodeResult.NOT_FINISHED)
                {
                    yield return BTNodeResult.NOT_FINISHED;
                }
                else
                {
                    yield return result == BTNodeResult.FAILURE ? BTNodeResult.SUCCESS : BTNodeResult.FAILURE;
                    yield break;
                }
            }
        }
        #endregion
    }
}