﻿// <copyright file="ChangeTextCommand.cs" company="PlaceholderCompany">
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
        private Cell cell;
        private string text;
        private string prevText;

        public ChangeTextCommand(Cell newCell, string newText)
        {
            this.cell = newCell;
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
            this.prevText = this.cell.Text;
            this.cell.Text = this.text;
        }

        public override void Undo()
        {
            this.cell.Text = this.prevText;
        }
    }
}
