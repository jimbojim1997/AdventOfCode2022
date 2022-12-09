namespace AdventOfCode2022.Tests
{
    internal class Day9
    {
        [Theory]
        [TestCase("Day9Part1Example.txt", 13)]
        [TestCase("Day9Part1Puzzle.txt", 5902)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day9.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day9Part1Example.txt", 1)]
        [TestCase("Day9Part2Example.txt", 36)]
        [TestCase("Day9Part1Puzzle.txt", 2445)]
        public void SolvePart2(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day9.SolvePart2(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
