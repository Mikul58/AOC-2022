using System.Text;

namespace AdventOfCode.Days;

public class Day10
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day10.txt");

        var cycles = 0;
        var startingValue = 1;
        int[] cyclesToRecalculate = {20, 60, 100, 140, 180, 220};
        var signalStrengths = new List<int>();

        while (cycles <= 220)
        {
            foreach (var line in input)
            {
                if (cycles > 220)
                    break;
                if (line == "noop")
                {
                    if (cyclesToRecalculate.Contains(cycles))
                    {
                        var oldValue = startingValue;
                        startingValue *= cycles;
                        signalStrengths.Add(startingValue);
                        startingValue = oldValue;
                    }

                    cycles++;
                    continue;
                }

                cycles++;
                if (cyclesToRecalculate.Contains(cycles))
                {
                    var oldValue = startingValue;
                    startingValue *= cycles;
                    signalStrengths.Add(startingValue);
                    startingValue = oldValue;
                }

                cycles++;
                if (cyclesToRecalculate.Contains(cycles))
                {
                    var oldValue = startingValue;
                    startingValue *= cycles;
                    signalStrengths.Add(startingValue);
                    startingValue = oldValue;
                }

                var splittedLine = line.Split(" ");
                startingValue += int.Parse(splittedLine[1]);
            }
        }

        Console.WriteLine(signalStrengths.Sum());
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day10.txt");

        var cycles = 0;
        var lineStringBuilder = new StringBuilder("###.....................................");
        var displayStringBuilder = new StringBuilder();

        while (cycles <= 240)
        {
            foreach (var line in input)
            {
                if (cycles > 240)
                {
                    break;
                }

                var currentPositionInChangingArray = GetPositionInChangingArray(cycles);
                displayStringBuilder.Append(lineStringBuilder![currentPositionInChangingArray]);
                cycles++;
                if (cycles > 240)
                {
                    break;
                }

                if (line == "noop")
                {
                    continue;
                }

                currentPositionInChangingArray = GetPositionInChangingArray(cycles);
                displayStringBuilder.Append(lineStringBuilder![currentPositionInChangingArray]);
                cycles++;
                if (cycles > 240)
                {
                    break;
                }

                var splittedLine = line.Split(" ");
                var valueToShift = int.Parse(splittedLine[1]);

                var hashOccurencies = new List<int>();

                for (var i = 0; i < lineStringBuilder.Length; i++)
                {
                    if (lineStringBuilder[i] == '#')
                    {
                        hashOccurencies.Add(i);
                    }
                }

                for (var i = 0; i < hashOccurencies.Count; i++)
                {
                    hashOccurencies[i] += valueToShift;

                    if (hashOccurencies[i] < 0)
                    {
                        hashOccurencies[i] = 40 - Math.Abs(hashOccurencies[i] % 40);
                        if (hashOccurencies[i] == 40)
                        {
                            hashOccurencies[i] = 0;
                        }
                    }

                    if (hashOccurencies[i] >= 40)
                    {
                        if (hashOccurencies[i] == 40)
                        {
                            hashOccurencies[i] = 0;
                        }
                        else
                        {
                            hashOccurencies[i] = hashOccurencies[i] % 40;   
                        }
                    }
                }

                lineStringBuilder.Clear();
                lineStringBuilder.Append("........................................");

                for (var i = 0; i < lineStringBuilder.Length; i++)
                {
                    foreach (var hash in hashOccurencies.Where(hash => i == hash))
                    {
                        lineStringBuilder[i] = '#';
                    }
                }

                hashOccurencies.Clear();
            }
        }

        for (var i = 0; i < displayStringBuilder.Length; i++)
        {
            if (i % 40 == 0)
            {
                Console.WriteLine();
            }

            Console.Write(displayStringBuilder[i]);
        }
    }

    private static int GetPositionInChangingArray(int cycles)
    {
        int currentPositionInChangingArray;

        if (cycles >= 40)
        {
            currentPositionInChangingArray = cycles % 40;
        }
        else
        {
            currentPositionInChangingArray = cycles ;
        }

        return currentPositionInChangingArray;
    }
}
