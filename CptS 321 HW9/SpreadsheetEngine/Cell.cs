// <copyright file="Cell.cs" company="PlaceholderCompany">
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
    /// the 'Absract Product' creating the framework of a cell
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Bakcground color of the cell
        /// </summary>
        protected uint bgcolor;

        /// <summary>
        /// Column index field
        /// </summary>
        protected int columnIndex;

        /// <summary>
        /// Row index field
        /// </summary>
        protected int rowIndex;

        /// <summary>
        /// Text of the cell
        /// </summary>
        protected string text;

        /// <summary>
        /// Value of the cell
        /// </summary>
        protected string value;

        /// <summary>
        /// Event signifying the changing of a cell text
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// subscribed via the sheet
        /// </summary>
        public event PropertyChangedEventHandler DependancyChanged;

        /// <summary>
        /// Gets or sets the background color
        /// </summary>
        public abstract uint BGColor { get; set; }

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
        /// Subscribes the dependancy changed event handler of the cell to the property changed of another cell
        /// </summary>
        /// <param name="target">The cell which will be subscribed to</param>
        public void SubscribeDependancy(ref Cell target)
        {
            target.PropertyChanged += new PropertyChangedEventHandler(this.DependancyChangedHandler);
        }

        /// <summary>
        /// Unsubscribes the dependancy changed event handler of the cell to the property changed of another cell
        /// </summary>
        /// <param name="target">The cell which will be unsubscribed to</param>
        public void UnsubscribeDependancy(ref Cell target)
        {
            target.PropertyChanged -= new PropertyChangedEventHandler(this.DependancyChangedHandler);
        }

        /// <summary>
        /// Executes the propertyChanged event.
        /// </summary>
        /// <param name="name">Type of property changed</param>
        protected virtual void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Catches a property changed event and executes the Dependancy Changed event
        /// </summary>
        /// <param name="sender">the object that threw the property changed event</param>
        /// <param name="e">property changed event argument</param>
        protected void DependancyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (this.DependancyChanged != null)
            {
                this.DependancyChanged(this, e);
            }
        }
    }
}
