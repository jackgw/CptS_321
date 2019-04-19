// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Primary class for the prorgam. contains main()
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main() function. Creates a new bst and prints the contents using the 3 implemented methods
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BST myBST = new BST();
            myBST.BuildTree();
            myBST.PrintTreeNoStackOrRecursion();
            myBST.PrintTreeStack();
            myBST.PrintTreeRecursive();
        }
    }
}
