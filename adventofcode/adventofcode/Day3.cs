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

        public enum Direction
        {
            Right,
            Up,
            Left,
            Down
        }

        public static int GetFirstLarger(int number)
        {
            var matrix = new int[20, 20];

            var x = 10;
            var y = 10;
            matrix[x, y] = 1;

            var r = 1;
            var d = Direction.Right;
            var s = 0;

            do
            {
                s++;
                switch (d)
                {
                    case Direction.Right:
                        y++;
                        break;
                    case Direction.Up:
                        x--;
                        break;
                    case Direction.Left:
                        y--;
                        break;
                    case Direction.Down:
                        x++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (s == r)
                {
                    switch (d)
                    {
                        case Direction.Right:
                            d = Direction.Up;
                            break;
                        case Direction.Up:
                            d = Direction.Left;
                            r++;
                            break;
                        case Direction.Left:
                            d = Direction.Down;
                            break;
                        case Direction.Down:
                            d = Direction.Right;
                            r++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    s = 0;
                }
                matrix[x, y] = GetSum(matrix, x, y);
            } while (matrix[x,y] < number);

            return matrix[x, y];
        }

        private static int GetSum(int[,] matrix, int x, int y)
        {
            var sum = 0;
            for (int i = x-1; i <= x+1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }
    }
}
