using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public static class Day6
    {
        public static int NumberOfRedistribution(string _banks)
        {
            var banks = ParseBanks(_banks);
            var states = new HashSet<string>();

            var numberOfRedistribution = GetInfiniteLoop(states, banks);

            return numberOfRedistribution;
        }

        private static int GetInfiniteLoop(ISet<string> states, int[] banks)
        {
            var numberOfRedistribution = 0;
            while (!states.Contains(GetHash(banks)))
            {
                numberOfRedistribution++;
                states.Add(GetHash(banks));
                FindMaxAndRedistribute(banks);
            }
            return numberOfRedistribution;
        }

        public static int SizeOfInfiniteLoop(string _banks)
        {
            var banks = ParseBanks(_banks);
            var states = new HashSet<string>();

            GetInfiniteLoop(states, banks);

            return states.SkipWhile(hash => !hash.Equals(GetHash(banks))).Count();
        }

        private static string GetHash(IEnumerable<int> banks)
        {
            return string.Join(" ", banks);
        }

        public static int[] ParseBanks(string banks)
        {
            return banks.Split(' ', '\t').Select(int.Parse).ToArray();
        }

        public static int[] Redistribute(int[] banks, int index, int value)
        {
            while (value-- > 0)
            {
                if (++index >= banks.Length)
                {
                    index = 0;
                }

                banks[index]++;
            }

            return banks;
        }

        public static int[] FindMaxAndRedistribute(int[] banks)
        {
            var maxIndex = 0;

            for (var i = 1; i < banks.Length; i++)
            {
                if (banks[maxIndex] < banks[i])
                {
                    maxIndex = i;
                }
            }

            var maxValue = banks[maxIndex];
            banks[maxIndex] = 0;

            return Redistribute(banks, maxIndex, maxValue);
        }
    }
}