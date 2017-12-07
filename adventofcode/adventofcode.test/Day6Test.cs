using System.Collections.Generic;
using NUnit.Framework;

namespace adventofcode.test
{
    [TestFixture]
    public class Day6Test
    {
        [TestCase("0 2 7 0", ExpectedResult = new[] { 0, 2, 7, 0 })]
        public int[] ParseBanks(string banks)
        {
            return Day6.ParseBanks(banks);
        }

        [TestCase(new[] { 0, 2, 0, 0 }, 2, 7, ExpectedResult = new[] { 2, 4, 1, 2 })]
        public int[] Redistribute(int[] banks, int index, int value)
        {
            return Day6.Redistribute(banks, index, value);
        }

        [TestCase(new[] { 0, 2, 7, 0 }, ExpectedResult = new[] { 2, 4, 1, 2 })]
        public int[] FindAndRedistribute(int[] banks)
        {
            return Day6.FindMaxAndRedistribute(banks);
        }

        [TestCase("0 2 7 0", ExpectedResult = 5)]
        [TestCase("4 1 15 12 0 9 9 5 5 8 7 3 14 5 12 3", ExpectedResult = 6681)]
        public int NumberOfRedistribution(string banks)
        {
            return Day6.NumberOfRedistribution(banks);
        }

        [TestCase("0 2 7 0", ExpectedResult = 4)]
        [TestCase("4 1 15 12 0 9 9 5 5 8 7 3 14 5 12 3", ExpectedResult = 2392)]
        public int SizeOfInfiniteLoop(string banks)
        {
            return Day6.SizeOfInfiniteLoop(banks);
        }
    }
}
