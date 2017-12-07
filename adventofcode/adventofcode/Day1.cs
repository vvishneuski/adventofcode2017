using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public static class Day1
    {
        public static IEnumerable<int> ParseSequence(string sequence)
        {
            return sequence.Select(c => (int) char.GetNumericValue(c));
        }

        private static LinkedListNode<int> GetNext(LinkedListNode<int> node, int step = 1)
        {
            for (var i = 0; i < step; i++)
            {
                node = node.Next ?? node.List.First;
            }
            return node;
        }

        public static int GetSum(string sequence, int step = 1)
        {
            var list = new LinkedList<int>(ParseSequence(sequence));
            var node = list.First;

            var sum = 0;
            do
            {
                if (node.Value == GetNext(node, step).Value)
                    sum += node.Value;
                node = GetNext(node);
            } while (node != list.First);

            return sum;
        }

        private static int GetStep(string sequence)
        {
            return sequence.Length / 2;
        }

        public static int GetSumWithStep(string sequence)
        {
            return GetSum(sequence, GetStep(sequence));
        }
    }
}
