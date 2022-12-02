using System;
using System.ComponentModel.Design;

namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/2
    public static class Day2
    {
        public static int SolvePart1(string input)
        {
            int totalScore = 0;
            foreach(string line in input.Split("\n"))
            {
                string[] hands = line.Split(' ');
                string a = hands[0];
                string b = hands[1];

                if ((a == "A" && b == "X") || (a == "B" && b == "Y") || (a == "C" && b == "Z")) totalScore += 3;
                else if ((a == "A" && b == "Y") || (a == "B" && b == "Z") || (a == "C" && b == "X")) totalScore += 6;

                totalScore += b switch
                {
                    "X" => 1,
                    "Y" => 2,
                    "Z" => 3,
                    _ => throw new InvalidOperationException($"The hand {hands[1]} is not valid.")
                };
            }

            return totalScore;
        }
    }
}
