using System.Collections.Generic;
using System.Linq;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviorTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviorTrees
{
    public class BTSelector : BTNode
    {
        #region Fields
        private readonly BTNode[] subNodes;
        #endregion

        #region Constructors
        public BTSelector(params BTNode[] subNodes) => this.subNodes = subNodes;

        public BTSelector(IEnumerable<BTNode> subNodes) : this(subNodes.ToArray()) { }
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

                    if (result == BTNodeResult.SUCCESS)
                    {
                        yield return BTNodeResult.SUCCESS;
                        yield break;
                    }

                    yield return BTNodeResult.NOT_FINISHED;
                    if (result == BTNodeResult.FAILURE) break;
                }
            }

            yield return BTNodeResult.FAILURE;
        }
        #endregion
    }
}