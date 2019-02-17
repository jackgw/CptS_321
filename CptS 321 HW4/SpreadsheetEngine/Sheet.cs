namespace CptS_321_HW4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Spreadsheet class
    /// </summary>
    public class Sheet
    {
        private Cell[,] cells;
        private int columnCount;
        private int rowCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sheet"/> class.
        /// Initializes a 2D array of Cells according to size parameters
        /// </summary>
        /// <param name="columns">Number of Columns</param>
        /// <param name="rows">Number of Rows</param>
        public Sheet(int columns, int rows)
        {
            int i, j = 0;

            this.cells = new Cell[columns, rows];
            this.columnCount = columns;
            this.rowCount = rows;

            for (i = 1; i <= columns; i++)
            {
                for (j = 1; j <= rows; j++)
                {
                    this.cells[i, j] = new SpreadsheetCell(i, j);

                    /* Subscribe to cell property changed event */
                    this.cells[i, j].PropertyChanged += this.CellPropertyChanged;
                }
            }
        }

        /// <summary>
        /// Property changed event handler for all cells in the spreadsheet
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Gets the number of columns
        /// </summary>
        public int ColumnCount
        {
            get { return this.columnCount; }
        }

        /// <summary>
        /// Gets the number of rows
        /// </summary>
        public int RowCount
        {
            get { return this.rowCount; }
        }

        /// <summary>
        /// Changes text of a specified cell
        /// </summary>
        /// <param name="rowIndex">Row index</param>
        /// <param name="colIndex">Column Index</param>
        /// <param name="newText">New cell text</param>
        /// <returns>True if cell found, false otherwise</returns>
        public bool ChangeText(int rowIndex, int colIndex, string newText)
        {
            if (this.cells[colIndex, rowIndex] != null)
            {
                this.cells[colIndex, rowIndex].Text = newText;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the text of a cell to determine what to change the value to, and changes it
        /// </summary>
        /// <param name="targetCell">Cell to be changed</param>
        public void ChangeValue(Cell targetCell)
        {
            /* Conversion Required */
            if (targetCell.Text[0] == '=')
            {
                /* Set value equal to another cell's value */
                int colNum = targetCell.Text[1] - 65;       // convert ascii to index
                int rowNum = targetCell.Text[2] - 1;
                targetCell.ValueSet = this.cells[colNum, rowNum].Value;
            }
            else
            {
                targetCell.ValueSet = targetCell.Text;
            }
        }

        /// <summary>
        /// Returns the cell at a certain row and column index
        /// </summary>
        /// <param name="column">Column index of desired cell</param>
        /// <param name="row">Row index of desired cell</param>
        /// <returns>The cell object at given index</returns>
        public Cell GetCell(int column, int row)
        {
            return this.cells[column, row];
        }

        public void OnCellPropertyChanged()
        {

        }
    }
}
