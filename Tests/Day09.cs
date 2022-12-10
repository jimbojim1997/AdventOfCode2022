namespace AdventOfCode2022.Tests
{
    internal class Day09
    {
        [Theory]
        [TestCase("Day09Example1.txt", 13)]
        [TestCase("Day09Puzzle.txt", 5902)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day09.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day09Example1.txt", 1)]
        [TestCase("Day09Example2.txt", 36)]
        [TestCase("Day09Puzzle.txt", 2445)]
        public void SolvePart2(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day09.SolvePart2(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
