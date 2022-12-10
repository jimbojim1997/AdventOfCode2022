using System;

namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/2
    public static class Day02
    {
        public static int SolvePart1(string input)
        {
            int totalScore = 0;
            foreach (string line in input.Split("\n"))
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
                    _ => throw new InvalidOperationException($"The hand {b} is not valid.")
                };
            }

            return totalScore;
        }

        public static int SolvePart2(string input)
        {
            int totalScore = 0;
            foreach (string line in input.Split("\n"))
            {
                string[] hands = line.Split(' ');
                string a = hands[0];
                string b = hands[1];
                string c;

                if (b == "X")
                {
                    c = a switch
                    {
                        "A" => "Z",
                        "B" => "X",
                        "C" => "Y",
                        _ => throw new InvalidOperationException($"The hand {a} is not valid.")
                    };
                }
                else if (b == "Y")
                {
                    totalScore += 3;
                    c = a switch
                    {
                        "A" => "X",
                        "B" => "Y",
                        "C" => "Z",
                        _ => throw new InvalidOperationException($"The hand {a} is not valid.")
                    };
                }
                else
                {
                    totalScore += 6;
                    c = a switch
                    {
                        "A" => "Y",
                        "B" => "Z",
                        "C" => "X",
                        _ => throw new InvalidOperationException($"The hand {a} is not valid.")
                    };
                }

                totalScore += c switch
                {
                    "X" => 1,
                    "Y" => 2,
                    "Z" => 3,
                    _ => throw new InvalidOperationException($"The hand {c} is not valid.")
                };
            }

            return totalScore;
        }
    }
}
