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

        [Theory]
        [TestCase("Day10Part1Example.txt", "Day10Part2ExampleOutput.txt")]
        [TestCase("Day10Part1Puzzle.txt","Day10Part2PuzzleOutput.txt")]
        public void SolvePart2(string inputFile, string expectedFile)
        {
            string input = File.ReadAllText(inputFile);
            string actual = Solutions.Day10.SolvePart2(input);

            string expected = File.ReadAllText(expectedFile);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
