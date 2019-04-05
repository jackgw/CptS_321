// <copyright file="ChangeTextCommand.cs" company="PlaceholderCompany">
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
    /// Concrete command for the changing of the cell's text
    /// </summary>
    public class ChangeTextCommand : Command
    {
        private Cell cell;
        private string text;
        private string prevText;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTextCommand"/> class.
        /// </summary>
        /// <param name="newCell">Cell to be changed</param>
        /// <param name="newText">New text of the cell</param>
        public ChangeTextCommand(Cell newCell, string newText)
        {
            this.cell = newCell;
            this.text = newText;
        }

        /// <summary>
        /// Changes the text of the cell to the new value
        /// </summary>
        public override void Execute()
        {
            this.prevText = this.cell.Text;
            this.cell.Text = this.text;
        }

        /// <summary>
        /// Changes the text of the cell to its previous value
        /// </summary>
        public override void Undo()
        {
            this.cell.Text = this.prevText;
        }
    }
}
