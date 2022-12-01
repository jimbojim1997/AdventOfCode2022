using System;
using System.Linq;

namespace AdventOfCode2022.Solutions.Day1
{
    public static class Solution
    {
        public static int SolvePart1(string input)
        {
            return input.Split("\n\n")
                        .Select(e => e.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(c => int.Parse(c))
                                      .Sum())
                        .Max();
        }

        public static int SolvePart2(string input)
        {
            return input.Split("\n\n")
                        .Select(e => e.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(c => int.Parse(c))
                                      .Sum())
                        .OrderByDescending(n => n)
                        .Take(3)
                        .Sum();
        }
    }
}
