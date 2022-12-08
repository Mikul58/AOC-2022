using System.Data;
using Microsoft.VisualBasic.FileIO;

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
}
