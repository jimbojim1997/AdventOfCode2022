using System;
using System.Collections.Generic;

namespace AdventOfCode2022.Solutions
{
    public static class Day9
    {
        public static int SolvePart1(string input)
        {
            (int x, int y) head = (0, 0);
            (int x, int y) tail = (0, 0);

            var touchedPositions = new HashSet<(int, int)> { tail };
            foreach (var instruction in input.Split('\n'))
            {
                string[] parts = instruction.Split(' ');
                string direction = parts[0];
                int.TryParse(parts[1], out int count);

                for (int i = 0; i < count; i++)
                {
                    switch (direction)
                    {
                        case "U":
                            head = (head.x, head.y + 1);
                            break;
                        case "D":
                            head = (head.x, head.y - 1);
                            break;
                        case "L":
                            head = (head.x - 1, head.y);
                            break;
                        case "R":
                            head = (head.x + 1, head.y);
                            break;
                    }

                    if (Diff(head.x, tail.x) > 1 || Diff(head.y, tail.y) > 1)
                    {
                        tail = (tail.x + Math.Sign(head.x - tail.x), tail.y + Math.Sign(head.y - tail.y));
                        touchedPositions.Add(tail);
                    }
                }
            }

            return touchedPositions.Count;
        }

        public static int Diff(int a, int b)
        {
            if (a > b) return a - b;
            else return b - a;
        }
    }
}
