namespace AdventOfCode2022.Tests
{
    internal class Day5
    {
        [Theory]
        [TestCase("Day5Part1Example.txt", "CMZ")]
        [TestCase("Day5Part1Puzzle.txt", "TLFGBZHCN")]
        public void SolvePart1(string inputFile, string expected)
        {
            string input = File.ReadAllText(inputFile);
            string actual = Solutions.Day5.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day5Part1Example.txt", "MCD")]
        [TestCase("Day5Part1Puzzle.txt", "QRQFHFWCL")]
        public void SolvePart2(string inputFile, string expected)
        {
            string input = File.ReadAllText(inputFile);
            string actual = Solutions.Day5.SolvePart2(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
