// <copyright file="VariableNode.cs" company="PlaceholderCompany">
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
    /// Expression tree node representing a variable
    /// </summary>
    internal class VariableNode : BaseNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="newName">Name of variable</param>
        public VariableNode(string newName)
        {
            this.Name = newName;
        }

        /// <summary>
        /// Gets or sets the name property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Evaluates the value of the node, using the variables dictionary parameter
        /// </summary>
        /// <param name="variables">Dictionary of variables and their corresponding values</param>
        /// <returns>The value of the variable</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return variables[this.Name];
        }
    }
}
