using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public static class Day7
    {
        public static int SolvePart1(string input)
        {
            Directory root = ParseInput(input);

            int result = 0;

            Queue<Directory> directories = new Queue<Directory>();
            directories.Enqueue(root);

            while (directories.Count > 0)
            {
                Directory dir = directories.Dequeue();
                foreach (var subDir in dir.Nodes.Where(n => n is Directory).Cast<Directory>()) directories.Enqueue(subDir);

                int size = dir.Size;
                if (size <= 100_000) result += size;
            }

            return result;
        }

        public static int SolvePart2(string input)
        {
            Directory root = ParseInput(input);

            const int totalSpace = 70_000_000;
            const int requiredSpace = 30_000_000;
            int usedSpace = root.Size;
            int unusedSpace = totalSpace - usedSpace;
            int spaceToFree = requiredSpace - unusedSpace;

            int smallestDirectorySize = int.MaxValue;

            Queue<Directory> directories = new Queue<Directory>();
            directories.Enqueue(root);

            while (directories.Count > 0)
            {
                Directory dir = directories.Dequeue();
                foreach (var subDir in dir.Nodes.Where(n => n is Directory).Cast<Directory>()) directories.Enqueue(subDir);

                int size = dir.Size;
                if (size >= spaceToFree && size <= smallestDirectorySize) smallestDirectorySize = size;
            }

            return smallestDirectorySize;
        }

        private static Directory ParseInput(string input)
        {
            Directory root = new Directory() { Name = "/", Parent = null };
            Directory currentDirectory = root;

            INode node = new Directory() { Name = "asd", Parent = null };
            INode[] nodes = new INode[0];

            bool a = node is Directory;
            bool b = nodes.Any(n => n is Directory);


            foreach (var line in input.Split('\n'))
            {
                var segments = line.Split(' ');
                if (segments[0] == "$")
                {
                    string command = segments[1];
                    switch (command)
                    {
                        case "cd":
                            string path = segments[2];
                            if (path == "/") currentDirectory = root;
                            else if (path == "..") currentDirectory = currentDirectory.Parent!;
                            else currentDirectory = (currentDirectory.Nodes.First(n => n is Directory && n.Name == path) as Directory)!;
                            break;
                        case "ls":
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (segments[0] == "dir") currentDirectory.Nodes.Add(new Directory() { Name = segments[1], Parent = currentDirectory });
                    else currentDirectory.Nodes.Add(new File() { Name = segments[1], Size = int.Parse(segments[0]) });
                }
            }

            return root;
        }
        private interface INode
        {
            string Name { get; }
            int Size { get; }
            string ToString(int indent);
        }

        [DebuggerDisplay("{Name}")]
        private sealed class Directory : INode
        {
            public required Directory? Parent { get; set; }
            public List<INode> Nodes { get; } = new List<INode>();

            public required string Name { get; set; }
            public int Size { get => Nodes.Select(n => n.Size).Sum(); }

            public override string ToString() => ToString(0);

            public string ToString(int indent)
            {
                int nextIndent = indent + 2;
                return $"{"".PadLeft(indent)}- {Name} (dir, size={Size})\n{string.Join('\n', Nodes.Select(n => n.ToString(nextIndent)))}";
            }
        }

        [DebuggerDisplay("{Name}")]
        private sealed class File : INode
        {
            public required string Name { get; set; }
            public required int Size { get; set; }

            public override string ToString() => $"- {Name} (file, size={Size})";
            public string ToString(int indent) => $"{"".PadLeft(indent)}- {Name} (file, size={Size})";
        }
    }
}
