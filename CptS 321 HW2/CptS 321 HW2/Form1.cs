namespace CptS_321_HW2
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
    /// Class for the form window, managing input and controling output.
    /// </summary>
    public partial class Form1 : Form
    {
        private int distinctHash = 0;
        private int distinctConstant = 0;
        private int distinctSort = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            int[] userArray = new int[10000];
            FunctionClass utilityFunction = new FunctionClass();

            utilityFunction.PopulateArrayRandom(userArray);
            this.distinctHash = utilityFunction.CountDistinctHash(userArray);
            this.distinctConstant = utilityFunction.CountDistinctConstant(userArray);
            this.distinctSort = utilityFunction.CountDistinctSort(userArray);

            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "HashSet Method: " + this.distinctHash.ToString() +
                "\r\nO(1) Storage Method: " + this.distinctConstant.ToString() +
                "\r\nSort Method: " + this.distinctSort.ToString();
        }
    }
}
