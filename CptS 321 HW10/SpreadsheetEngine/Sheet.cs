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
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
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
                    this.cells[i, j].PropertyChanged += new PropertyChangedEventHandler(this.OnCellPropertyChanged);
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
        /// <param name="colIndex">Column Index</param>
        /// <param name="rowIndex">Row index</param>
        /// <param name="newText">New cell text</param>
        /// <returns>True if cell found, false otherwise</returns>
        public bool ChangeText(int colIndex, int rowIndex, string newText)
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
        /// Changes the BG color of the specified cell
        /// </summary>
        /// <param name="colIndex">Column index</param>
        /// <param name="rowIndex">Row index</param>
        /// <param name="colorVal">New background color as a uint</param>
        /// <returns>True if changed successfully, false otherwise</returns>
        public bool ChangeBGColor(int colIndex, int rowIndex, uint colorVal)
        {
            if (this.cells[colIndex, rowIndex] != null)
            {
                this.cells[colIndex, rowIndex].BGColor = colorVal;
                return true;
            }

            return false;
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
        /// Saves the current contents of the spreadsheet to an XML document, given a pathname
        /// </summary>
        /// <param name="filename">Pathname of the xml file</param>
        public void SaveXML(string filename)
        {
            XmlWriter outfile = XmlWriter.Create(filename);

            outfile.WriteStartDocument();
            outfile.WriteStartElement("cells");

            foreach (Cell cell in this.cells)
            {
                /* If cells attributues are not the default values */
                if (cell.Text != string.Empty || cell.BGColor != 0xFFFFFFFF)
                {
                    outfile.WriteStartElement("cell");

                    outfile.WriteAttributeString("row", cell.RowIndex.ToString());
                    outfile.WriteAttributeString("col", cell.ColumnIndex.ToString());

                    outfile.WriteStartElement("BGColor");
                    outfile.WriteString(cell.BGColor.ToString());
                    outfile.WriteEndElement();

                    outfile.WriteStartElement("Text");
                    outfile.WriteString(cell.Text);
                    outfile.WriteEndElement();

                    outfile.WriteEndElement();
                }
            }

            outfile.WriteEndElement();
            outfile.WriteEndDocument();

            outfile.Close();
        }

        /// <summary>
        /// Clears the contents of the spreadsheet and loads the contents of an xml file into the cells
        /// </summary>
        /// <param name="filename">Pathname of the xml file</param>
        public void LoadXML(string filename)
        {
            Cell tempCell = new SpreadsheetCell(-1, -1);

            XmlReader infile = XmlReader.Create(filename);

            /* Clear all cells */
            foreach (Cell cell in this.cells)
            {
                cell.BGColor = 0xFFFFFFFF;
                cell.Text = string.Empty;
            }

            while (!infile.EOF)
            {
                if (infile.NodeType == XmlNodeType.Element && infile.Name == "cell")
                {
                    tempCell = this.cells[int.Parse(infile.GetAttribute("col")), int.Parse(infile.GetAttribute("row"))];
                    infile.Read();
                }
                else if (infile.NodeType == XmlNodeType.Element && infile.Name == "BGColor")
                {
                    tempCell.BGColor = uint.Parse(infile.ReadElementContentAsString());
                }
                else if (infile.NodeType == XmlNodeType.Element && infile.Name == "Text")
                {
                    tempCell.Text = infile.ReadElementContentAsString();
                }
                else
                {
                    infile.Read();
                }
            }

            infile.Close();
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

            if (this.CellPropertyChanged != null)
            {
                this.CellPropertyChanged(sender, e);
            }
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

                foreach (string var in variableList)
                {
                    /* Check non-empty */
                    if (var == string.Empty)
                    {
                        targetCell.ValueSet = "!(Empty Reference)";
                        return;
                    }

                    colNum = var[0] - 65;       // convert ascii to index

                    /* check parseable */
                    if (int.TryParse(var.TrimStart(var[0]), out rowNum))
                    {
                        rowNum -= 1;
                    }
                    else
                    {
                        targetCell.ValueSet = "!(Invalid Reference)";
                        return;
                    }

                    /* Check out of bounds */
                    if ((colNum > this.ColumnCount || colNum < 0) || (rowNum > this.rowCount || rowNum < 0))
                    {
                        targetCell.ValueSet = "!(Out of Bounds)";
                        return;
                    }

                    /* Check for self reference */
                    if (targetCell.RowIndex == rowNum && targetCell.ColumnIndex == colNum)
                    {
                        targetCell.ValueSet = "!(Self Reference)";
                        return;
                    }

                    /* Check for Circular Reference */
                    try
                    {
                        this.CheckCircularRef(targetCell, this.cells[colNum, rowNum]);
                    }
                    catch (CircularReferenceException)
                    {
                        targetCell.ValueSet = "!(Circular Reference)";
                        return;
                    }

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
            }
            else
            {
                targetCell.ValueSet = targetCell.Text;
            }
        }

        /// <summary>
        /// Recursively checks all cells upon which a given cell is dependant to see if any are equal to the base cell
        /// </summary>
        /// <param name="baseCell">base cell for comparison</param>
        /// <param name="currentCell">current cell in the recursion cycle</param>
        private void CheckCircularRef(Cell baseCell, Cell currentCell)
        {
            if (currentCell == baseCell)
            {
                throw new CircularReferenceException();
            }
            else
            {
                /* Has an expression */
                if (currentCell.Text != string.Empty && currentCell.Text[0] == '=')
                {
                    ExpressionTree expTree = new ExpressionTree(currentCell.Text.TrimStart('='));
                    List<string> variableList = expTree.GetVariableNames();

                    foreach (string var in variableList)
                    {
                        int colNum = var[0] - 65;
                        int rowNum = int.Parse(var[1].ToString()) - 1;

                        this.CheckCircularRef(baseCell, this.cells[colNum, rowNum]);
                    }
                }
            }
        }
    }
}
