using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public class BTConditionNode : BTNode 
{
    private Func<bool> condition;

    public BTConditionNode(Func<bool> condition)
    {
        this.condition = condition;
    }

    public override BTCoroutine Procedure()
    {
        yield return condition() ? BTNodeResult.Success : BTNodeResult.Failure;
    }
}
