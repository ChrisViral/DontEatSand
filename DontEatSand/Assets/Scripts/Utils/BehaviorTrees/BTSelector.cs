using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public class BTSelector : BTNode
{
    private BTNode[] subNodes;

    public BTSelector(IEnumerable<BTNode> subNodes)
    {
        this.subNodes = subNodes.ToArray();
    }

    public BTSelector(params BTNode[] subNodes)
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

                if (result == BTNodeResult.Success)
                {
                    yield return BTNodeResult.Success;
                    yield break;
                }
                else
                {
                    yield return BTNodeResult.NotFinished; 
                    
                    if (result == BTNodeResult.Failure)
                        break;
                }
            }
        }

        yield return BTNodeResult.Failure;
    }
}