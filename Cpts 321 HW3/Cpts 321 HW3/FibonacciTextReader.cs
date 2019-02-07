//-----------------------------------------------------------------
// <copyright file="FibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------
// Jack Wharton
// 11506329

namespace Cpts_321_HW3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Class for loading fibonacci sequence
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        private int prevNum1;
        private int prevNum2;
        private int lineNumber;
        private int maxLines;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLinesAvailable">The integer value of the max lines available for the file</param>
        public FibonacciTextReader(int maxLinesAvailable)
        {

        }

        /// <summary>
        /// Calculates the next number in the fibonacci sequence based on the value of this.lineNumber
        /// </summary>
        /// <returns>The next number in the fibonacci sequence as a string</returns>
        public string ReadLine()
        {

        }

        /// <summary>
        /// Calls ReadLine as many times as specified by this.maxLines, and concatenates results to a single string
        /// </summary>
        /// <returns>a string </returns>
        public string ReadToEnd()
        {

        }

        /// <summary>
        /// Tests the ability of ReadLine to generate the first 10 elements of the fibonacci sequence
        /// </summary>
        [Test]
        public void First10_FibonacciTest()
        {
            Assert.AreEqual(int.Parse(this.ReadLine()), 0);
            Assert.AreEqual(int.Parse(this.ReadLine()), 1);
            Assert.AreEqual(int.Parse(this.ReadLine()), 1);
            Assert.AreEqual(int.Parse(this.ReadLine()), 2);
            Assert.AreEqual(int.Parse(this.ReadLine()), 3);
            Assert.AreEqual(int.Parse(this.ReadLine()), 5);
            Assert.AreEqual(int.Parse(this.ReadLine()), 8);
            Assert.AreEqual(int.Parse(this.ReadLine()), 13);
            Assert.AreEqual(int.Parse(this.ReadLine()), 21);
            Assert.AreEqual(int.Parse(this.ReadLine()), 34);
        }

        /// <summary>
        /// Verifies that the number of fibonacci items returned by ReadToEnd matches the given max lines
        /// </summary>
        [Test]
        public void TotalLinesTest()
        {
            this.maxLines = 10;
            this.ReadToEnd();
            Assert.AreEqual(this.lineNumber, this.maxLines);
        }
    }
}
