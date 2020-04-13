﻿using System;

namespace DontEatSand.Utils.BehaviorTrees
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class BTLeafAttribute : Attribute
    {
        #region Properties
        public string LeafName { get; }
        #endregion

        #region Constructors
        public BTLeafAttribute(string leafName) => this.LeafName = leafName;
        #endregion
    }
}