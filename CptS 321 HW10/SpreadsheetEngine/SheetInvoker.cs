// <copyright file="SheetInvoker.cs" company="PlaceholderCompany">
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
    /// The Invoker class for the spreadsheet command pattern
    /// </summary>
    public class SheetInvoker
    {
        private Stack<CommandCollection> undoStack = new Stack<CommandCollection>();
        private Stack<CommandCollection> redoStack = new Stack<CommandCollection>();

        /// <summary>
        /// Executes every command in the CommandCollection object
        /// </summary>
        /// <param name="commands">Collection of command objects</param>
        public void ExecuteCommand(CommandCollection commands)
        {
            foreach (Command cmd in commands.GetCommandList())
            {
                cmd.Execute();
            }

            this.undoStack.Push(commands);
        }

        /// <summary>
        /// Undoes the last executed command using the undo stack
        /// </summary>
        public void UndoLastCommand()
        {
            CommandCollection tempCommands = this.undoStack.Pop();
            foreach (Command cmd in tempCommands.GetCommandList())
            {
                cmd.Undo();
            }

            this.redoStack.Push(tempCommands);
        }

        /// <summary>
        /// Redoes the last undone command using the redo stack
        /// </summary>
        public void RedoLastCommand()
        {
            CommandCollection tempCommands = this.redoStack.Pop();
            foreach (Command cmd in tempCommands.GetCommandList())
            {
                cmd.Execute();
            }

            this.undoStack.Push(tempCommands);
        }

        /// <summary>
        /// Checks the top of the undo stack. If stack is not empty, return the name. Returns 0 otherwise
        /// </summary>
        /// <returns>The name of the top item of the stack</returns>
        public string CheckUndo()
        {
            if (this.undoStack.Count != 0)
            {
                return this.undoStack.Peek().Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks the top of the redo stack. If stack is not empty, return the name. Returns 0 otherwise
        /// </summary>
        /// <returns>The name of the top item of the stack</returns>
        public string CheckRedo()
        {
            if (this.redoStack.Count != 0)
            {
                return this.redoStack.Peek().Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Clears all contents from both stacks
        /// </summary>
        public void ClearStacks()
        {
            this.redoStack.Clear();
            this.undoStack.Clear();
        }
    }
}
