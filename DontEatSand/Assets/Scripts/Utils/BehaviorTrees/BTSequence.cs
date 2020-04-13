using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public class BTSequence : BTNode
{
    private BTNode[] subNodes;

    public BTSequence(IEnumerable<BTNode> subNodes)
    {
        this.subNodes = subNodes.ToArray();
    }

    public BTSequence(params BTNode[] subNodes)
    {
        this.subNodes = subNodes;
    }

    public override BTCoroutine Procedure()
    {
        foreach (BTNode node in subNodes)
        {
            BTCoroutine routine = node.Procedure();

            while (routine.MoveNext())
            {
                BTNodeResult result = routine.Current;

                if (result == BTNodeResult.Failure)
                {
                    yield return BTNodeResult.Failure;
                    yield break;
                }
                else //success
                {
                    yield return BTNodeResult.NotFinished;

                    if (result == BTNodeResult.Success)
                        break;
                }
            }
        }

        yield return BTNodeResult.Success;
    }
}
