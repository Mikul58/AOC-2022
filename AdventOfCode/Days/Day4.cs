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

            if (valuesAsIntArray[0] <= valuesAsIntArray[2] && valuesAsIntArray[1] >= valuesAsIntArray[3])
            {
                fullyOverlapedAssignmentsCount++;
            }
            else if (valuesAsIntArray[0] >= valuesAsIntArray[2] && valuesAsIntArray[1] <= valuesAsIntArray[3])
            {
                fullyOverlapedAssignmentsCount++;
            }
        }

        Console.WriteLine(fullyOverlapedAssignmentsCount);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day4.txt");
        var fullyOverlapedAssignmentsCount = 0;

        foreach (var line in input)
        {
            var lineWithOnlyValues = line.Split(',', '-');
            var valuesAsIntArray = Array.ConvertAll(lineWithOnlyValues, int.Parse);

            if (valuesAsIntArray[0] <= valuesAsIntArray[2] && valuesAsIntArray[1] >= valuesAsIntArray[2])
                fullyOverlapedAssignmentsCount++;
            else if (valuesAsIntArray[0] <= valuesAsIntArray[3] && valuesAsIntArray[1] >= valuesAsIntArray[3])
                fullyOverlapedAssignmentsCount++;
            else if (valuesAsIntArray[2] <= valuesAsIntArray[0] && valuesAsIntArray[3] >= valuesAsIntArray[0])
                fullyOverlapedAssignmentsCount++;
            else if (valuesAsIntArray[3] <= valuesAsIntArray[0] && valuesAsIntArray[3] >= valuesAsIntArray[1])
                fullyOverlapedAssignmentsCount++;
        }

        Console.WriteLine(fullyOverlapedAssignmentsCount);
    }
}
