﻿namespace AdventOfCode2022.Tests
{
    internal class Day7
    {
        [Theory]
        [TestCase("Day7Part1Example.txt", 95437)]
        [TestCase("Day7Part1Puzzle.txt", 1428881)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day7.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("Day7Part1Example.txt", 24933642)]
        [TestCase("Day7Part1Puzzle.txt", 10475598)]
        public void SolvePart2(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day7.SolvePart2(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
