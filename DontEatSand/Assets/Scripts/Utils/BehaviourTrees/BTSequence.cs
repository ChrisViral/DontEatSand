using System.Collections.Generic;
using System.Linq;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviourTrees
{
    public class BTSequence : BTNode
    {
        #region Fields
        private readonly BTNode[] subNodes;
        #endregion

        #region Constructors
        public BTSequence(params BTNode[] subNodes) => this.subNodes = subNodes;

        public BTSequence(IEnumerable<BTNode> subNodes) : this(subNodes.ToArray()) { }
        #endregion

        #region Methods
        public override BTCoroutine Procedure()
        {
            foreach (BTNode node in this.subNodes)
            {
                BTCoroutine routine = node.Procedure();

                while (routine.MoveNext())
                {
                    BTNodeResult result = routine.Current;

                    if (result == BTNodeResult.FAILURE)
                    {
                        yield return BTNodeResult.FAILURE;

                        yield break;
                    }
                    //Success
                    yield return BTNodeResult.NOT_FINISHED;
                    if (result == BTNodeResult.SUCCESS) break;
                }
            }
            yield return BTNodeResult.SUCCESS;
        }
        #endregion
    }
}