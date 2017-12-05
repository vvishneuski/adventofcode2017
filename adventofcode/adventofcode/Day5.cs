using System;

namespace adventofcode
{
    public static class Day5
    {
        public static int HowManyStepsWhileExit(int[] list, Func<int[], int, int> getOffset)
        {
            var i = 0;
            var step = 0;
            while (0 <= i && i < list.Length)
            {
                i += getOffset(list, i);
                step++;
            }
            return step;
        }

        public static int GetOffset(int[] list, int i)
        {
            return list[i]++;
        }

        public static int GetAnotherOffset(int[] list, int i)
        {
            return list[i] < 3 ? list[i]++ : list[i]--;
        }
    }
}
