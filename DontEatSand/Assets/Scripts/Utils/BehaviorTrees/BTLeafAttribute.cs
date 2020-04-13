using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class BTLeafAttribute : Attribute
{
    public string LeafName { get; private set; }

    public BTLeafAttribute(string leafName)
    {
        LeafName = leafName;
    }
}
