// <copyright file="BaseNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Jack Wharton
// 11506329
// CptS 321

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Abstract class representing a node of the Expression tree
    /// </summary>
    internal abstract class BaseNode
    {
        /// <summary>
        /// Abstract evaluate method.
        /// Every subnode class must implement evaluation functionality
        /// </summary>
        /// <param name="variables">Variable dictionary</param>
        /// <returns>Value of the node</returns>
        public abstract double Evaluate(ref Dictionary<string, double> variables);
    }
}
