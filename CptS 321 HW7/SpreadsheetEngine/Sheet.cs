namespace CptS321
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

            for (i = 0; i < columns; i++)
            {
                for (j = 0; j < rows; j++)
                {
                    this.cells[i, j] = new SpreadsheetCell(i, j);
                }
            }
        }

        /// <summary>
        /// Property changed event handler for all cells in the spreadsheet
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        private void SheetDependancyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            this.ChangeValue((Cell)sender);
            // use event args to call changeValue()
        }

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
            /* Subscribe to cell property changed event */
            this.cells[colIndex, rowIndex].PropertyChanged += this.CellPropertyChanged;

            if (this.cells[colIndex, rowIndex] != null)
            {
                this.cells[colIndex, rowIndex].Text = newText;
                this.ChangeValue(this.cells[colIndex, rowIndex]);
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
        private void ChangeValue(Cell targetCell)
        {
            /* Conversion Required */
            if (targetCell.Text != null && targetCell.Text[0] == '=')
            {
                int colNum = 0;
                int rowNum = 0;
                double value;
                string result;
                /* Set value equal to another cell's value */
                ExpressionTree expTree = new ExpressionTree(targetCell.Text.TrimStart('='));

                List<string> variableList = expTree.GetVariableNames();

                /* Can assume that all variables will be cells in the form (A1, B2, etc.) for this Assignment */
                foreach (string var in variableList)
                {
                    colNum = var[0] - 65;       // convert ascii to index
                    rowNum = int.Parse(var[1].ToString()) - 1;

                    /* subscribe dependant cell's dependancychanged to needed cell's propertychanged */
                    targetCell.Unsubscribe(ref this.cells[colNum, rowNum]);
                    targetCell.Subscribe(ref this.cells[colNum, rowNum]);
                    targetCell.DependancyChanged += new PropertyChangedEventHandler(this.SheetDependancyChangedHandler);

                    if (double.TryParse(this.cells[colNum, rowNum].Value, out value))
                    {
                        expTree.SetVariable(var, value);
                    }
                }

                targetCell.ValueSet = expTree.Evaluate().ToString();
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
