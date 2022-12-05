namespace AdventOfCode.Days;

public static class Day3
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day3.txt");
        var itemList = new List<char>();

        foreach (var line in input)
        {
            var halfInputLength = (line.Length + 1) / 2;
            var firstHalf = line.Substring(0, halfInputLength);
            var secondHalf = line.Substring(halfInputLength, line.Length - halfInputLength);

            foreach (var character in secondHalf.Where(t => firstHalf.Contains(t)))
            {
                itemList.Add(character);
                break;
            }
        }

        var itemDictionary = GetItemsDictionary();
        var totalPoints = itemList.Sum(item => itemDictionary[item]);

        Console.WriteLine(totalPoints);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day3.txt");
        var itemList = new List<char>();

        for (var i = 0; i < input.Length; i++)
        {
            if ((i + 1) % 3 != 0)
            {
                continue;
            }

            for (var j = 0; j < input[i - 2].Length; j++)
            {
                if (input[i - 1].Contains(input[i - 2][j]))
                {
                    itemList.Add(input[i - 2][j]);
                    break;
                }
            }
        }

        var itemDictionary = GetItemsDictionary();
        var totalPoints = itemList.Sum(item => itemDictionary[item]);
        Console.WriteLine(totalPoints);
    }

    private static Dictionary<char, int> GetItemsDictionary()
    {
        var dict = new Dictionary<char, int>();
        for (int i = 'A', j = 27; i <= 'z'; i++)
        {
            if ((char) i > 'Z' && (char) i < 'a')
            {
                continue;
            }

            dict.Add((char) i, j);
            j++;

            if ((char) i == 'Z')
            {
                j = 1;
            }
        }

        return dict;
    }
}
