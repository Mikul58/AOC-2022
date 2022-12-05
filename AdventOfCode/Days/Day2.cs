namespace AdventOfCode.Days;

public static class Day2
{
    public static void Part2()
    {
        //Only part 2
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
            var gesturesTuple = GetPlayersValues(rockPaperScissorsDictionary, line);
            gesturesTuple.Deconstruct(out var playerChoiceAsNumber, out var opponentChoiceAsNumber);

            playerChoiceAsNumber = SetPlayerGestureFromPlayerInput(playerChoiceAsNumber, opponentChoiceAsNumber);

            points += GetPointsFromGesture(playerChoiceAsNumber);
            points += GetMatchResultPoints(playerChoiceAsNumber, opponentChoiceAsNumber);
        }

        Console.WriteLine(points);
    }

    private static Tuple<int, int> GetPlayersValues(Dictionary<char[], int> dict, string currentLine)
    {
        var playerChoiceAsNumber = 0;
        var opponentChoiceAsNumber = 0;

        foreach (var keyValuePair in dict)
        {
            if (keyValuePair.Key[0] == currentLine[0])
            {
                opponentChoiceAsNumber = keyValuePair.Value;
            }

            if (keyValuePair.Key[1] == currentLine[2])
            {
                playerChoiceAsNumber = keyValuePair.Value;
            }

            if (playerChoiceAsNumber != 0 && opponentChoiceAsNumber != 0)
            {
                break;
            }
        }

        return new Tuple<int, int>(playerChoiceAsNumber, opponentChoiceAsNumber);
    }

    private static int GetMatchResultPoints(int playerChoiceAsNumber, int opponentChoiceAsNumber)
    {
        var points = 0;
        points += GetPointsForWin(playerChoiceAsNumber, opponentChoiceAsNumber);
        points += GetPointsForDraw(playerChoiceAsNumber, opponentChoiceAsNumber);

        return points;
    }

    private static int SetPlayerGestureFromPlayerInput(int playerChoiceAsNumber, int opponentChoiceAsNumber)
        => playerChoiceAsNumber switch
        {
            1 when opponentChoiceAsNumber == 1 => 3,
            1 => opponentChoiceAsNumber - 1,
            2 => opponentChoiceAsNumber,
            3 when opponentChoiceAsNumber == 3 => 1,
            3 => opponentChoiceAsNumber + 1,
            _ => playerChoiceAsNumber
        };

    private static int GetPointsForWin(int playerChoiceAsNumber, int opponentChoiceAsNumber)
    {
        var points = 0;

        if (opponentChoiceAsNumber + 1 > 3 && playerChoiceAsNumber == 1)
        {
            points = 6;
        }
        else if (playerChoiceAsNumber == opponentChoiceAsNumber + 1)
        {
            points = 6;
        }

        return points;
    }

    private static int GetPointsFromGesture(int playerChoiceAsNumber)
        => playerChoiceAsNumber;

    private static int GetPointsForDraw(int playerChoiceAsNumber, int opponentChoiceAsNumber)
        => playerChoiceAsNumber == opponentChoiceAsNumber ? 3 : 0;
}
