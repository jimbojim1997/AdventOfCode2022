using System;

namespace AdventOfCode2022.Solutions
{
    public static class Day10
    {
        public static int SolvePart1(string input)
        {
            var lines = input.Split('\n');
            var enumerator = lines.GetEnumerator();

            int result = 0;
            string[] instruction = Array.Empty<string>();
            int cyclesRaminaing = 0;
            int regX = 1;
            for (int cycle = 1; ; cycle++)
            {
                if ((cycle + 20) % 40 == 0)
                {
                    result += cycle * regX;
                }

                if (cyclesRaminaing == 0)
                {
                    if (!enumerator.MoveNext()) break;
                    instruction = (enumerator.Current as string)!.Split(' ');

                    cyclesRaminaing = instruction[0] switch
                    {
                        "noop" => 1,
                        "addx" => 2,
                        _ => throw new InvalidOperationException($"The instruction {instruction[0]} is not valid.")
                    };
                }

                if (cyclesRaminaing == 1)
                {
                    switch (instruction[0])
                    {
                        case "noop":
                            break;
                        case "addx":
                            int value = int.Parse(instruction[1]);
                            regX += value;
                            break;

                    }
                }

                cyclesRaminaing--;
            }

            return result;
        }
    }
}
