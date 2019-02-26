namespace ExpressionTreeApp
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

            /* Get expression */
            Console.WriteLine("Enter an expression: ");
            expression = Console.ReadLine();

            /* Command Prompt Loop */
            do
            {
                Console.WriteLine("Choose an option: \n1. Set Variable Value\n2. Evaluate\n3. Exit");
                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        // prompt for name and value, and change
                        break;
                    case 2:
                        // evaluate
                        break;
                    case 3:
                        Console.WriteLine("Exiting...\n");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection\n");
                        break;
                }
            } while (selection != 3);
        }
    }
}
