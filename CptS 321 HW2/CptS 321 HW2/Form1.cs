//-----------------------------------------------------------------
// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------
// Jack Wharton 11506329

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
        // Variables to store the return values of the 3 different count distinct methods.
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
            this.textBox1.Text = "1. HashSet Method: " + this.distinctHash.ToString() +
                "\r\n\r\nIn this implementation, for each item in the initial array, the HashSet function add() is called. add() has a time complexity of O(1) as with a hash function only one comparison is needed for any insertion. This happens N times, so the overall time complexity of the method is O(N).\r\n" +
                "\r\n2. O(1) Storage Method: " + this.distinctConstant.ToString() +
                "\r\n\r\nWhile this implementation requires a traversal through the initial array and a traversal through an additional array, the size of the second array is fixed (at 20,000 items), so the method has a time complexity of O(N) and a space complexity of just O(1) not including the space allocated to the initial array.\r\n" +
                "\r\n3. Sort Method: " + this.distinctSort.ToString();
        }
    }
}
