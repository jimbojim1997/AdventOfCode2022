using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/5
    public static class Day5
    {
        public static string SolvePart1(string input)
        {
            string[] sections = input.Split("\n\n");
            string stateText = sections[0];
            string instructionsText = sections[1];

            Stack<char>[] stacks = ParseStateText(stateText);

            foreach (Instruction instruction in ParseInstructions(instructionsText))
            {
                for (int i = 0; i < instruction.Count; i++)
                {
                    char item = stacks[instruction.From - 1].Pop();
                    stacks[instruction.To - 1].Push(item);
                }
            }

            return new string(stacks.Select(s => s.TryPop(out char item) ? item : ' ').ToArray());
        }

        private static Stack<char>[] ParseStateText(string input)
        {
            string[] lines = input.Split("\n");

            string lastLine = lines[lines.Length - 1];
            string lastNumberChar = lastLine.Substring(lastLine.Length - 2, 1);
            int stacksCount = int.Parse(lastNumberChar);

            var stacks = new Stack<char>[stacksCount];
            for (int i = 0; i < stacksCount; i++) stacks[i] = new Stack<char>();

            for (int l = lines.Length - 2; l >= 0; l--)
            {
                var line = lines[l];
                for (int c = 0, s = 0; c < line.Length; c += 4, s++)
                {
                    char item = line[c + 1];
                    if (item != ' ') stacks[s].Push(item);
                }
            }

            return stacks;
        }

        private static IEnumerable<Instruction> ParseInstructions(string input)
        {
            Regex lineParse = new Regex(@"move (?'count'\d+) from (?'from'\d+) to (?'to'\d+)", RegexOptions.IgnoreCase);
            MatchCollection matches = lineParse.Matches(input);
            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups["count"].ValueSpan);
                int from = int.Parse(match.Groups["from"].ValueSpan);
                int to = int.Parse(match.Groups["to"].ValueSpan);

                yield return new Instruction(count, from, to);
            }
        }

        private struct Instruction
        {
            public readonly int Count;
            public readonly int From;
            public readonly int To;

            public Instruction(int count, int from, int to)
            {
                Count = count;
                From = from;
                To = to;
            }
        }
    }
}
