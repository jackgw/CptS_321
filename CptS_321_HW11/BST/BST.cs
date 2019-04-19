// <copyright file="BST.cs" company="PlaceholderCompany">
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
    /// Binary Search Tree class. Uses BSTNode class as nodes
    /// </summary>
    public class BST
    {
        private BSTNode root;
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="BST"/> class by calling BuildTree()
        /// </summary>
        public BST()
        {
            this.root = null;
            this.size = 0;
        }

        /// <summary>
        /// Prints the [In Order] contents of the tree using recursion
        /// </summary>
        /// <returns>The string output</returns>
        public string PrintTreeRecursive()
        {
            string line = "[Recursive Traversal]\n";
            line += "Tree Size: " + this.size;
            line += "\nTree Contents: [";
            this.RecursivePrint(this.root, ref line);
            line += "]\n";

            Console.WriteLine(line);
            return line;
        }

        /// <summary>
        /// Prints the [In Order] contents of the tree using a single stack
        /// </summary>
        /// <returns>The string output</returns>
        public string PrintTreeStack()
        {
            Stack<BSTNode> nodeStack = new Stack<BSTNode>();
            BSTNode curNode = this.root, tempNode;
            string output = "[Stack Traversal]\n";
            output += "Tree Size: " + this.size;
            output += "\nTree Contents: [";

            while (curNode != null || nodeStack.Count > 0)
            {
                /* move all the way to the left, pushing cur to the stack */
                while (curNode != null)
                {
                    nodeStack.Push(curNode);
                    curNode = curNode.LeftNode;
                }

                /* if stack not empty when curNode == null, pop, print value, and move one to the right */
                if (nodeStack.Count > 0)
                {
                    tempNode = nodeStack.Pop();
                    output += tempNode.Value + " ";
                    curNode = tempNode.RightNode;
                }
            }

            output += "]\n";
            Console.WriteLine(output);
            return output;
        }

        /// <summary>
        /// Prints the [In Order] contents of the tree only by rearranging the tree links
        /// </summary>
        /// <returns>The string output</returns>
        public string PrintTreeNoStackOrRecursion()
        {
            return "";
        }

        /// <summary>
        /// Pupulates the BST with 25 random values from 0 to 100
        /// </summary>
        public void BuildTree()
        {
            Random randomGenerator = new Random();
            BSTNode newNode;
            int i = 0;

            for (i = 0; i < 30; i++)
            {
                newNode = new BSTNode(randomGenerator.Next(0, 100));
                this.InsertNode(newNode, this.root);
            }
        }

        /// <summary>
        /// Inserts a value into the BST
        /// </summary>
        /// <param name="newValue">value to be inserted</param>
        public void Insert(int newValue)
        {
            BSTNode newNode = new BSTNode(newValue);
            this.InsertNode(newNode, this.root);
        }

        /// <summary>
        /// Recursively inserts a single node into the BST, starting at curNode
        /// </summary>
        /// <param name="newNode">Node to be inserted</param>
        /// <param name="curNode">Starting Node</param>
        private void InsertNode(BSTNode newNode, BSTNode curNode)
        {
            if (newNode != null)
            {
                if (this.root == null)
                {
                    this.root = newNode;
                    this.size++;
                }
                else if (newNode.Value < curNode.Value)
                {
                    if (curNode.LeftNode == null)
                    {
                        curNode.LeftNode = newNode;
                        this.size++;
                    }
                    else
                    {
                        this.InsertNode(newNode, curNode.LeftNode);
                    }
                }
                else if (newNode.Value > curNode.Value)
                {
                    if (curNode.RightNode == null)
                    {
                        curNode.RightNode = newNode;
                        this.size++;
                    }
                    else
                    {
                        this.InsertNode(newNode, curNode.RightNode);
                    }
                }
            }
        }

        /// <summary>
        /// Recursively prints all nodes in order
        /// </summary>
        /// <param name="curNode">current/starting node</param>
        /// <param name="line">return string</param>
        private void RecursivePrint(BSTNode curNode, ref string line)
        {
            if (curNode != null)
            {
                this.RecursivePrint(curNode.LeftNode, ref line);
                line += curNode.Value + " ";
                this.RecursivePrint(curNode.RightNode, ref line);
            }
        }
    }
}
