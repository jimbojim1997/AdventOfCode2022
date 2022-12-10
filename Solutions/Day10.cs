using System;
using System.Text;

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

        public static string SolvePart2(string input)
        {
            var lines = input.Split('\n');
            var enumerator = lines.GetEnumerator();

            bool[,] screen = new bool[40, 6];
            string[] instruction = Array.Empty<string>();
            int cyclesRaminaing = 0;
            int regX = 1;
            for (int cycle = 1; ; cycle++)
            {
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

                {
                    int screenCycle = (cycle - 1) % 240;
                    int screenX = screenCycle % 40;
                    int screenY = screenCycle / 40;

                    screen[screenX, screenY] = screenX >= regX - 1 && screenX <= regX + 1;
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

            var sb = new StringBuilder();
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                for (int x = 0; x < screen.GetLength(0); x++)
                {
                    sb.Append(screen[x, y] switch
                    {
                        true => '#',
                        _ => '.'
                    });
                }
                sb.Append('\n');
            }

            return sb.ToString().Trim();
        }
    }
}
