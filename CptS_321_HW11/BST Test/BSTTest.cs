// <copyright file="BST.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Test class for the BST implementation
    /// </summary>
    public class BSTTest
    {
        /// <summary>
        /// Tests the BST recursive print functionality
        /// </summary>
        [Test]
        public void TreePrintRecursiveTest()
        {
            /* Create a BST with contents: 1 2 5 15 25 40 80 99 */
            BST myBST = new BST();
            myBST.Insert(25);
            myBST.Insert(2);
            myBST.Insert(5);
            myBST.Insert(15);
            myBST.Insert(1);
            myBST.Insert(5);
            myBST.Insert(80);
            myBST.Insert(40);
            myBST.Insert(99);

            /* Test print output */
            StringAssert.AreEqualIgnoringCase(myBST.PrintTreeRecursive(),
                "[Recursive Traversal]\nTree Size: 8\nTree Contents: [1 2 5 15 25 40 80 99 ]\n");
        }

        /// <summary>
        /// Tests the BST stack print functionality
        /// </summary>
        [Test]
        public void TreePrintStackTest()
        {
            /* Create a BST with contents: 1 2 5 15 25 40 80 99 */
            BST myBST = new BST();
            myBST.Insert(25);
            myBST.Insert(2);
            myBST.Insert(5);
            myBST.Insert(15);
            myBST.Insert(1);
            myBST.Insert(5);
            myBST.Insert(80);
            myBST.Insert(40);
            myBST.Insert(99);

            /* Test print output */
            StringAssert.AreEqualIgnoringCase(myBST.PrintTreeStack(),
                "[Recursive Traversal]\nTree Size: 8\nTree Contents: [1 2 5 15 25 40 80 99 ]\n");
        }

        /// <summary>
        /// Tests the BST print functionality using no stack or recursion
        /// </summary>
        [Test]
        public void TreePrintNoStackOrRecursionTest()
        {
            /* Create a BST with contents: 1 2 5 15 25 40 80 99 */
            BST myBST = new BST();
            myBST.Insert(25);
            myBST.Insert(2);
            myBST.Insert(5);
            myBST.Insert(15);
            myBST.Insert(1);
            myBST.Insert(5);
            myBST.Insert(80);
            myBST.Insert(40);
            myBST.Insert(99);

            /* Test print output */
            StringAssert.AreEqualIgnoringCase(myBST.PrintTreeNoStackOrRecursion(),
                "[Recursive Traversal]\nTree Size: 8\nTree Contents: [1 2 5 15 25 40 80 99 ]\n");
        }
    }
}
