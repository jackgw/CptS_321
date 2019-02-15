namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Sheet
    {
        private Cell[,] cells;
        private int columnCount;
        private int rowCount;

        Sheet(int columns, int rows)
        {
            cells = new Cell[columns, rows];
        }

        public int ColumnCount
        {
            get { return columnCount; }
        }

        public int RowCount
        {
            get { return rowCount; }
        }

        public Cell GetCell(int column, int row)
        {
            return null;
        }
    }
}
