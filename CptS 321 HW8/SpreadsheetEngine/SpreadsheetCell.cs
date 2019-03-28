// <copyright file="SpreadsheetCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Jack Wharton
// 11506329
// CptS 321

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 'Concrete Product' implementation of the Cell class
    /// </summary>
    internal class SpreadsheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="columnNum">Column the cell is in</param>
        /// <param name="rowNum">Row the cell is in</param>
        public SpreadsheetCell(int columnNum, int rowNum)
        {
            this.BGColor = 0xFFFFFFFF;
            this.columnIndex = columnNum;
            this.rowIndex = rowNum;
            this.text = string.Empty;
            this.value = string.Empty;
        }

        /// <summary>
        /// Gets or sets the color of the cell.
        /// If the color is changed, fire property changed event
        /// </summary>
        public override uint BGColor
        {
            get
            {
                return this.bgcolor;
            }

            set
            {
                if (value == this.bgcolor)
                {
                    return;
                }
                else
                {
                    this.bgcolor = value;
                    this.OnPropertyChanged("color");
                }
            }
        }

        /// <summary>
        /// Gets the column index of the cell
        /// </summary>
        public override int ColumnIndex
        {
            get { return this.columnIndex; }
        }

        /// <summary>
        /// Gets the row index of the cell
        /// </summary>
        public override int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets or sets the text contained in the cell
        /// If the text is changed, then fire property changed event
        /// </summary>
        public override string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == this.text)
                {
                    return;
                }
                else
                {
                    this.text = value;
                    this.OnPropertyChanged("text");
                }
            }
        }

        /// <summary>
        /// Gets the value of the cell
        /// </summary>
        public override string Value
        {
            get { return this.value; }

            // only spreadsheet should be allowed to change this value
        }

        /// <summary>
        /// Sets the value variable. Only visable to Sheet class.
        /// </summary>
        internal override string ValueSet
        {
            set
            {
                if (value == this.value)
                {
                    return;
                }
                else
                {
                    this.value = value;
                    this.OnPropertyChanged("value");
                }
            }
        }
    }
}
