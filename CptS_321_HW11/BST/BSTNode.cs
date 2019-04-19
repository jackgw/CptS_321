// <copyright file="BSTNode.cs" company="PlaceholderCompany">
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
    /// Class representing a single node in a BST
    /// </summary>
    internal class BSTNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BSTNode"/> class.
        /// Sets the value to the specified parameter
        /// </summary>
        /// <param name="newValue">Value to but put in the created Node</param>
        public BSTNode(int newValue)
        {
            this.LeftNode = null;
            this.RightNode = null;
            this.Value = newValue;
        }

        /// <summary>
        /// Gets or sets the LeftNode attribute
        /// </summary>
        public BSTNode LeftNode { get; set; }

        /// <summary>
        /// Gets or sets the RightNode attribute
        /// </summary>
        public BSTNode RightNode { get; set; }

        /// <summary>
        /// Gets or sets the Value attribute
        /// </summary>
        public int Value { get; set; }
    }
}
