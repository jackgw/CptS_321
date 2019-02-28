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
                        ((BaseOperatorNode)tempNode).Left = operandStack.Pop();
                        ((BaseOperatorNode)tempNode).Right = operandStack.Pop();
                        operandStack.Push(tempNode);
                    }
                }

                return operandStack.Pop();
            }
        }

        /// <summary>
        /// Converts a string expression in infix notation (a+b) to prefix notation (ab+)
        /// </summary>
        /// <param name="expression">Expression in infix notation</param>
        /// <returns>Expression in postfix notation</returns>
        private List<BaseNode> InfixToPostfix(string expression)
        {
            List<BaseNode> postfixResult = new List<BaseNode>();
            Stack<BaseNode> operatorStack = new Stack<BaseNode>();
            int i = 0;
            string tempName;
            BaseNode tempNode;

            /* Separate expression into constant nodes, variable nodes, and operatornodes */
            while (i < expression.Length)
            {
                tempName = string.Empty;
                while (i < expression.Length || !this.operatorFactory.IsOperator(expression[i]))
                {
                    tempName += expression[i];
                    i++;
                }

                if (i < expression.Length)
                {
                    tempNode = this.CreateNode(tempName);
                    if (tempNode is VariableNode || tempNode is ConstantNode)
                    {
                        postfixResult.Add(tempNode);
                    }

                    if (tempNode is BaseOperatorNode)
                    {
                        while (operatorStack.Count > 0)
                        {
                            postfixResult.Add(operatorStack.Pop());
                        }

                        //operatorStack.Push();
                    }
                }
            }
        }

        private BaseNode CreateNode(string name)
        {
            int value = 0;

            if (name[0] >= 48 && name[0] <= 57)
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

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Name of target variable</param>
        /// <param name="variableValue">Desired variable value</param>
        public void SetVariable(string variableName, double variableValue)
        {

        }

        /// <summary>
        /// Evaluates the tree expression to a double value.
        /// </summary>
        /// <returns>Value of the expression</returns>
        public double Evaluate()
        {
            return 0;
        }
    }
}
