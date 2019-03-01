// <copyright file="ConstantNode.cs" company="PlaceholderCompany">
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
    /// Expression tree node representing a constant
    /// </summary>
    internal class ConstantNode : BaseNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">Constant value of the node</param>
        public ConstantNode(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value property
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Returns the value of the node
        /// </summary>
        /// <param name="variables">Variable dictionary</param>
        /// <returns>Value of node</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Value;
        }
    }
}
