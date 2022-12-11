using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tests
{
    internal class Day11
    {
        [Theory]
        [TestCase("Day11Example.txt", 10605)]
        [TestCase("Day11Puzzle.txt", 110888)]
        public void SolvePart1(string inputFile, int expected)
        {
            string input = File.ReadAllText(inputFile);
            int actual = Solutions.Day11.SolvePart1(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
