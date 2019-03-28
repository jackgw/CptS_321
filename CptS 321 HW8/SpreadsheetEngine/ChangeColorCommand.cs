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
        private int colIndex;
        private int rowIndex;
        private uint color;

        public ChangeColorCommand(int colNum, int rowNum, uint newColor)
        {
            this.colIndex = colNum;
            this.rowIndex = rowNum;
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

        }

        public override void Undo()
        {

        }
    }
}
