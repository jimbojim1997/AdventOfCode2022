using System;

namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/6
    public static class Day6
    {
        public static int SolvePart1(string input)
        {
            int duplicates = 0;
            for(int i = 0; i < input.Length; i++)
            {
                for(int b = 1; b <= 3 && i - b >= 0; b++)
                {
                    if (input[i] == input[i - b])
                    {
                        duplicates |= 1 << b;
                        break;
                    }
                }

                if (i > 3 && (duplicates & 0b1111) == 0) return i + 1;

                duplicates <<= 1;
            }

            throw new InvalidOperationException("Input doesn't contain a valid start-of-packet marker.");
        }
    }
}
