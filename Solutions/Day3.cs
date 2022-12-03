using System;

namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/3
    public static class Day3
    {
        public static int SolvePart1(string input)
        {
            int total = 0;
            string[] packs = input.Split('\n');
            foreach (string pack in packs)
            {
                int half = pack.Length / 2;
                string first = pack.Substring(0, half);
                string second = pack.Substring(half);

                foreach (char item in first)
                {
                    if (second.Contains(item))
                    {
                        total += item switch
                        {
                            >= 'a' and <= 'z' => item - 'a' + 1,
                            >= 'A' and <= 'Z' => item - 'A' + 27,
                            _ => throw new InvalidOperationException($"The item {item} is not valid.")
                        };
                        break;
                    }
                }
            }

            return total;
        }
    }
}
