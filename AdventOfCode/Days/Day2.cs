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
}
