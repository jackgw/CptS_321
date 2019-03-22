// <copyright file="SubtractOperatorNode.cs" company="PlaceholderCompany">
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
    /// Implementation for the subtraction (-) operator
    /// </summary>
    internal class SubtractOperatorNode : BaseOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractOperatorNode"/> class.
        /// </summary>
        /// <param name="c">Operator symbol</param>
        public SubtractOperatorNode()
        {
            this.Operator = '-';
            this.Left = this.Right = null;
            this.precedence = 1;
        }

        /// <summary>
        /// Evaluates the node value by subtracting the value of the left node from the right node
        /// </summary>
        /// <param name="variables">Variable dictionary</param>
        /// <returns>Value of the node</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(ref variables) - this.Right.Evaluate(ref variables);
        }
    }
}
