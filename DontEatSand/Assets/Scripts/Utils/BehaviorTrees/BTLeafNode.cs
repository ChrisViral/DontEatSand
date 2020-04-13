using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public class BTLeafNode : BTNode
{
    private Func<BTCoroutine> actionFunc;

    public BTLeafNode(Func<BTCoroutine> actionFunc)
    {
        this.actionFunc = actionFunc;
    }

    public override BTCoroutine Procedure()
    {
        return actionFunc();
    }
}
