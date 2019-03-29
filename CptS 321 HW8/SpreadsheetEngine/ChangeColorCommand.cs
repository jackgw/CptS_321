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

    public class ChangeColorCommand : Command
    {
        private Cell cell;
        private uint color;
        private uint prevColor;

        public ChangeColorCommand(Cell newCell, uint newColor)
        {
            this.cell = newCell;
            this.color = newColor;
        }

        public override string Name
        {
            get
            {
                return "Color Change";
            }
        }

        public override void Execute()
        {
            this.prevColor = this.cell.BGColor;
            this.cell.BGColor = this.color;
        }

        public override void Undo()
        {
            this.cell.BGColor = this.prevColor;
        }
    }
}
