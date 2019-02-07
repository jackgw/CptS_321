//-----------------------------------------------------------------
// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------
// Jack Wharton
// 11506329

namespace Cpts_321_HW3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Primary form class, managing the window.
    /// </summary>
    public partial class Menu : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SaveDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void LoadText(TextReader sr)
        {
            this.textBox.Text = sr.ReadToEnd();
        }

        private void LoadFromFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader inFile = new StreamReader(this.openDialog.FileName);
                this.LoadText(inFile);
            }
        }

        private void LoadFibbinachiSequence50_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load 50 fibonacci items
        }

        private void LoadFibonacciSequence100_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load 100 fibonacci items
        }

        private void SaveToFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(this.saveDialog.FileName, this.textBox.Text);
            }
        }
    }
}
