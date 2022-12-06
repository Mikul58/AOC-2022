namespace AdventOfCode.Days;

public class Day6
{
    public static void Part1()
    {
        var input = File.ReadAllText("day6.txt");

        for (var i = 0; i < input.Length; i++)
        {
            var isNonRepeatable = true;
            var substring = input.Substring(i, 4);
            for (var j = 0; j < substring.Length; j++)
            {
                for (var k = j + 1; k < substring.Length; k++)
                {
                    if (substring[k] == substring[j])
                    {
                        isNonRepeatable = false;
                        break;
                    }
                }
            }

            if (isNonRepeatable)
            {
                Console.WriteLine(i + 4);
                break;
            }
        }
    }

    public static void Part2()
    {
        var input = File.ReadAllText("day6.txt");

        for (var i = 0; i < input.Length; i++)
        {
            var isNonRepeatable = true;
            var substring = input.Substring(i, 14);
            for (var j = 0; j < substring.Length; j++)
            {
                for (var k = j + 1; k < substring.Length; k++)
                {
                    if (substring[k] == substring[j])
                    {
                        isNonRepeatable = false;
                        break;
                    }
                }
            }

            if (isNonRepeatable)
            {
                Console.WriteLine(i + 14);
                break;
            }
        }
    }
}
