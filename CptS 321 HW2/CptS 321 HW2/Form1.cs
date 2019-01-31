﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace CptS_321_HW2
{
    /// <summary>
    /// Class for the form window, managing input and controling output.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes the form window.
        /// </summary>
        public Form1()
        {
            int[] userArray = new int[10000];
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Test";
        }
    }
}
