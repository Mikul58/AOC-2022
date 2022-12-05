namespace AdventOfCode.Days;

public class Day5
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day5.txt");

        var phrasesToDelete = new[] {"move", "from", "to"};
        var instructions = input
            .Where(x => x.StartsWith("move"))
            .Select(x => x.Split(phrasesToDelete, StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        var stacks = new Dictionary<int, Stack<char>>();

        for (var i = input.Length - 1; i >= 0; i--)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                if (char.IsUpper(input[i][j]))
                {
                    var currentStackPosition = 1 + j / 4;
                    if (!stacks.ContainsKey(currentStackPosition))
                    {
                        stacks.Add(currentStackPosition, new Stack<char>());
                    }

                    stacks[currentStackPosition].Push(input[i][j]);
                }
            }
        }

        foreach (var values in instructions)
        {
            var currentValues = Array.ConvertAll(values, int.Parse);
            var numberOfValuesToMove = currentValues[0];
            for (var i = 0; i < numberOfValuesToMove; i++)
            {
                stacks[currentValues[2]].Push(stacks[currentValues[1]].Peek());
                stacks[currentValues[1]].Pop();
            }
        }

        foreach (var stack in stacks)
        {
            Console.Write(stack.Value.Peek());
        }
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day5.txt");

        var phrasesToDelete = new[] {"move", "from", "to"};
        var instructions = input
            .Where(x => x.StartsWith("move"))
            .Select(x => x.Split(phrasesToDelete, StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        var stacks = new Dictionary<int, Stack<char>>();

        for (var i = input.Length - 1; i >= 0; i--)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                var currentStackPosition = 1 + j / 4;
                if (char.IsUpper(input[i][j]))
                {
                    if (!stacks.ContainsKey(currentStackPosition))
                    {
                        stacks.Add(currentStackPosition, new Stack<char>());
                    }

                    stacks[currentStackPosition].Push(input[i][j]);
                }
            }
        }

        foreach (var values in instructions)
        {
            var instructionsForCurrentOperation = Array.ConvertAll(values, int.Parse);
            var numberOfValuesToMove = instructionsForCurrentOperation[0];
            var cratesList = new List<char>();
            for (var i = 0; i < numberOfValuesToMove; i++)
            {
                cratesList.Add(stacks[instructionsForCurrentOperation[1]].Peek());
                stacks[instructionsForCurrentOperation[1]].Pop();
            }

            for (var i = cratesList.Count - 1; i >= 0; i--)
            {
                stacks[instructionsForCurrentOperation[2]].Push(cratesList[i]);
            }
        }

        foreach (var stack in stacks)
        {
            Console.Write(stack.Value.Peek());
        }
    }
}
