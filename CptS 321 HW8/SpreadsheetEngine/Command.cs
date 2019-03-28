// <copyright file="ICommand.cs" company="PlaceholderCompany">
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
    /// Interface representing a general command with Execute and Undo functionality
    /// </summary>
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute();

        public abstract void Undo();
    }
}
