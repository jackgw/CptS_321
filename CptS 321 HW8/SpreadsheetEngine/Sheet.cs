// <copyright file="Sheet.cs" company="PlaceholderCompany">
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
        /// Sets the CellPropertyChanged event to subscribe to all cell propertychanged events
        /// </summary>
        /// <param name="cols">Column index</param>
        /// <param name="rows">Row index</param>
        public void SetSubsciptions(int cols, int rows)
        {
            int i, j;

            for (i = 0; i < cols; i++)
            {
                for (j = 0; j < rows; j++)
                {
                    /* Subscribe to cell property changed event */
                    this.cells[i, j].PropertyChanged += new PropertyChangedEventHandler(this.OnCellPropertyChanged);
                }
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

        /// <summary>
        /// Handles dependancy changed of a cell by recalculating the value of that cell
        /// </summary>
        /// <param name="sender">Cell that fired the event</param>
        /// <param name="e">event argument</param>
        private void SheetDependancyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            this.ChangeValue((Cell)sender);
        }

        /// <summary>
        /// Handles the cell PropertyChanged event by calculating the value if it is a text change, and forwarding it to the 
        /// form's event handler to update the cell in the UI
        /// </summary>
        /// <param name="sender">Cell that fired the event</param>
        /// <param name="e">event argument</param>
        private void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            /* Text Changed: calculate new value */
            if (e.PropertyName == "text")
            {
                this.ChangeValue((Cell)sender);
            }

            this.CellPropertyChanged(sender, e);
        }

        /// <summary>
        /// Checks the text of a cell to determine what to change the value to, and changes it
        /// </summary>
        /// <param name="targetCell">Cell to be changed</param>
        private void ChangeValue(Cell targetCell)
        {
            /* Conversion Required */
            if (targetCell.Text != string.Empty && targetCell.Text[0] == '=')
            {
                int colNum = 0;
                int rowNum = 0;
                double value;
                /* Set value equal to another cell's value */
                ExpressionTree expTree = new ExpressionTree(targetCell.Text.TrimStart('='));

                List<string> variableList = expTree.GetVariableNames();

                /* Can assume that all variables will be cells in the form (A1, B2, etc.) for this Assignment */
                foreach (string var in variableList)
                {
                    colNum = var[0] - 65;       // convert ascii to index
                    rowNum = int.Parse(var[1].ToString()) - 1;

                    /* subscribe dependant cell's dependancychanged to needed cell's propertychanged */
                    targetCell.UnsubscribeDependancy(ref this.cells[colNum, rowNum]);
                    targetCell.SubscribeDependancy(ref this.cells[colNum, rowNum]);
                    targetCell.DependancyChanged += new PropertyChangedEventHandler(this.SheetDependancyChangedHandler);

                    if (double.TryParse(this.cells[colNum, rowNum].Value, out value))
                    {
                        expTree.SetVariable(var, value);
                    }
                }

                targetCell.ValueSet = expTree.Evaluate().ToString();
                Console.WriteLine(targetCell.Value);
            }
            else
            {
                targetCell.ValueSet = targetCell.Text;
            }
        }
    }
}
