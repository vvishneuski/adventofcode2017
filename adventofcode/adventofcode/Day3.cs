using System;
using System.Collections.Generic;

namespace adventofcode
{
    public static class Day3
    {
        private static readonly IList<Func<int, int, int>> Tools =
            new List<Func<int, int, int>> {GetLegDistance, GetHandDistance};

        public static int GetDistance(int number)
        {
            var root = GetRoot(number);

            if (GetBranch(root) == number)
                return root - 1;

            return number < GetBranch(root) ? GetLegDistance(number, root) : GetHandDistance(number, root);
        }

        private static int GetLegDistance(int number, int root)
        {
            var knee = root / 2 + 1;
            var leg = GetBranch(root) - number;

            if (leg <= root - knee)
                return root - 1 - leg;

            return leg + GetLeaf(root);
        }

        private static int GetHandDistance(int number, int root)
        {
            var elbow = root / 2 + 1;
            var hand = number - GetBranch(root);

            if (hand <= elbow)
                return root + 1 - hand;

            return hand - GetLeaf(root);
        }

        private static int GetLeaf(int root)
        {
            return root % 2 == 0 ? 1 : 0;
        }

        private static int GetBranch(int root)
        {
            return (int) Math.Pow(root, 2);
        }

        private static int GetRoot(int number)
        {
            return (int) Math.Round(Math.Sqrt(number));
        }

        public static int GetFirstLarger(int number)
        {
            return number;
        }
    }
}
