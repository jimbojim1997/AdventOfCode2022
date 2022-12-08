using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/8
    public static class Day8
    {
        public static int SolvePart1(string input)
        {
            var forrest = BuildForrest(input);
            SetVisibilities(forrest);

            int result = 0;
            foreach(Tree tree in forrest)
            {
                if (tree.Visible) result++;
            }

            return result;
        }

        private static Tree[,] BuildForrest(string input)
        {
            var lines = input.Split('\n');

            int xMax = lines[0].Length;
            int yMax = lines.Length;

            Tree[,] trees = new Tree[xMax, yMax];

            for (int y = 0; y < yMax; y++)
            {
                string line = lines[y];
                for (int x = 0; x < xMax; x++)
                {
                    byte height = byte.Parse(line.Substring(x, 1));
                    trees[x, y] = new Tree(height, false);
                }
            }

            return trees;
        }

        private static void SetVisibilities(Tree[,] forrest)
        {
            int xMax = forrest.GetLength(0);
            int yMax = forrest.GetLength(1);
            int maxHeight;

            //from top
            for (int x = 0; x < xMax; x++)
            {
                maxHeight = -1;
                for (int y = 0; y < yMax; y++)
                {
                    Tree current = forrest[x, y];
                    if (current.Height > maxHeight)
                    {
                        maxHeight = current.Height;
                        forrest[x, y] = new Tree(current.Height, true);
                    }
                }
            }

            //from bottom
            for (int x = 0; x < xMax; x++)
            {
                maxHeight = -1;
                for (int y = yMax - 1; y >= 0; y--)
                {
                    Tree current = forrest[x, y];
                    if (current.Height > maxHeight)
                    {
                        maxHeight = current.Height;
                        forrest[x, y] = new Tree(current.Height, true);
                    }
                }
            }

            //from left
            for (int y = 0; y < yMax; y++)
            {
                maxHeight = -1;
                for (int x = 0; x < xMax; x++)
                {
                    Tree current = forrest[x, y];
                    if (current.Height > maxHeight)
                    {
                        maxHeight = current.Height;
                        forrest[x, y] = new Tree(current.Height, true);
                    }
                }
            }

            //from right
            for (int y = 0; y < yMax; y++)
            {
                maxHeight = -1;
                for (int x = xMax - 1; x >= 0; x--)
                {
                    Tree current = forrest[x, y];
                    if (current.Height > maxHeight)
                    {
                        maxHeight = current.Height;
                        forrest[x, y] = new Tree(current.Height, true);
                    }
                }
            }
        }

        [DebuggerDisplay("{Height} {Visible}")]
        private struct Tree
        {
            public readonly byte Height;
            public readonly bool Visible;

            public Tree(byte height, bool visible)
            {
                Height = height;
                Visible = visible;
            }
        }
    }
}
