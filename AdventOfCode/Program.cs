//I'll rearrange structure of Days later, I am aware that with regions it looks awful

#region Days
#region Day1
//Only part 2
static void Day1()
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
#endregion
#region  Day2
//Only part 2
static void Day2()
{
    var input = File.ReadAllLines("day2.txt");
    var points = 0;
    var rockPaperScissorsDictionary = new Dictionary<char[], int>()
    {
        {new[] {'A', 'X'}, 1},
        {new[] {'B', 'Y'}, 2},
        {new[] {'C', 'Z'}, 3},
    };
    
    foreach (var line in input)
    {
        var opponentChoiceAsNumber = 0;
        var playerChoiceAsNumber = 0;
    
        foreach (var keyValuePair in rockPaperScissorsDictionary)
        {
            if (keyValuePair.Key[0] == line[0])
            {
                opponentChoiceAsNumber = keyValuePair.Value;
            }
    
            if (keyValuePair.Key[1] == line[2])
            {
                playerChoiceAsNumber = keyValuePair.Value;
            }
        }
    
        playerChoiceAsNumber = playerChoiceAsNumber switch
        {
            1 when opponentChoiceAsNumber == 1 => 3,
            1 => opponentChoiceAsNumber - 1,
            2 => opponentChoiceAsNumber,
            3 when opponentChoiceAsNumber == 3 => 1,
            3 => opponentChoiceAsNumber + 1,
            _ => playerChoiceAsNumber
        };
    
        points += playerChoiceAsNumber;
    
        if (CheckIfOpponentLose(playerChoiceAsNumber, opponentChoiceAsNumber))
        {
            points += 6;
        }
        else if (playerChoiceAsNumber == opponentChoiceAsNumber)
        {
            points += 3;
        }
    }
    
    bool CheckIfOpponentLose(int playerChoiceAsNumber, int opponentChoiceAsNumber)
    {
        if (opponentChoiceAsNumber + 1 > 3)
        {
            opponentChoiceAsNumber = 1;
            return playerChoiceAsNumber == opponentChoiceAsNumber;
        }
    
        return playerChoiceAsNumber == opponentChoiceAsNumber + 1;
    }
    
    Console.WriteLine(points);
}
#endregion
#region Day3
#region Part1
static void Day3Part1()
{
    var input = File.ReadAllLines("day3.txt");

    var itemList = new List<char>();

    foreach (var line in input)
    {
        var halfInputLength = (line.Length + 1) / 2;
        var firstHalf = line[..halfInputLength];
        var secondHalf = line.Substring(halfInputLength, line.Length - halfInputLength);

        foreach (var t in secondHalf.Where(t => firstHalf.Contains(t)))
        {
            itemList.Add(t);
            break;
        }
    }

    var itemDictionary = GetDictionaryForItems();

    var totalPoints = itemList.Sum(item => itemDictionary[item]);
    Console.WriteLine(totalPoints);



    Dictionary<char, int> GetDictionaryForItems()
    {
        var dict = new Dictionary<char, int>();
        for (int i = 'A', j = 27; i <= 'z'; i++)
        {
            if ((char) i == 'Z' + 1)
            {
                j = 1;
            }

            if ((char) i > 'Z' && (char) i < 'a')
            {
                continue;
            }

            dict.Add((char) i, j);
            j++;
        }

        return dict;
    }
}
#endregion
#region  Part2

static void Day3Part2()
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
                if (input[i].Contains(input[i - 2][j]))
                {
                    itemList.Add(input[i - 2][j]);
                    break;
                }
            }
        }
    }

    var itemDictionary = GetItemsDictionary();
    var totalPoints = itemList.Sum(item => itemDictionary[item]);
    Console.WriteLine(totalPoints);

    Dictionary<char, int> GetItemsDictionary()
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
#endregion
#endregion
#region Day4
#region Day4Part1
static void Day4Part1()
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
#endregion
#region Day4Part2
static void Day4Part2()
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
#endregion
#endregion
#region Day5
#region Day5Part1
static void Day5Part1()
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
                if (!stacks.ContainsKey(1 + j / 4))
                {
                    stacks.Add(1 + j / 4, new Stack<char>());
                }

                stacks[1 + j / 4].Push(input[i][j]);
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
#endregion
#region Day5Part2
static void Day5Part2()
{
    var input = File.ReadAllLines("day5.txt");

    var phrasesToDelete = new[]{"move", "from", "to"};
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
                if (!stacks.ContainsKey(1 + j / 4))
                {
                    stacks.Add(1 + j / 4, new Stack<char>());
                }
            
                stacks[1 + j / 4].Push(input[i][j]);
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
        cratesList.Reverse();
        foreach (var crate in cratesList)
        {
            stacks[instructionsForCurrentOperation[2]].Push(crate);
        }
    }

    foreach (var stack in stacks)
    {
        Console.Write(stack.Value.Peek());
    }
}
#endregion
#endregion
#endregion
