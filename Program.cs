namespace CptS_321_HW1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Prompts the user to input a sequence of integers, inserts those integers into a BST, and prints the contents of the BST
        /// in order, as well as statistics about the BST such as the size, levels, and theoretical minimum levels required.
        /// </summary>
        /// <param name="args"> External input strings </param>
        public static void Main(string[] args)
        {
            string userLine = string.Empty;
            BST userTree = new BST();

            // Get user input
            Console.WriteLine("Enter a series of integers in the range [0, 100] separated by spaces:");
            userLine = Console.ReadLine();

            // Insert each integer entered by the user
            foreach (string userString in userLine.Split(' '))
            {
                userTree.Insert(int.Parse(userString));
            }

            // Print tree contents and statistics
            userTree.PrintInOrder();
            userTree.PrintStats();
        }

        /// <summary>
        /// Test function
        /// </summary>
        [Test]
        public void TreeStatisticsTest()
        {
            BST testBST = new CptS_321_HW1.Program.BST();

            // insert the values: 10 5 1 15 11 20
            testBST.Insert(10);
            testBST.Insert(5);
            testBST.Insert(1);
            testBST.Insert(15);
            testBST.Insert(11);
            testBST.Insert(20);

            // test statistics
            testBST.CountSize();
            Assert.AreEqual(testBST.TreeLevels, 3);
            Assert.AreEqual(testBST.TreeSize, 6);
            Assert.AreEqual(Math.Floor(Math.Log(testBST.TreeSize, 2)) + 1, 3);
        }

        /// <summary>
        /// BSTNode class, defining a single node with internal data and links to left and right BSTNodes. 
        /// For use in a Binary Search Tree Data Structure.
        /// </summary>
        public class BSTNode
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BSTNode" /> class. accepts an integer to be assigned to the new node's nodeData variable.
            /// </summary>
            /// <param name="newData"> Integer data to be stored in the created node </param>
            public BSTNode(int newData)
            {
                this.nodeData = newData;
                this.leftNode = null;
                this.rightNode = null;
            }

            /// <summary>
            /// Gets or sets leftNode variable.
            /// </summary>
            public BSTNode LeftNode
            {
                get { return this.leftNode; }
                set { this.leftNode = value; }
            }

            /// <summary>
            /// Gets or sets rightNode variable.
            /// </summary>
            public BSTNode RightNode
            {
                get { return this.rightNode; }
                set { this.rightNode = value; }
            }

            /// <summary>
            /// Gets or sets nodeData variable.
            /// </summary>
            public int NodeData
            {
                get { return this.nodeData; }
                set { this.nodeData = value; }
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
        public class BST
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BST" /> class.
            /// </summary>
            public BST()
            {
                this.treeLevels = 0;
                this.treeSize = 0;
                this.headNode = null;
            }

            /// <summary>
            /// Public insert function, accepting integer data to be inserted, making a new node with the data, and calling the recursive insert.
            /// </summary>
            /// <param name="newData"> Integer value to be inserted into the BST </param>
            /// <returns> True if node inserted successfully, false otherwise </returns>
            public bool Insert(int newData)
            {
                bool success = false;

                BSTNode newNode = new CptS_321_HW1.Program.BSTNode(newData);

                if (newNode != null)
                {
                    success = this.Insert(newNode, this.headNode, 1);
                }
                return success;
            }

            /// <summary>
            /// Public print function, calling the private recursive print.
            /// </summary>
            public void PrintInOrder()
            {
                Console.Write("Tree Contents: ");
                this.PrintInOrder(this.headNode);
                Console.Write("\n");
            }

            /// <summary>
            /// Public count function, calling private recursive count.
            /// </summary>
            public void CountSize()
            {
                this.CountSize(this.headNode);
            }

            /// <summary>
            /// Print statistics function, calling the countSize function and printing the value of treeSize and treeLevels, as well as
            /// calculating the theoretical minimum levels needed for a BST of that size.
            /// </summary>
            public void PrintStats()
            {
                this.CountSize();
                Console.WriteLine("Tree Size: " + this.treeSize);
                Console.WriteLine("Tree Levels: " + this.treeLevels);
                Console.WriteLine("Theoretical Minimum Levels: " + (Math.Floor(Math.Log(this.treeSize, 2)) + 1));
            }

            /// <summary>
            /// Gets or sets the treeLevels variable.
            /// </summary>
            public int TreeLevels
            {
                get { return this.treeLevels; }
                set { this.treeLevels = value; }
            }

            /// <summary>
            /// Gets or sets the treeSize variable.
            /// </summary>
            public int TreeSize
            {
                get { return this.treeSize; }
                set { this.treeSize = value; }
            }

            /// <summary>
            /// Private recursive insert, accepting a newNode to be added, a current node, and a current level. 
            /// </summary>
            /// <param name="newNode"> New constructed node containing the data to be inserted </param>
            /// <param name="currentNode"> The current node in the recursive cycle </param>
            /// <param name="level"> The level of the current node </param>
            /// <returns> Returns true if newNode inserted successfully. </returns>
            private bool Insert(BSTNode newNode, BSTNode currentNode, int level)
            {
                bool success = false;
                if (currentNode != null)
                {
                    if (newNode.NodeData < currentNode.NodeData)
                    {
                        level++;
                        if (currentNode.LeftNode != null)
                        {
                            success = this.Insert(newNode, currentNode.LeftNode, level);
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
                            success = this.Insert(newNode, currentNode.RightNode, level);
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

            /// <summary>
            /// Private recursive print function, traversing the BST in order and printing all values.
            /// </summary>
            /// <param name="currentNode"> Current node in the recursive traversal </param>
            private void PrintInOrder(BSTNode currentNode)
            {
                if (currentNode != null)
                {
                    this.PrintInOrder(currentNode.LeftNode);
                    Console.Write(currentNode.NodeData + " ");
                    this.PrintInOrder(currentNode.RightNode);
                }
            }

            /// <summary>
            /// Private recursive count function, traversing the entire list and counting the total number of nodes, updating the treeSize variable.
            /// </summary>
            /// <param name="currentNode"> The current node in the recursive traversal </param>
            private void CountSize(BSTNode currentNode)
            {
                if (currentNode != null)
                {
                    this.CountSize(currentNode.LeftNode);
                    this.CountSize(currentNode.RightNode);
                    this.treeSize++;
                }
            }

            private int treeLevels;
            private int treeSize;
            private BSTNode headNode;
        }
    }
}