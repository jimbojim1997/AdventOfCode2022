namespace AdventOfCode2022.Tests
{
    internal class Day10
    {
        [Theory]
        [TestCase("Day10Part1Example.txt", 13140)]
        [TestCase("Day10Part1Puzzle.txt", 15360)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day10.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
