// <copyright file="CommandCollection.cs" company="PlaceholderCompany">
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
    /// Encapsulates a List of simple Command objects and a title for the overall operation
    /// </summary>
    public class CommandCollection
    {
        private List<Command> commandList = new List<Command>();
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCollection"/> class.
        /// Sets the name of the collection to the provided string
        /// </summary>
        /// <param name="newName">Collection Name</param>
        public CommandCollection(string newName)
        {
            this.name = newName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCollection"/> class.
        /// Accepts the name of the collection and an unspecified number of command object to be inserted into the list
        /// </summary>
        /// <param name="newName">Collection Name</param>
        /// <param name="cmds">Commands</param>
        public CommandCollection(string newName, params Command[] cmds)
        {
            this.name = newName;

            foreach (Command cmd in cmds)
            {
                this.commandList.Add(cmd);
            }
        }

        /// <summary>
        /// Gets the Name of the collection
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the list of commands in the collection
        /// </summary>
        /// <returns>THe List of commands</returns>
        public List<Command> GetCommandList()
        {
            return this.commandList;
        }

        /// <summary>
        /// Adds a single command to the command list
        /// </summary>
        /// <param name="newCmd">A new Command</param>
        public void AddCommand(Command newCmd)
        {
            this.commandList.Add(newCmd);
        }
    }
}
