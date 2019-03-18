// <copyright file="AddOperatorNode.cs" company="PlaceholderCompany">
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
    /// Operator node with implementation for the Add operation
    /// Derived from BaseOperatorNode
    /// </summary>
    internal class AddOperatorNode : BaseOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddOperatorNode"/> class.
        /// </summary>
        /// <param name="c">Operator symbol</param>
        public AddOperatorNode(char c)
        {
            this.Operator = c;
            this.Left = this.Right = null;
            this.precedence = 1;
        }

        /// <summary>
        /// Evaluates the node value by adding the values of the left node and the right node
        /// </summary>
        /// <param name="variables">Variable dictionary</param>
        /// <returns>Value of the node including all descendent nodes</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(ref variables) + this.Right.Evaluate(ref variables);
        }
    }
}
