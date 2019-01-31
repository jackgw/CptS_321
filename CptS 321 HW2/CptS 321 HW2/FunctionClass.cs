using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CptS_321_HW2
{
    /// <summary>
    /// Function Class conatining implementation for pupulating a user array with random integers and
    /// three different methods of counting the number of distinct numbers in the array.
    /// </summary>
    public class FunctionClass
    {
        private int GenerateRandomInt()
        {
            Random randInt = new Random();
            return randInt.Next(0, 20000);
        }

        /// <summary>
        /// Populates a user array with 10,000 random values by calling private GenerateRandomInt()
        /// </summary>
        public void PopulateArrayRandom(int[] userArray)
        {
            return;
        }

        /// <summary>
        /// Counts distinct ints using Hash Table
        /// </summary>
        /// <param name="userArray"> input parameter userArray as an array of integers </param>
        /// <returns> Returns the number of distinct integers in the parameter array as an int </returns>
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 3, 3 }, ExpectedResult = 3)]
        public int CountDistinctHash(int[] userArray)
        {
            return 0;
        }

        /// <summary>
        /// Counts Distinct ints using O(1) insertion
        /// </summary>
        /// <param name="userArray"> input parameter userArray as an array of integers </param>
        /// <returns> Returns the number of distinct integers in the parameter array as an int </returns>
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 3, 3 }, ExpectedResult = 3)]
        public int CountDistinctSet(int[] userArray)
        {
            return 0;
        }

        /// <summary>
        /// Counts Distinct ints using built in Sort function
        /// </summary>
        /// <param name="userArray"> input parameter userArray as an array of integers </param>
        /// <returns> Returns the number of distinct integers in the parameter array as an int </returns>
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 3, 3 }, ExpectedResult = 3)]
        public int CountDistinctSort(int[] userArray)
        {
            return 0;
        }
    }
}
