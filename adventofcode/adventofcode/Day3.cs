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

        public class State
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int R { get; set; }
            public int S { get; set; }
            public Direction D { get; set; }
            public int[,] Matrix { get; set; }

            public int Value
            {
                get => Matrix[X, Y];
                set => Matrix[X, Y] = value;
            }

            public int GetSum()
            {
                var sum = 0;
                for (var i = X - 1; i <= X + 1; i++)
                {
                    for (var j = Y - 1; j <= Y + 1; j++)
                    {
                        sum += Matrix[i, j];
                    }
                }
                return sum;
            }

            public void Move()
            {
                Movements[D](this);
            }
        }

        public static readonly IDictionary<Direction, Action<State>> Movements = new Dictionary<Direction, Action<State>>
        {
            {Direction.Right, GoRight},
            {Direction.Up, GoUp},
            {Direction.Left, GoLeft},
            {Direction.Down, GoDown}
        };

        public static int GetFirstLarger(int number)
        {
            var state = new State
            {
                R = 1,
                S = 0,
                D = Direction.Right,
                Matrix = new int[20, 20],
                X = 10,
                Y = 10,
                Value = 1
            };

            do
            {
                state.Move();
                state.Value = state.GetSum();
            } while (state.Value < number);

            return state.Value;
        }

        private static void GoRight(State state)
        {
            state.S++;
            state.Y++;

            if (state.S != state.R) return;

            state.D = Direction.Up;
            state.S = 0;
        }

        private static void GoDown(State state)
        {
            state.S++;
            state.X++;

            if (state.S != state.R) return;

            state.D = Direction.Right;
            state.S = 0;
            state.R++;
        }

        private static void GoLeft(State state)
        {
            state.S++;
            state.Y--;

            if (state.S != state.R) return;

            state.D = Direction.Down;
            state.S = 0;
        }

        private static void GoUp(State state)
        {
            state.S++;
            state.X--;

            if (state.S != state.R) return;

            state.D = Direction.Left;
            state.S = 0;
            state.R++;
        }
    }
}
