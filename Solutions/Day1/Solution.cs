﻿namespace AdventOfCode2022.Solutions.Day1
{
    public static class Solution
    {
        public static int SolvePart1(string input)
        {
            int maxValue = int.MinValue;
            int maxIndex = 0;

            int currentValue = 0;
            int currentIndex = 1;

            string[] lines = input.Split('\n');
            foreach (string line in lines)
            {
                if (line == "")
                {
                    if (currentValue > maxValue)
                    {
                        maxValue = currentValue;
                        maxIndex = currentIndex;
                    }

                    currentValue = 0;
                    currentIndex++;
                }
                else if (int.TryParse(line, out int value))
                {
                    currentValue += value;
                }
            }

            return maxValue;
        }
    }
}
