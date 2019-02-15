namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Cell
    {
        private int columnIndex;
        private int rowIndex;
        protected string text;
        protected string value;

        public Cell()
        {

        }

        public int ColumnIndex
        {
            get { return this.columnIndex; }
        }

        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        public string Text
        {
            get { return this.text; }
            set { /* if text changed to a different value, fire property changed event */}
        }

        public string Value
        {
            get { return this.value; }
            // only spreadsheet should be allowed to change this value
        }
    }
}
