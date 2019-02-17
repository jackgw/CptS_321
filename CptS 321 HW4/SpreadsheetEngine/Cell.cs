namespace CptS_321_HW4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the 'Absract Product' creating the framework of a cell
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Event signifying the changing of a cell text
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the column index of the cell
        /// </summary>
        public abstract int ColumnIndex { get; }

        /// <summary>
        /// Gets the row index of the cell
        /// </summary>
        public abstract int RowIndex { get; }

        /// <summary>
        /// Gets or sets the text contained in the cell
        /// If the text is changed, then fire property changed event
        /// </summary>
        public abstract string Text { get; set; }

        /// <summary>
        /// Gets the value of the cell
        /// </summary>
        public abstract string Value { get; }

        /// <summary>
        /// Sets the value variable. Only visable to Sheet class.
        /// </summary>
        internal abstract string ValueSet { set; }

        /// <summary>
        /// Executes the propertyChanged event.
        /// </summary>
        /// <param name="name">Type of property changed</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    /// <summary>
    /// 'Concrete Product' implementation of the Cell class
    /// </summary>
    internal class SpreadsheetCell : Cell
    {
        private int columnIndex;
        private int rowIndex;
        private string text;
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="columnNum">Column the cell is in</param>
        /// <param name="rowNum">Row the cell is in</param>
        public SpreadsheetCell(int columnNum, int rowNum)
        {
            this.columnIndex = columnNum;
            this.rowIndex = rowNum;
            this.text = string.Empty;
            this.value = string.Empty;
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
                    this.OnPropertyChanged(this.text);
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
            set { this.value = value; }
        }
    }
}
