namespace CptS_321_HW4
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
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Resizes the Window to 800x600
        /// Adds columns A-Z and rows 1-50 to the grid
        /// </summary>
        public Form1()
        {
            Sheet spreadsheet = new Sheet(26, 50);

            char letter = 'A';

            this.InitializeComponent();

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
    }
}
