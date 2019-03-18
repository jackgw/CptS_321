// <copyright file="App.cs" company="PlaceholderCompany">
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
    /// Console applicaion for interation with the ExpressionTree class.
    /// </summary>
    public class App
    {
        /// <summary>
        /// Prompts the user for an expression, and instantiates an ExpressionTree using the expression.
        /// Provides options to set variable value, evaluate, or quit.
        /// </summary>
        /// <param name="args">External string arguments</param>
        public static void Main(string[] args)
        {
            string expression = string.Empty;
            int selection = 0;
            string variableName;
            double variableValue;

            /* Get expression */
            Console.Write("Enter an expression: ");
            expression = Console.ReadLine();

            ExpressionTree appExpressionTree = new ExpressionTree(expression);

            /* Command Prompt Loop */
            do
            {
                Console.WriteLine("\nExpression: " + expression);
                Console.WriteLine("=====================\n1. Set Variable Value\n2. Evaluate\n3. New Expression\n4. Exit\n=====================");
                Console.Write("Choose an option: ");
                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.Write("Enter variable name: ");
                        variableName = Console.ReadLine();
                        if (appExpressionTree.ContainsVariable(variableName))
                        {
                            Console.Write("Variable found. Enter variable value: ");
                            variableValue = int.Parse(Console.ReadLine());
                            appExpressionTree.SetVariable(variableName, variableValue);
                        }
                        else
                        {
                            Console.WriteLine("Variable not found.");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Expression Tree Value: " + appExpressionTree.Evaluate());
                        break;
                    case 3:
                        Console.Write("Enter new expression: ");
                        expression = Console.ReadLine();
                        appExpressionTree = new ExpressionTree(expression);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...\n");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection\n");
                        break;
                }
            }
            while (selection != 4);
        }
    }
}
