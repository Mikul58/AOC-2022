// See https://aka.ms/new-console-template for more information

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
#endregion
