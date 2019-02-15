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
    }
}
