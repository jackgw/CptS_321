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

    public class ChangeTextCommand : Command
    {
        private int colIndex;
        private int rowIndex;
        private string text;

        public ChangeTextCommand(int colNum, int rowNum, string newText)
        {
            this.colIndex = colNum;
            this.rowIndex = rowNum;
            this.text = newText;
        }

        public override string Name
        {
            get
            {
                return "Text Change";
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
