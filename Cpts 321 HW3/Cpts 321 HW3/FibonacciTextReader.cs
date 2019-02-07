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
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Class for loading fibonacci sequence
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        private BigInteger prevNum1;
        private BigInteger prevNum2;
        private int lineNumber;
        private int maxLines;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        public FibonacciTextReader()
        {
            this.lineNumber = 0;
            this.maxLines = 100; // default value (for tests)
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLinesAvailable">The integer value of the max lines available for the file</param>
        public FibonacciTextReader(int maxLinesAvailable)
        {
            this.lineNumber = 0;
            this.maxLines = maxLinesAvailable;
        }

        /// <summary>
        /// Calculates the next number in the fibonacci sequence based on the value of this.lineNumber
        /// </summary>
        /// <returns>The next number in the fibonacci sequence as a string</returns>
        public string ReadLine()
        {
            if (this.lineNumber == 0)
            {
                this.prevNum1 = 0;
                this.lineNumber++;
                return "0";
            }
            else if (this.lineNumber == 1)
            {
                this.prevNum2 = 1;
                this.lineNumber++;
                return "1";
            }
            else
            {
                BigInteger temp = this.prevNum2;
                this.prevNum2 += this.prevNum1;
                this.prevNum1 = temp;
                this.lineNumber++;
                return this.prevNum2.ToString();
            }
        }

        /// <summary>
        /// Calls ReadLine as many times as specified by this.maxLines, and concatenates results to a single string
        /// </summary>
        /// <returns>a string </returns>
        public string ReadToEnd()
        {
            string allLines = string.Empty;
            this.lineNumber = 0;
            while (this.lineNumber < this.maxLines)
            {
                allLines += this.ReadLine() + "\r\n";
            }

            return allLines;
        }

        /// <summary>
        /// Tests the ability of ReadLine to generate the first 10 elements of the fibonacci sequence
        /// </summary>
        [Test]
        public void First10_FibonacciTest()
        {
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "0");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "1");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "1");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "2");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "3");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "5");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "8");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "13");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "21");
            StringAssert.AreEqualIgnoringCase(this.ReadLine(), "34");
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

        /// <summary>
        /// Tests the output of the ReadToEnd function when maxLines is set to 5
        /// </summary>
        [Test]
        public void ReadAllLinesTest()
        {
            this.maxLines = 5;
            StringAssert.AreEqualIgnoringCase(this.ReadToEnd(), "0\r\n1\r\n1\r\n2\r\n3\r\n");
        }
    }
}
