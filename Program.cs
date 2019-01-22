using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace CptS_321_HW1
{
    class Program
    {
        /// <summary>
        /// BSTNode class, defining a single node with internal data and links to left and right BSTNodes. 
        /// For use in a Binary Search Tree Data Structure.
        /// </summary>
        class BSTNode
        {
            // Constructor accepting integer data as input
            public BSTNode(int newData)
            {
                nodeData = newData;
                leftNode = null;
                rightNode = null;
            }

            // Setters and Getters for the left BSTNode
            public BSTNode LeftNode
            {
                get { return leftNode; }
                set { leftNode = value; }
            }

            // Setters and Getters for the right BSTNode
            public BSTNode RightNode
            {
                get { return rightNode; }
                set { rightNode = value; }
            }

            // Setters and Getters for the node data
            public int NodeData
            {
                get { return nodeData; }
                set { nodeData = value; }
            }

            private BSTNode leftNode;
            private BSTNode rightNode;
            private int nodeData;
        }

        /// <summary>
        /// BST class, providing implementation for the Binary Search Tree data structure. Contains a head node and internal level and size data with
        /// getters and setters, as well as functionality for the insert, print in order, and count size methods.
        /// Requires the use of BSTNode class for individual nodes.
        /// </summary>
        class BST
        {
            // Default constructor for BST
            public BST()
            {
                this.treeLevels = 0;
                this.treeSize = 0;
                this.headNode = null;
            }

            // Private recursive insert, accepting a newNode to be added, a current node, and a current level. Returns true if newNode inserted successfully.
            private bool insert(BSTNode newNode, BSTNode currentNode, int level)
            {
                bool success = false;
                if (currentNode != null)
                {
                    if (newNode.NodeData < currentNode.NodeData)
                    {
                        level++;
                        if (currentNode.LeftNode != null)
                        {
                            success = insert(newNode, currentNode.LeftNode, level);
                        }
                        else
                        {
                            currentNode.LeftNode = newNode;
                            if (level > this.treeLevels)
                            {
                                this.treeLevels = level;
                            }
                            success = true;
                        }
                    }
                    if (newNode.NodeData > currentNode.NodeData)
                    {
                        level++;
                        if (currentNode.RightNode != null)
                        {
                            success = insert(newNode, currentNode.RightNode, level);
                        }
                        else
                        {
                            currentNode.RightNode = newNode;
                            if (level > this.treeLevels)
                            {
                                this.treeLevels = level;
                            }
                            success = true;
                        }
                    }
                    if (newNode.NodeData == currentNode.NodeData)
                    {
                        success = false;
                    }
                }
                else
                {
                    this.headNode = newNode;
                    if (level > this.treeLevels)
                    {
                        this.treeLevels = level;
                    }
                    success = true;
                }
                return success;
            } 

            // Public insert function, accepting integer data to be inserted, making a new node with the data, and calling the recursive insert.
            public bool insert(int newData)
            {
                bool success = false;

                BSTNode newNode = new CptS_321_HW1.Program.BSTNode(newData);

                if (newNode != null)
                {
                    success = insert(newNode, headNode, 1);
                }

                return success;
            }

            // Private recursive print function, traversing the BST in order and printing all values.
            private void printInOrder(BSTNode currentNode)
            {
                if (currentNode != null)
                {
                    printInOrder(currentNode.LeftNode);
                    Console.Write(currentNode.NodeData + " ");
                    printInOrder(currentNode.RightNode);
                }
            }

            // Public print function, calling the private recursive print.
            public void printInOrder()
            {
                Console.Write("Tree Contents: ");
                printInOrder(this.headNode);
                Console.Write("\n");
            }

            // Private recursive count function, traversing the entire list and counting the total number of nodes, updating the treeSize variable.
            private void countSize(BSTNode currentNode)
            {
                if (currentNode != null)
                {
                    countSize(currentNode.LeftNode);
                    countSize(currentNode.RightNode);
                    this.treeSize++;
                }
            }

            // Public count function, calling private recursive count.
            public void countSize()
            {
                countSize(this.headNode);

            }

            // Print statistics function, calling the countSize function and printing the value of treeSize and treeLevels, as well as
            // calculating the theoretical minimum levels needed for a BST of that size.
            public void printStats()
            {
                this.countSize();
                Console.WriteLine("Tree Size: " + treeSize);
                Console.WriteLine("Tree Levels: " + treeLevels);
                Console.WriteLine("Theoretical Minimum Levels: " + (Math.Floor(Math.Log(treeSize, 2)) + 1));
            }

            // getter and setter for treeLevels variable
            public int TreeLevels
            {
                get { return this.treeLevels; }
                set { this.treeLevels = value; }
            }

            // getter and setter for treeSize variable
            public int TreeSize
            {
                get { return this.treeSize; }
                set { this.treeSize = value; }
            }

            private int treeLevels;
            private int treeSize;
            private BSTNode headNode;
        }

        static void Main(string[] args)
        {
            string userLine = "";
            BST userTree = new BST();

            // Get user input
            Console.WriteLine("Enter a series of integers in the range [0, 100] separated by spaces:");
            userLine = Console.ReadLine();

            // Insert each integer entered by the user
            foreach(string userString in userLine.Split(' '))
            {
                userTree.insert(int.Parse(userString));
            }

            // Print tree contents and statistics
            userTree.printInOrder();
            userTree.printStats();
        }

        [Test]
        public void treeStatisticsTest()
        {
            BST testBST = new CptS_321_HW1.Program.BST();

            // insert the values: 10 5 1 15 11 20
            testBST.insert(10);
            testBST.insert(5);
            testBST.insert(1);
            testBST.insert(15);
            testBST.insert(11);
            testBST.insert(20);

            // test statistics
            testBST.countSize();
            Assert.AreEqual(testBST.TreeLevels, 3);
            Assert.AreEqual(testBST.TreeSize, 6);
            Assert.AreEqual((Math.Floor(Math.Log(testBST.TreeSize, 2)) + 1), 3);
        }
    }
}
