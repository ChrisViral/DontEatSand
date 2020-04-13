using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public class BTNotNode : BTNode
{
    private BTNode childNode;

    public BTNotNode(BTNode childNode)
    {
        this.childNode = childNode;
    }

    public override BTCoroutine Procedure()
    {
        BTCoroutine routine = childNode.Procedure();

        while (routine.MoveNext())
        {
            BTNodeResult result = routine.Current;

            if (result == BTNodeResult.NotFinished)
                yield return BTNodeResult.NotFinished;
            else
            {
                yield return result == BTNodeResult.Failure ? BTNodeResult.Success : BTNodeResult.Failure;
                yield break;
            }
        }
    }
}
