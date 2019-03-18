// <copyright file="CloseParenthesesOperatorNode.cs" company="PlaceholderCompany">
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
    /// Operator node to represent open parentheses. For use in building tree but not to be evaluated
    /// </summary>
    internal class CloseParenthesesOperatorNode : BaseOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloseParenthesesOperatorNode"/> class.
        /// </summary>
        /// <param name="c">operator symbol</param>
        public CloseParenthesesOperatorNode(char c)
        {
            this.Operator = c;
            this.Left = this.Right = null;
            this.precedence = 0;
        }

        /// <summary>
        /// Evaluates the value of the node
        /// </summary>
        /// <param name="variables">Variables dictionary</param>
        /// <returns>Value of node including all descendant nodes</returns>
        public override double Evaluate(ref Dictionary<string, double> variables)
        {
            throw new System.InvalidOperationException("Cannot evaluate paretheses");
        }
    }
}
