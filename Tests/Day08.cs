namespace AdventOfCode2022.Tests
{
    internal class Day08
    {
        [Theory]
        [TestCase("Day08Example.txt", 21)]
        [TestCase("Day08Puzzle.txt", 1792)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day08.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day08Example.txt", 8)]
        [TestCase("Day08Puzzle.txt", 334880)]
        public void SolvePart2(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day08.SolvePart2(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
