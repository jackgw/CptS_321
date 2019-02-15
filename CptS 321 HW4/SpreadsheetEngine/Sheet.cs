namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            this.cells = new Cell[columns, rows];
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
        /// Returns the cell at a certain row and column index
        /// </summary>
        /// <param name="column">Column index of desired cell</param>
        /// <param name="row">Row index of desired cell</param>
        /// <returns>The cell object at given index</returns>
        public Cell GetCell(int column, int row)
        {
            return null;
        }
    }
}
