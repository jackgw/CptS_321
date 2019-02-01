﻿namespace CptS_321_HW2
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
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "Test";
        }
    }
}
