namespace AdventOfCode.Days;

public static class Day4
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day4.txt");

        var fullyOverlapedAssignmentsCount = 0;

        foreach (var line in input)
        {
            var lineWithOnlyValues = line.Split(',', '-');
            var valuesAsIntArray = Array.ConvertAll(lineWithOnlyValues, int.Parse);

            fullyOverlapedAssignmentsCount += IncrementFullyOverlappedAssignments(valuesAsIntArray);
        }

        Console.WriteLine(fullyOverlapedAssignmentsCount);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day4.txt");
        var partiallyOverlapedAssignmentsCount = 0;

        foreach (var line in input)
        {
            var lineWithOnlyValues = line.Split(',', '-');
            var valuesAsIntArray = Array.ConvertAll(lineWithOnlyValues, int.Parse);

            partiallyOverlapedAssignmentsCount += IncrementPartiallyOverlappedAssignments(valuesAsIntArray);
        }

        Console.WriteLine(partiallyOverlapedAssignmentsCount);
    }

    private static int IncrementFullyOverlappedAssignments(IReadOnlyList<int> valuesAsIntArray)
    {
        if
        (
            valuesAsIntArray[0] <= valuesAsIntArray[2] && valuesAsIntArray[1] >= valuesAsIntArray[3] ||
            valuesAsIntArray[0] >= valuesAsIntArray[2] && valuesAsIntArray[1] <= valuesAsIntArray[3]
        )
        {
            return 1;
        }

        return 0;
    }

    private static int IncrementPartiallyOverlappedAssignments(IReadOnlyList<int> valuesAsIntArray)
    {
        if
        (
            valuesAsIntArray[0] <= valuesAsIntArray[2] && valuesAsIntArray[1] >= valuesAsIntArray[2] ||
            valuesAsIntArray[0] <= valuesAsIntArray[3] && valuesAsIntArray[1] >= valuesAsIntArray[3] ||
            valuesAsIntArray[2] <= valuesAsIntArray[0] && valuesAsIntArray[3] >= valuesAsIntArray[0] ||
            valuesAsIntArray[3] <= valuesAsIntArray[0] && valuesAsIntArray[3] >= valuesAsIntArray[1]
        )
        {
            return 1;
        }

        return 0;
    }
}
