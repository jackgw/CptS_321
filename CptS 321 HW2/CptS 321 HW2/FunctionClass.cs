namespace CptS_321_HW2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Function Class conatining implementation for pupulating a user array with random integers and
    /// three different methods of counting the number of distinct numbers in the array.
    /// </summary>
    public class FunctionClass
    {
        private Random randInt = new Random();

        /// <summary>
        /// Populates a user array with 10,000 random values by calling private GenerateRandomInt()
        /// </summary>
        /// <param name="userArray"> An array of integers </param>
        public void PopulateArrayRandom(int[] userArray)
        {
            int i = 0;
            while (i < 10000)
            {
                userArray[i] = this.GenerateRandomInt();
                i++;
            }

            return;
        }

        /// <summary>
        /// Counts distinct ints using Hash Table.
        /// </summary>
        /// <param name="userArray"> input parameter userArray as an array of integers </param>
        /// <returns> Returns the number of distinct integers in the parameter array as an int </returns>
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 3, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, 20000 }, ExpectedResult = 2)]
        public int CountDistinctHash(int[] userArray)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int element in userArray)
            {
                set.Add(element);
            }

            return set.Count;
        }

        /// <summary>
        /// Counts Distinct ints using O(1) storage complexity without modifying the list.
        /// </summary>
        /// <param name="userArray"> input parameter userArray as an array of integers </param>
        /// <returns> Returns the number of distinct integers in the parameter array as an int </returns>
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 3, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, 20000 }, ExpectedResult = 2)]
        public int CountDistinctConstant(int[] userArray)
        {
            int count = 0;
            int[] valueOccurences = new int[20001]; // Size of this array is constant for all sizes of userArray.
            foreach (int element in userArray)
            {
                valueOccurences[element]++;
            }

            foreach (int element in valueOccurences)
            {
                if (element != 0)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Counts Distinct ints using built in Sort function.
        /// </summary>
        /// <param name="userArray"> input parameter userArray as an array of integers </param>
        /// <returns> Returns the number of distinct integers in the parameter array as an int </returns>
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 3, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, 20000 }, ExpectedResult = 2)]
        public int CountDistinctSort(int[] userArray)
        {
            int prevElement = -1;
            int count = 0;
            List<int> newArray = userArray.ToList<int>();
            newArray.Sort();
            foreach (int element in newArray)
            {
                if (element != prevElement)
                {
                    prevElement = element;
                    count++;
                }
            }

            return count;
        }

        private int GenerateRandomInt()
        {
            return this.randInt.Next(0, 20001);
        }
    }
}
