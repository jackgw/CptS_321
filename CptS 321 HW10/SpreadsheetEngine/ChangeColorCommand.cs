// <copyright file="ChangeColorCommand.cs" company="PlaceholderCompany">
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
    /// Concrete command for the changing of a cell's background color
    /// </summary>
    public class ChangeColorCommand : Command
    {
        private Cell cell;
        private uint color;
        private uint prevColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeColorCommand"/> class.
        /// </summary>
        /// <param name="newCell">The cell to be modified</param>
        /// <param name="newColor">The new background color</param>
        public ChangeColorCommand(Cell newCell, uint newColor)
        {
            this.cell = newCell;
            this.color = newColor;
        }

        /// <summary>
        /// Changes the Background color of the cell to the new value
        /// </summary>
        public override void Execute()
        {
            this.prevColor = this.cell.BGColor;
            this.cell.BGColor = this.color;
        }

        /// <summary>
        /// Changes the Background color of the cell to the previous value
        /// </summary>
        public override void Undo()
        {
            this.cell.BGColor = this.prevColor;
        }
    }
}
