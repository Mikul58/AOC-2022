namespace AdventOfCode.Days;

public static class Day1
{
    //Only part 2
    public static void Part2()
    {
        var input = File.ReadAllLines("day1.txt");

        var caloriesPerElfList = new List<int>();
        var currentElfCalories = 0;

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                caloriesPerElfList.Add(currentElfCalories);
                currentElfCalories = 0;
            }
            else
            {
                currentElfCalories += Convert.ToInt32(line);
            }
        }

        var ordered = caloriesPerElfList.OrderByDescending(x => x).Take(3).ToList();
        Console.WriteLine(ordered.Sum());
    }
}
