namespace AdventOfCode2022.Solutions
{
    //https://adventofcode.com/2022/day/4
    public static class Day4
    {
        public static int SolvePart1(string input)
        {
            int totalEncompasses = 0;

            foreach(string pair in input.Split("\n"))
            {
                string[] elves = pair.Split(",");
                Range e1 = ExtractRange(elves[0]);
                Range e2 = ExtractRange(elves[1]);

                if (RangeEncompasses(e1, e2) || RangeEncompasses(e2, e1)) totalEncompasses++;
            }

            return totalEncompasses;
        }

        private static Range ExtractRange(string range)
        {
            string[] parts = range.Split("-");
            return new Range(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        private static bool RangeEncompasses(Range outer, Range inner)
        {
            return outer.Max >= inner.Max && outer.Min <= inner.Min;
        }

        private struct Range
        {
            public readonly int Min;
            public readonly int Max;

            public Range(int min, int max)
            {
                Min = min;
                Max = max;
            }
        }

    }
}
