namespace AdventOfCode2022.Tests
{
    internal class Day10
    {
        [Theory]
        [TestCase("Day10Example.txt", 13140)]
        [TestCase("Day10Puzzle.txt", 15360)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day10.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day10Example.txt", "Day10ExampleOutput.txt")]
        [TestCase("Day10Puzzle.txt","Day10PuzzleOutput.txt")]
        public void SolvePart2(string inputFile, string expectedFile)
        {
            string input = File.ReadAllText(inputFile);
            string actual = Solutions.Day10.SolvePart2(input);

            string expected = File.ReadAllText(expectedFile);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
