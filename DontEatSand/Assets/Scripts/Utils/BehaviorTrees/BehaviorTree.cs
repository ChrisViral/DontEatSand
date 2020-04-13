using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public sealed class BehaviorTree
{
    private BTNode rootNode;
    private MonoBehaviour parent;
    private UnityEngine.Coroutine coroutineHandle;

    public BehaviorTree(BTNode rootNode, MonoBehaviour parent)
    {
        this.rootNode = rootNode;
        this.parent = parent;
    }

    public BehaviorTree(string xmlPath, MonoBehaviour parent)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
        settings.ConformanceLevel = ConformanceLevel.Fragment;
        settings.ValidationType = ValidationType.None;

        this.parent = parent;

        using(XmlReader reader = XmlReader.Create(xmlPath, settings))
        {
            XDocument doc = XDocument.Load(reader);

            if (doc.Root.Name.ToString().ToLowerInvariant() != "behavior-tree")
                throw new XmlException("Behavior tree root node not found");

            if (doc.Root.Elements().Count() == 0)
                throw new XmlException("The behavior tree is empty!");

            if (doc.Root.Elements().Count() > 1)
                throw new XmlException("The behavior tree must have only one node at the top level");

            Dictionary<string, MethodInfo> leaves, conditions;

            LoadParentLeafFunctions(out leaves, out conditions);

            this.rootNode = ParseXmlElement(doc.Root.Elements().First(), leaves, conditions);
        }
    }

    public void Start()
    {
        this.coroutineHandle = parent.StartCoroutine(BehaviorCoroutine());
    }

    public void Stop()
    {
        parent.StopCoroutine(coroutineHandle);
    }

    private Coroutine BehaviorCoroutine()
    {
        while (true)
        {
            BTCoroutine btRoutine = rootNode.Procedure();

            while (btRoutine.MoveNext())
                yield return new WaitForFixedUpdate();
        }
    }

    private void LoadParentLeafFunctions(
        out Dictionary<string, MethodInfo> leaves,
        out Dictionary<string, MethodInfo> conditions)
    {
        leaves = new Dictionary<string, MethodInfo>();
        conditions = new Dictionary<string, MethodInfo>();

        Type parentType = parent.GetType();

        MethodInfo[] allMethods = parentType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        foreach (MethodInfo method in allMethods)
        {
            object[] custAttrs = method.GetCustomAttributes(typeof(BTLeafAttribute), false);
            if (custAttrs == null || custAttrs.Length == 0)
                continue;

            BTLeafAttribute leafAttr = (BTLeafAttribute)custAttrs[0];

            if(method.GetParameters().Length > 0)
                throw new ArgumentException("Method '" + method.Name + "' cannot have parameters if it is marked as a leaf function");

            string key = leafAttr.LeafName.Trim().ToLowerInvariant();

            if (method.ReturnType == typeof(bool)) //condition
            {
                if (conditions.ContainsKey(key))
                    throw new ArgumentException("Duplicate condition name: '" + key + "'");

                conditions[key] = method;
            }
            else if (method.ReturnType == typeof(BTCoroutine)) //leaf
            {
                if (leaves.ContainsKey(key))
                    throw new ArgumentException("Duplicate leaf name: '" + key + "'");

                leaves[key] = method;
            }
            else
            {
                throw new ArgumentException("Method '" + method.Name + "' must return either bool or BTCoroutine");
            }
        }
    }

    private BTNode ParseXmlElement(XElement element, 
        Dictionary<string, MethodInfo> leafFunctions,
        Dictionary<string, MethodInfo> conditionFunctions)
    {
        XElement[] children = (element.Elements() ?? new XElement[0]).ToArray();

        string nodeType = element.Name.ToString().ToLowerInvariant();
        XAttribute nameAttr = null;
        string name = null;

        switch (nodeType)
        {
            case "not":
                if (children.Length == 0)
                    throw new XmlException("The 'not' element must have one child");
                if (children.Length > 1)
                    throw new XmlException("The 'not' element must only have one child");

                return new BTNotNode(ParseXmlElement(children[0], leafFunctions, conditionFunctions));

            case "sequence":
                if (children.Length == 0)
                    throw new XmlException("The 'sequence' element must have children");

                return new BTSequence(children.Select(elem => ParseXmlElement(elem, leafFunctions, conditionFunctions)));

            case "selector":
                if (children.Length == 0)
                    throw new XmlException("The 'selector' element must have children");

                return new BTSelector(children.Select(elem => ParseXmlElement(elem, leafFunctions, conditionFunctions)));

            case "condition":
                if (children.Length > 0)
                    throw new XmlException("The 'condition' element cannot have children");

                nameAttr = element.Attribute("name");

                if (nameAttr == null)
                    throw new XmlException("Missing 'name' attribute for 'condition' element");

                name = (nameAttr.Value ?? "").Trim().ToLowerInvariant();

                if (string.IsNullOrEmpty(name))
                    throw new XmlException("The'name' attribute for the 'condition' element was not given a value");

                if (!conditionFunctions.ContainsKey(name))
                    throw new XmlException("Condition not found: '" + name + "'");

                return new BTConditionNode(() => (bool)conditionFunctions[name].Invoke(parent, null));


            case "leaf":
                if (children.Length > 0)
                    throw new XmlException("The 'leaf' element cannot have children");

                nameAttr = element.Attribute("name");

                if (nameAttr == null || nameAttr.Value == null)
                    throw new XmlException("Missing 'name' attribute for 'leaf' element");

                name = (nameAttr.Value ?? "").Trim().ToLowerInvariant();

                if (string.IsNullOrEmpty(name))
                    throw new XmlException("The'name' attribute for the 'leaf' element was not given a value");

                if (!leafFunctions.ContainsKey(name))
                    throw new XmlException("Leaf not found: '" + name + "'");

                return new BTLeafNode(() => (BTCoroutine)leafFunctions[name].Invoke(parent, null));

            default:
                throw new XmlException("Unknown behavior tree node type: '" + nodeType);

        }
    }
	
}
