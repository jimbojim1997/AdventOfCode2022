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

        public static int SolvePart2(string input)
        {
            (int x, int y)[] nodes = new (int, int)[10];

            var touchedPositions = new HashSet<(int, int)> { (0, 0) };
            foreach (var instruction in input.Split('\n'))
            {
                string[] parts = instruction.Split(' ');
                string direction = parts[0];
                int.TryParse(parts[1], out int count);

                for (int i = 0; i < count; i++)
                {
                    var head = nodes[0];
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
                    nodes[0] = head;

                    for (int n = 1; n < nodes.Length; n++)
                    {
                        var current = nodes[n];
                        var previus = nodes[n - 1];

                        if (Diff(previus.x, current.x) > 1 || Diff(previus.y, current.y) > 1)
                        {
                            current = (current.x + Math.Sign(previus.x - current.x), current.y + Math.Sign(previus.y - current.y));
                            nodes[n] = current;

                            if (n == nodes.Length - 1) touchedPositions.Add(current);
                        }
                    }
                }
            }

            return touchedPositions.Count;
        }

        private static int Diff(int a, int b)
        {
            if (a > b) return a - b;
            else return b - a;
        }
    }
}
