namespace AdventOfCode2022.Tests
{
    internal class Day05
    {
        [Theory]
        [TestCase("Day05Example.txt", "CMZ")]
        [TestCase("Day05Puzzle.txt", "TLFGBZHCN")]
        public void SolvePart1(string inputFile, string expected)
        {
            string input = File.ReadAllText(inputFile);
            string actual = Solutions.Day05.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day05Example.txt", "MCD")]
        [TestCase("Day05Puzzle.txt", "QRQFHFWCL")]
        public void SolvePart2(string inputFile, string expected)
        {
            string input = File.ReadAllText(inputFile);
            string actual = Solutions.Day05.SolvePart2(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
