// <copyright file="DivideOperatorNode.cs" company="PlaceholderCompany">
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
    /// Operator node implementing division functionality
    /// </summary>
    internal class DivideOperatorNode : BaseOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivideOperatorNode"/> class.
        /// </summary>
        public DivideOperatorNode()
        {
            this.Operator = '/';
            this.Left = this.Right = null;
            this.precedence = 2;
        }

        /// <summary>
        /// Evaluates the value of the node
        /// </summary>
        /// <param name="variables">Variables dictionary</param>
        /// <returns>Value of node including all descendant nodes</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(ref variables) / this.Right.Evaluate(ref variables);
        }
    }
}
