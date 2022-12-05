namespace AdventOfCode.Days;

public class Day5
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day5.txt");
        var instructions = MapInstructionsFromInput(input);

        var stacksDictionary = MapStacksDictionaryFromInput(input);
        stacksDictionary = RearrangeStacksWithCrateMover9000(instructions, stacksDictionary);
        DisplayTopCrates(stacksDictionary);
    }

    public static void Part2()
    {
        var input = File.ReadAllLines("day5.txt");
        var instructions = MapInstructionsFromInput(input);

        var stacksDictionary = MapStacksDictionaryFromInput(input);
        stacksDictionary = RearrangeStacksWithCrateMover9001(instructions, stacksDictionary);
        DisplayTopCrates(stacksDictionary);
    }

    private static IEnumerable<string[]> MapInstructionsFromInput(IEnumerable<string> input)
    {
        var phrasesToDelete = new[] {"move", "from", "to"};
        return input
            .Where(x => x.StartsWith("move"))
            .Select(x => x.Split(phrasesToDelete, StringSplitOptions.RemoveEmptyEntries))
            .ToArray();
    }

    private static Dictionary<int, Stack<char>> MapStacksDictionaryFromInput(IReadOnlyList<string> input)
    {
        var stacks = new Dictionary<int, Stack<char>>();

        for (var i = input.Count - 1; i >= 0; i--)
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

        return stacks;
    }

    private static Dictionary<int, Stack<char>> RearrangeStacksWithCrateMover9000(IEnumerable<string[]> instructions,
        Dictionary<int, Stack<char>> stacks)
    {
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

        return stacks;
    }

    private static Dictionary<int, Stack<char>> RearrangeStacksWithCrateMover9001(IEnumerable<string[]> instructions,
        Dictionary<int, Stack<char>> stacks)
    {
        foreach (var values in instructions)
        {
            var instructionsForCurrentOperation = Array.ConvertAll(values, int.Parse);
            var numberOfValuesToMove = instructionsForCurrentOperation[0];
            var cratesStack = new Stack<char>();
            for (var i = 0; i < numberOfValuesToMove; i++)
            {
                cratesStack.Push(stacks[instructionsForCurrentOperation[1]].Pop());
            }

            while (cratesStack.Count > 0)
            {
                stacks[instructionsForCurrentOperation[2]].Push(cratesStack.Pop());
            }
        }

        return stacks;
    }

    private static void DisplayTopCrates(Dictionary<int, Stack<char>> stacks)
    {
        foreach (var stack in stacks)
        {
            Console.Write(stack.Value.Peek());
        }
    }
}
