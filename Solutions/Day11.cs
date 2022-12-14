using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Solutions
{
    public static class Day11
    {
        public static int SolvePart1(string input)
        {
            string[] inputSections = input.Split("\n\n");
            var monkeys = inputSections.Select(s => new Monkey1(s)).ToArray();

            for (int round = 0; round < 20; round++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.TryDequeue(out int currentItem))
                    {
                        monkey.NumberOfInspecitons++;
                        int worryLevel = monkey.WorryLevelChange(currentItem);
                        worryLevel /= 3;
                        int nextMonkey = monkey.GetNextMonkey(worryLevel);
                        monkeys[nextMonkey].Items.Enqueue(worryLevel);
                    }
                }
            }

            return monkeys.OrderByDescending(m => m.NumberOfInspecitons).Take(2).Aggregate(1, (a, m) => a * (int)m.NumberOfInspecitons);
        }

        public static long SolvePart2(string input)
        {
            string[] inputSections = input.Split("\n\n");
            var monkeys = inputSections.Select(s => new Monkey2(s)).ToArray();

            int shrink = monkeys.Select(m => m.TestDivisor).Aggregate(1, (a, n) => a * n);

            for (int round = 0; round < 10_000; round++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.TryDequeue(out long currentItem))
                    {
                        monkey.NumberOfInspecitons++;
                        long worryLevel = monkey.WorryLevelChange(currentItem) % shrink;
                        int nextMonkey = monkey.GetNextMonkey(worryLevel);
                        monkeys[nextMonkey].Items.Enqueue(worryLevel);
                    }
                }
            }

            return monkeys.OrderByDescending(m => m.NumberOfInspecitons).Take(2).Aggregate((long)1, (a, m) => a * m.NumberOfInspecitons);
        }

        private class Monkey1
        {
            private static readonly Regex _regexParse = new Regex(@"(?'monkey'Monkey (?'id'\d+):\s+Starting items: (?:(?'starting_item'\d+)(?:, )?)+)\s+Operation: new = (?'op1'.*?) (?'op2'.*?) (?'op3'.*?)\s+Test: divisible by (?'test'\d+)\s+If true: throw to monkey (?'throw_true'\d+)\s+If false: throw to monkey (?'throw_false'\d+)", RegexOptions.Compiled);

            public readonly int Id;
            public long NumberOfInspecitons = 0;
            public readonly Queue<int> Items = new Queue<int>();
            public readonly Func<int, int> WorryLevelChange; //Operation in puzzle
            public readonly Func<int, int> GetNextMonkey; //Test in puzzle

            public Monkey1(string input)
            {
                var match = _regexParse.Match(input);
                Id = int.Parse(match.Groups["id"].ValueSpan);

                foreach (Capture cap in match.Groups["starting_item"].Captures) Items.Enqueue(int.Parse(cap.ValueSpan));

                {
                    Func<int, int> left = (old) => old;

                    string opName = match.Groups["op2"].Value;
                    Func<int, int, int> op = opName switch
                    {
                        "+" => (l, r) => l + r,
                        "-" => (l, r) => l - r,
                        "*" => (l, r) => l * r,
                        "/" => (l, r) => l / r,
                        _ => throw new InvalidOperationException($"The operation {opName} is not valid.")
                    };

                    string rightValue = match.Groups["op3"].Value;
                    Func<int, int> right;
                    if (rightValue == "old")
                    {
                        right = (old) => old;
                    }
                    else
                    {
                        int rightNumeric = int.Parse(rightValue);
                        right = (old) => rightNumeric;
                    }

                    WorryLevelChange = (old) => op(left(old), right(old));
                }

                {
                    int divisiableBy = int.Parse(match.Groups["test"].ValueSpan);
                    int ifTrue = int.Parse(match.Groups["throw_true"].ValueSpan);
                    int ifFalse = int.Parse(match.Groups["throw_false"].ValueSpan);
                    GetNextMonkey = (old) => old % divisiableBy == 0 ? ifTrue : ifFalse;
                }
            }
        }

        private class Monkey2
        {
            private static readonly Regex _regexParse = new Regex(@"(?'monkey'Monkey (?'id'\d+):\s+Starting items: (?:(?'starting_item'\d+)(?:, )?)+)\s+Operation: new = (?'op1'.*?) (?'op2'.*?) (?'op3'.*?)\s+Test: divisible by (?'test'\d+)\s+If true: throw to monkey (?'throw_true'\d+)\s+If false: throw to monkey (?'throw_false'\d+)", RegexOptions.Compiled);

            public readonly int Id;
            public long NumberOfInspecitons = 0;
            public readonly Queue<long> Items = new Queue<long>();
            public readonly Func<long, long> WorryLevelChange; //Operation in puzzle
            public readonly Func<long, int> GetNextMonkey; //Test in puzzle
            public readonly int TestDivisor;

            public Monkey2(string input)
            {
                var match = _regexParse.Match(input);
                Id = int.Parse(match.Groups["id"].ValueSpan);

                foreach (Capture cap in match.Groups["starting_item"].Captures) Items.Enqueue(int.Parse(cap.ValueSpan));

                {
                    Func<long, long> left = (old) => old;

                    string opName = match.Groups["op2"].Value;
                    Func<long, long, long> op = opName switch
                    {
                        "+" => (l, r) => l + r,
                        "-" => (l, r) => l - r,
                        "*" => (l, r) => l * r,
                        "/" => (l, r) => l / r,
                        _ => throw new InvalidOperationException($"The operation {opName} is not valid.")
                    };

                    string rightValue = match.Groups["op3"].Value;
                    Func<long, long> right;
                    if (rightValue == "old")
                    {
                        right = (old) => old;
                    }
                    else
                    {
                        int rightNumeric = int.Parse(rightValue);
                        right = (old) => rightNumeric;
                    }

                    WorryLevelChange = (old) => op(left(old), right(old));
                }

                {
                    TestDivisor = int.Parse(match.Groups["test"].ValueSpan);
                    int ifTrue = int.Parse(match.Groups["throw_true"].ValueSpan);
                    int ifFalse = int.Parse(match.Groups["throw_false"].ValueSpan);
                    GetNextMonkey = (old) => old % TestDivisor == 0 ? ifTrue : ifFalse;
                }
            }
        }
    }
}
