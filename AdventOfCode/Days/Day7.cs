namespace AdventOfCode.Days;

public static class Day7
{
    public class Directory
    {
        public Directory(string directoryName, Directory? ancestorDirectory = null)
        {
            DirectoryName = directoryName;
            AncestorDirectory = ancestorDirectory;
            ChildDirectoryList = new List<Directory>();
            FilesList = new List<Tuple<int, string>>();
        }

        public string DirectoryName { get; }
        public Directory? AncestorDirectory { get; }
        public List<Tuple<int, string>> FilesList { get; }
        public List<Directory> ChildDirectoryList { get; }
        public int SizeOfAllFilesInDirectory { get; private set; }

        public void AddDirectory(string directoryName, Directory? ancestor = null)
        {
            ChildDirectoryList.Add(new Directory(directoryName, ancestor));
        }

        public void AddFile(int fileSize, string fileName)
        {
            FilesList.Add(new Tuple<int, string>(fileSize, fileName));
        }

        public void GetSizeOfAllFilesThatDirectoryContains()
        {
            SizeOfAllFilesInDirectory = FilesList.Sum(x => x.Item1);

            foreach (var childDirectory in ChildDirectoryList)
            {
                SizeOfAllFilesInDirectory += childDirectory.SizeOfAllFilesInDirectory;
            }
        }
    }

    public static void Part1()
    {
        var input = File.ReadAllLines("day7.txt");
        var rootDirectory = new Directory("/");
        var sumOfSizesLessThanHundredThousand = 0;

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
                        rootDirectory?.GetSizeOfAllFilesThatDirectoryContains();
                        if (rootDirectory?.SizeOfAllFilesInDirectory <= 100000)
                        {
                            sumOfSizesLessThanHundredThousand += rootDirectory.SizeOfAllFilesInDirectory;
                        }
                        rootDirectory = rootDirectory?.AncestorDirectory;
                        break;
                    default:
                        rootDirectory = rootDirectory?.ChildDirectoryList.FirstOrDefault(x => x.DirectoryName == dirName);
                        break;
                }
            }
        }
        
        Console.WriteLine(sumOfSizesLessThanHundredThousand);
    }
}
