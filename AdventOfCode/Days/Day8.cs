namespace AdventOfCode.Days;

public class Day8
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day8.txt").Select(row => row.Select(inputChar => inputChar - '0').ToArray())
            .ToArray();

        var visibleTrees = 2 * input.Length + 2 * input[0].Length - 4;

        for (var i = 1; i < input.Length - 1; i++)
        {
            for (var j = 1; j < input[i].Length - 1; j++)
            {
                if (IsVisibleFromTop(input, i, j))
                {
                    Console.Write("Visible");
                    visibleTrees++;
                    continue;
                }

                if (IsVisibleFromBottom(input, i, j))
                {
                    Console.Write("Visible");
                    visibleTrees++;
                    continue;
                }

                if (IsVisibleFromLeft(input, i, j))
                {
                    Console.Write("Visible");
                    visibleTrees++;
                    continue;
                }

                if (!IsVisibleFromRight(input, i, j))
                {
                    continue;
                }

                Console.Write("Visible");
                visibleTrees++;
            }
        }

        Console.WriteLine(visibleTrees);
    }

    private static bool IsVisibleFromTop(IReadOnlyList<int[]> grid, int a, int b)
    {
        Console.WriteLine($"{a}, {b}");
        for (var i = 0; i < a; i++)
        {
            if (grid[i][b] >= grid[a][b])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromBottom(IReadOnlyList<int[]> grid, int a, int b)
    {
        Console.WriteLine($"{a}, {b}");
        for (var i = grid.Count - 1; i > a; i--)
        {
            if (grid[i][b] >= grid[a][b])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromRight(IReadOnlyList<int[]> grid, int a, int b)
    {
        Console.WriteLine($"{a}, {b}");
        for (var i = grid[a].Length - 1; i > b; i--)
        {
            if (grid[a][i] >= grid[a][b])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleFromLeft(IReadOnlyList<int[]> grid, int a, int b)
    {
        Console.WriteLine($"{a}, {b}");
        for (var i = 0; i < b; i++)
        {
            if (grid[a][i] >= grid[a][b])
            {
                return false;
            }
        }

        return true;
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day8.txt").Select(row => row.Select(inputChar => inputChar - '0').ToArray())
            .ToArray();

        var highestValue = 0;

        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                var currentValue =
                    GetLengthFromBottom(input, i, j) * GetLengthFromLeft(input, i, j) *
                    GetLengthFromRight(input, i, j) * GetLengthFromTop(input, i, j);
                if(currentValue > highestValue)
                {
                    highestValue = currentValue;
                }
            }
        }
        
        Console.WriteLine(highestValue);
    }

    private static int GetLengthFromTop(IReadOnlyList<int[]> grid, int a, int b)
    {
        if (a - 1 < 0)
        {
            return 0;
        }
        
        var counter = 0;
        
        for (var i = a - 1; i >= 0; i--)
        {
            counter++;
            if (grid[i][b] >= grid[a][b])
            {
                break;
            }
        }

        return counter;
    }

    private static int GetLengthFromBottom(IReadOnlyList<int[]> grid, int a, int b)
    {
        if (a + 1 > grid.Count)
        {
            return 0;
        }
        
        var counter = 0;

        for (var i = a + 1; i < grid.Count; i++)
        {
            counter++;
            if (grid[i][b] >= grid[a][b])
            {
                break;
            }
        }

        return counter;
    }

    private static int GetLengthFromRight(IReadOnlyList<int[]> grid, int a, int b)
    {
        if (b + 1 > grid[a].Length)
        {
            return 0;
        }
        
        var counter = 0;
        
        for (var i = b + 1; i < grid[a].Length; i++)
        {
            counter++;
            if (grid[a][i] >= grid[a][b])
            {
                break;
            }
        }

        return counter;
    }

    private static int GetLengthFromLeft(IReadOnlyList<int[]> grid, int a, int b)
    {
        if (b - 1 < 0)
        {
            return 0;
        }
        
        var counter = 0;
        
        for (var i = b - 1; i >= 0; i--)
        {
            counter++;
            if (grid[a][i] >= grid[a][b])
            {
                break;
            }
        }

        return counter;
    }
}
