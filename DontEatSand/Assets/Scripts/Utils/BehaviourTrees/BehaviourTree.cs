using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using BTCoroutine = System.Collections.Generic.IEnumerator<DontEatSand.Utils.BehaviourTrees.BTNodeResult>;

namespace DontEatSand.Utils.BehaviourTrees
{
    public enum BTNodeResult
    {
        NOT_FINISHED,
        SUCCESS,
        FAILURE
    }

    public sealed class BehaviourTree
    {
        #region Constants
        private static readonly Type LeafAttributeType = typeof(BTLeafAttribute);
        private static readonly Type BoolType = typeof(bool);
        private static readonly Type CoroutineType = typeof(BTCoroutine);
        private static readonly XmlReaderSettings XMLSettings = new XmlReaderSettings
        {
            IgnoreComments = true,
            ConformanceLevel = ConformanceLevel.Fragment,
            ValidationType = ValidationType.None
        };
        #endregion

        #region Fields
        private readonly BTNode rootNode;
        private readonly MonoBehaviour parent;
        private Coroutine coroutineHandle;
        #endregion

        #region Constructors
        public BehaviourTree(BTNode rootNode, MonoBehaviour parent)
        {
            this.rootNode = rootNode;
            this.parent = parent;
        }

        public BehaviourTree(string xmlPath, MonoBehaviour parent)
        {
            this.parent = parent;
            using (XmlReader reader = XmlReader.Create(xmlPath, XMLSettings))
            {
                XDocument doc = XDocument.Load(reader);
                if (doc.Root?.Name.ToString().ToLowerInvariant() != "behaviour-tree") throw new XmlException("Behaviour tree root node not found");

                XElement[] rootElements = doc.Root.Elements().ToArray();
                if (rootElements.Length == 0) throw new XmlException("The behaviour tree is empty!");
                if (rootElements.Length > 1) throw new XmlException("The behaviour tree must have only one node at the top level");

                LoadParentLeafFunctions(out Dictionary<string, MethodInfo> leaves, out Dictionary<string, MethodInfo> conditions);
                this.rootNode = ParseXmlElement(rootElements[0], leaves, conditions);
            }
        }
        #endregion

        #region Methods
        public void Start() => this.coroutineHandle = this.parent.StartCoroutine(BehaviourCoroutine());

        public void Stop() => this.parent.StopCoroutine(this.coroutineHandle);

        private IEnumerator<YieldInstruction> BehaviourCoroutine()
        {
            while (true)
            {
                BTCoroutine btRoutine = this.rootNode.Procedure();

                while (btRoutine.MoveNext())
                {
                    yield return new WaitForFixedUpdate();
                }
            }
        }

        private void LoadParentLeafFunctions(out Dictionary<string, MethodInfo> leaves, out Dictionary<string, MethodInfo> conditions)
        {
            leaves = new Dictionary<string, MethodInfo>();
            conditions = new Dictionary<string, MethodInfo>();

            Type parentType = this.parent.GetType();
            MethodInfo[] allMethods = parentType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (MethodInfo method in allMethods)
            {
                object[] customAttributes = method.GetCustomAttributes(LeafAttributeType, false);
                if (customAttributes.Length == 0) continue;

                BTLeafAttribute leafAttr = (BTLeafAttribute)customAttributes[0];
                if (method.GetParameters().Length > 0) throw new ArgumentException($"Method '{method.Name}' cannot have parameters if it is marked as a leaf function");

                string key = leafAttr.LeafName.Trim().ToLowerInvariant();
                if (method.ReturnType == BoolType) //Condition
                {
                    if (conditions.ContainsKey(key)) throw new ArgumentException($"Duplicate condition name: '{key}'");

                    conditions[key] = method;
                }
                else if (method.ReturnType == CoroutineType) //Leaf
                {
                    if (leaves.ContainsKey(key)) throw new ArgumentException($"Duplicate leaf name: '{key}'");

                    leaves[key] = method;
                }
                else throw new ArgumentException($"Method '{method.Name}' must return either bool or BTCoroutine");
            }
        }

        private BTNode ParseXmlElement(XElement element, Dictionary<string, MethodInfo> leafFunctions, Dictionary<string, MethodInfo> conditionFunctions)
        {
            XElement[] children = element.Elements().ToArray();

            string nodeType = element.Name.ToString().ToLowerInvariant();
            XAttribute nameAttr;
            string name;

            switch (nodeType)
            {
                case "not":
                    if (children.Length == 0) throw new XmlException("The 'not' element must have one child");
                    if (children.Length > 1) throw new XmlException("The 'not' element must only have one child");

                    return new BTNotNode(ParseXmlElement(children[0], leafFunctions, conditionFunctions));

                case "sequence":
                    if (children.Length == 0) throw new XmlException("The 'sequence' element must have children");

                    return new BTSequence(children.Select(elem => ParseXmlElement(elem, leafFunctions, conditionFunctions)));

                case "selector":
                    if (children.Length == 0) throw new XmlException("The 'selector' element must have children");

                    return new BTSelector(children.Select(elem => ParseXmlElement(elem, leafFunctions, conditionFunctions)));

                case "condition":
                    if (children.Length > 0) throw new XmlException("The 'condition' element cannot have children");

                    nameAttr = element.Attribute("name");
                    if (nameAttr == null) throw new XmlException("Missing 'name' attribute for 'condition' element");

                    name = nameAttr.Value.Trim().ToLowerInvariant();
                    if (string.IsNullOrEmpty(name)) throw new XmlException("The 'name' attribute for the 'condition' element was not given a value");
                    if (!conditionFunctions.ContainsKey(name)) throw new XmlException($"Condition not found: '{name}'");

                    return new BTConditionNode(() => (bool)conditionFunctions[name].Invoke(this.parent, null));


                case "leaf":
                    if (children.Length > 0) throw new XmlException("The 'leaf' element cannot have children");

                    nameAttr = element.Attribute("name");
                    if (nameAttr?.Value == null) throw new XmlException("Missing 'name' attribute for 'leaf' element");

                    name = nameAttr.Value.Trim().ToLowerInvariant();
                    if (string.IsNullOrEmpty(name)) throw new XmlException("The 'name' attribute for the 'leaf' element was not given a value");
                    if (!leafFunctions.ContainsKey(name)) throw new XmlException($"Leaf not found: '{name}'");

                    return new BTLeafNode(() => (BTCoroutine)leafFunctions[name].Invoke(this.parent, null));

                default:
                    throw new XmlException($"Unknown behaviour tree node type: '{nodeType}");

            }
        }
        #endregion
    }
}