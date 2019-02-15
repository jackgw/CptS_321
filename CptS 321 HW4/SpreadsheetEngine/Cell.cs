namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Abstract class representing a single spreadsheet cell
    /// </summary>
    public abstract class Cell
    {
        private int columnIndex;
        private int rowIndex;
        private string text;
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell()
        {
            // Initialize cell
        }

        /// <summary>
        /// Gets the column index of the cell
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
        }

        /// <summary>
        /// Gets the row index of the cell
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets or sets the text contained in the cell
        /// If the text is changed, then fire property changed event
        /// </summary>
        public string Text
        {
            get { return this.text; }
            set { /* if text changed to a different value, fire property changed event */ }
        }

        /// <summary>
        /// Gets the value of the cell
        /// </summary>
        public string Value
        {
            get { return this.value; }

            // only spreadsheet should be allowed to change this value
        }
    }
}
