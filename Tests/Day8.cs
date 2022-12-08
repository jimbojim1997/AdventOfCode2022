namespace AdventOfCode2022.Tests
{
    internal class Day8
    {
        [Theory]
        [TestCase("Day8Part1Example.txt", 21)]
        [TestCase("Day8Part1Puzzle.txt", 1792)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day8.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
