namespace AdventOfCode.Days;

public static class Day7
{
    public class Directory
    {
        public Directory(string directoryName, Directory? ancestorDirectory = null)
        {
            DirectoryName = directoryName;
            AncestorDirectory = ancestorDirectory;
            ChildDirectories = new List<Directory>();
            FilesList = new List<Tuple<int, string>>();
        }

        public string DirectoryName { get; }
        public Directory? AncestorDirectory { get; }
        public List<Tuple<int, string>> FilesList { get; }
        public List<Directory> ChildDirectories { get; }

        public void AddDirectory(string directoryName, Directory? ancestor = null)
        {
            ChildDirectories.Add(new Directory(directoryName, ancestor));
        }

        public void AddFile(int fileSize, string fileName)
        {
            FilesList.Add(new Tuple<int, string>(fileSize, fileName));
        }

        public int CalculateAllFilesInDirectory()
            => FilesList.Sum(file => file.Item1);
    }

    public static void Part1()
    {
        var input = File.ReadAllLines("day7.txt");
        var rootDirectory = new Directory("/");
        var rootDirectoryHead = rootDirectory;

        foreach (var line in input)
        {
            if (line == "$ ls") continue;

            if (!line.StartsWith("$"))
            {
                var file = line.Split(" ");
                if (file[0] != "dir")
                {
                    rootDirectory?.AddFile(int.Parse(file[0]), file[1]);
                }
                else
                {
                    rootDirectory?.AddDirectory(file[1], rootDirectory);
                }

                continue;
            }

            var nextCommand = line.Split(" ");

            {
                var dirName = nextCommand[2];
                switch (dirName)
                {
                    case "/":
                        continue;
                    case "..":
                        rootDirectory = rootDirectory?.AncestorDirectory;
                        break;
                    default:
                        rootDirectory = rootDirectory?.ChildDirectories.FirstOrDefault(x => x.DirectoryName == dirName);
                        break;
                }
            }
        }

        Console.WriteLine(GetAllChildDirectorySizesLessThanHundredThousand(rootDirectoryHead));
    }

    private static int GetAllChildDirectorySizesLessThanHundredThousand(Directory rootDirectory)
    {
        var childDirectorySizesList = new List<int>();

        foreach (var childDirectory in rootDirectory.ChildDirectories)
        {
            var childDirectoriesSize = GetAllChildDirectorySizesLessThanHundredThousand(childDirectory);
            childDirectorySizesList.Add(childDirectoriesSize);
        }

        var sizeFromCurrentDirectory = 0;

        foreach (var file in rootDirectory.FilesList)
        {
            sizeFromCurrentDirectory += file.Item1;
        }

        if (sizeFromCurrentDirectory <= 100000)
        {
            childDirectorySizesList.Add(sizeFromCurrentDirectory);
        }

        return childDirectorySizesList.Sum();
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day7.txt");
    }
}
