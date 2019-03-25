// <copyright file="Form1.cs" company="PlaceholderCompany">
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
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NUnit.Framework;

    /// <summary>
    /// Form class managing the winForms window
    /// </summary>
    public partial class Form1 : Form
    {
        public Sheet spreadsheet = new Sheet(26, 50);

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Resizes the Window to 800x600
        /// Adds columns A-Z and rows 1-50 to the grid
        /// </summary>
        public Form1()
        {
            char letter = 'A';
            this.spreadsheet.CellPropertyChanged += new PropertyChangedEventHandler(this.SheetEventHandler);

            this.InitializeComponent();

            /* Setup Event Handlers for CellEndEdit and CellBeginEdit */
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);

            /* Resize form window */
            this.Size = new System.Drawing.Size(800, 600);

            /* Create columns A through Z */
            for (letter = 'A'; letter != '['; letter++)
            {
                this.dataGridView1.Columns.Add(letter.ToString(), letter.ToString());
            }

            /* Create rows 1 through 50 */
            this.dataGridView1.Rows.Add(50);
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            /* Display text */
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.spreadsheet.GetCell(e.ColumnIndex, e.RowIndex).Text;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.spreadsheet.ChangeText(e.RowIndex, e.ColumnIndex, (string)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void SheetEventHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                /* Update specific cell to new value */
                case "text":
                    this.dataGridView1.Rows[((Cell)sender).RowIndex].Cells[((Cell)sender).ColumnIndex].Value = ((Cell)sender).Value;
                    break;
                case "value":
                    this.dataGridView1.Rows[((Cell)sender).RowIndex].Cells[((Cell)sender).ColumnIndex].Value = ((Cell)sender).Value;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Creates a test Sheet class, and uses the GetCell() method to test whether ChangeText() worked correctly.
        /// </summary>
        [Test]
        public void CellTextChangedTest()
        {
            Sheet testSheet = new Sheet(26, 50);
            testSheet.ChangeText(5, 5, "Test String");
            Cell testCell = testSheet.GetCell(5, 5);
            StringAssert.AreEqualIgnoringCase("Test String", testCell.Text);
        }

        /// <summary>
        /// Creates a test Sheet class, and tests whether entering '=B15' as the text of a cell changes the text to that of B15
        /// </summary>
        [Test]
        public void ValueCalculatedTest()
        {
            Sheet testSheet = new Sheet(26, 50);
            testSheet.ChangeText(1, 15, "cell b15 text"); // cell B 15
            testSheet.ChangeText(2, 5, "=B15"); // set cell C 5 to the value of cell B 15
            StringAssert.AreEqualIgnoringCase(testSheet.GetCell(1, 15).Text, testSheet.GetCell(2, 5).Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* DEMO */
            int i;
            int col, row;
            Random rand = new Random();
            for (i = 0; i < 50; i++)
            {
                col = rand.Next(0, 25);
                row = rand.Next(0, 49);
                this.spreadsheet.ChangeText(row, col, "Hello World!");
            }

            for (i = 0; i < 50; i++)
            {
                this.spreadsheet.ChangeText(i, 1, "This is cell B" + (i + 1).ToString());
            }

            for (i = 0; i < 50; i++)
            {
                this.spreadsheet.ChangeText(i, 0, "=B" + (i + 1).ToString());
            }
        }
    }
}
