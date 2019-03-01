// <copyright file="BaseOperatorNode.cs" company="PlaceholderCompany">
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
    /// Expression tree node representing an operator
    /// </summary>
    internal abstract class BaseOperatorNode : BaseNode
    {
        /// <summary>
        /// Gets or sets the operator property
        /// </summary>
        public char Operator { get; set; }

        /// <summary>
        /// Gets or sets the left node property
        /// </summary>
        public BaseNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right node property
        /// </summary>
        public BaseNode Right { get; set; }
    }
}
