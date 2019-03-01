// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
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
    ///  Implements an arithmetic expression parser that builds a tree for a given expression.
    ///  The tree is then used for evaluation of the expression.
    /// </summary>
    public class ExpressionTree
    {
        private BaseNode root;
        private Dictionary<string, double> variables = new Dictionary<string, double>();
        private OperatorNodeFactory operatorFactory = new OperatorNodeFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Constructs the tree from a specific expression
        /// </summary>
        /// <param name="expression">Expression to be parsed</param>
        public ExpressionTree(string expression)
        {
            this.root = this.CreateTree(expression);
        }

        /// <summary>
        /// Checks if the variables dictionary contains the given key. For external use
        /// </summary>
        /// <param name="variableName">Dictionary of variables and values</param>
        /// <returns>True if variable is in the dictionary, false otherwise</returns>
        public bool ContainsVariable(string variableName)
        {
            return this.variables.ContainsKey(variableName);
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Name of target variable</param>
        /// <param name="variableValue">Desired variable value</param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (this.variables.ContainsKey(variableName))
            {
                this.variables[variableName] = variableValue;
            }
        }

        /// <summary>
        /// Evaluates the tree expression to a double value.
        /// </summary>
        /// <returns>Value of the expression</returns>
        public double Evaluate()
        {
            return this.root.Evaluate(ref this.variables);
        }

        /// <summary>
        /// Constructs the tree from a specific expression
        /// </summary>
        /// <returns>The root node of the expression tree</returns>
        /// <param name="expression">Expression to be parsed</param>
        private BaseNode CreateTree(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }
            else
            {
                List<BaseNode> postfixNodes = this.InfixToPostfix(expression);
                Stack<BaseNode> operandStack = new Stack<BaseNode>();
                foreach (BaseNode tempNode in postfixNodes)
                {
                    if (tempNode is ConstantNode)
                    {
                        operandStack.Push(tempNode);
                    }
                    else if (tempNode is VariableNode)
                    {
                        operandStack.Push(tempNode);
                        this.variables.Add(((VariableNode)tempNode).Name, 0); // Variable values set to 0 by default
                    }
                    else
                    {
                        ((BaseOperatorNode)tempNode).Right = operandStack.Pop();
                        ((BaseOperatorNode)tempNode).Left = operandStack.Pop();
                        operandStack.Push(tempNode);
                    }
                }

                return operandStack.Pop();
            }
        }

        /// <summary>
        /// Converts a string expression in infix notation (a+b) to prefix notation (ab+)
        /// Does not consider Operator Precedence or the inclusion of parentheses
        /// </summary>
        /// <param name="expression">Expression in infix notation</param>
        /// <returns>Expression in postfix notation</returns>
        private List<BaseNode> InfixToPostfix(string expression)
        {
            List<BaseNode> postfixResult = new List<BaseNode>();
            Stack<BaseNode> operatorStack = new Stack<BaseNode>();
            int i = 0;
            string tempName = string.Empty;
            BaseNode tempNode;

            /* Check for a negative as the first symbol */
            if (expression[i] == '-')
            {
                tempName += '-';
                i++;
            }

            /* Separate expression into constant nodes, variable nodes, and operatornodes */
            while (i < expression.Length)
            {
                while (i < expression.Length && !this.operatorFactory.IsOperator(expression[i]))
                {
                    tempName += expression[i];
                    i++;
                }

                tempNode = this.CreateNode(tempName);
                if (tempNode is VariableNode || tempNode is ConstantNode)
                {
                    postfixResult.Add(tempNode);
                    if (i < expression.Length)
                    {
                        tempName = expression[i].ToString();    // next operator
                    }
                }
                else if (tempNode is BaseOperatorNode)
                {
                    while (operatorStack.Count > 0)
                    {
                        postfixResult.Add(operatorStack.Pop());
                    }

                    operatorStack.Push(tempNode);
                    tempName = string.Empty;                // reset temp string
                    i++;
                    if (expression[i] == '-')
                    {
                        tempName += '-';                   // check for a negative following an operator
                        i++;
                    }
                }
            }

            postfixResult.Add(operatorStack.Pop());
            return postfixResult;
        }

        /// <summary>
        /// Deternimes the type of node based on the input string and creates a corresponding node subclass
        /// </summary>
        /// <param name="name">Node name as given in expression</param>
        /// <returns>A node containing the name and corresponding to the corrext type</returns>
        private BaseNode CreateNode(string name)
        {
            int value = 0;

            if ((name[0] >= 48 && name[0] <= 57) || (name.Length > 1 && name[0] == '-'))
            {
                /* First character is a number: Constant Node */
                if (int.TryParse(name, out value))
                {
                    return new ConstantNode(value);
                }
                else
                {
                    return null;
                }
            }
            else if (name.Length == 1 && this.operatorFactory.IsOperator(name[0]))
            {
                /* Operator Node */
                return this.operatorFactory.GetOperatorNode(name[0]);
            }
            else
            {
                /* Variable Node */
                return new VariableNode(name);
            }
        }
    }
}
