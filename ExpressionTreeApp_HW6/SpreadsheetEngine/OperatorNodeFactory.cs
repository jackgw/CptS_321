// <copyright file="OperatorNodeFactory.cs" company="PlaceholderCompany">
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
    /// Factory for creating operator nodes
    /// </summary>
    internal class OperatorNodeFactory
    {
        private char[] supportedOperators = { '+', '-', '*', '/' };

        /// <summary>
        /// Creates an operator node based on a given operator symbol
        /// </summary>
        /// <param name="op">Operator symbol</param>
        /// <returns>Appropriate subnode corresponding to the operator</returns>
        public BaseOperatorNode GetOperatorNode(char op)
        {
            switch (op)
            {
                case '-':
                    return new SubtractOperatorNode(op);
                case '+':
                    return new AddOperatorNode(op);
                case '*':
                    return new MultiplyOperatorNode(op);
                case '/':
                    return new DivideOperatorNode(op);
                default:
                    return null;
            }
        }

        /// <summary>
        /// checks if element matches one of the supported operations
        /// </summary>
        /// <param name="op">Character to be checked</param>
        /// <returns>True if character is a valid operator, false otherwise</returns>
        public bool IsOperator(char op)
        {
            foreach (char supportedOperator in this.supportedOperators)
            {
                if (supportedOperator == op)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
