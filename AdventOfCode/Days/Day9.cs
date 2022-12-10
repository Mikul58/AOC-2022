namespace AdventOfCode.Days;

public class Day9
{
    public static void Part1()
    {
        var input = File.ReadAllLines("day9.txt");
        int[] headCurrentCoordinates = {1000, 1000};

        var headCoordinatesList = new List<Tuple<int, int>>();
        var tailCoordinatesList = new List<Tuple<int, int>>();

        headCoordinatesList.Add(new Tuple<int, int>(headCurrentCoordinates[0], headCurrentCoordinates[1]));
        tailCoordinatesList.Add(new Tuple<int, int>(headCurrentCoordinates[0], headCurrentCoordinates[1]));

        foreach (var line in input)
        {
            var direction = line[0];
            var stepsTowardsDirectionCount = line[2] - '0';

            switch (direction)
            {
                case 'R':
                    headCurrentCoordinates[1] += stepsTowardsDirectionCount;
                    headCoordinatesList.Add(new Tuple<int, int>(headCurrentCoordinates[0], headCurrentCoordinates[1]));
                    break;
                case 'L':
                    headCurrentCoordinates[1] -= stepsTowardsDirectionCount;
                    headCoordinatesList.Add(new Tuple<int, int>(headCurrentCoordinates[0], headCurrentCoordinates[1]));
                    break;
                case 'U':
                    headCurrentCoordinates[0] += stepsTowardsDirectionCount;
                    headCoordinatesList.Add(new Tuple<int, int>(headCurrentCoordinates[0], headCurrentCoordinates[1]));
                    break;
                case 'D':
                    headCurrentCoordinates[0] -= stepsTowardsDirectionCount;
                    headCoordinatesList.Add(new Tuple<int, int>(headCurrentCoordinates[0], headCurrentCoordinates[1]));
                    break;
            }

            var differenceBetweenHeadAndTail = new Tuple<int, int>(
                headCoordinatesList.Last().Item1 - tailCoordinatesList.Last().Item1,
                headCoordinatesList.Last().Item2 - tailCoordinatesList.Last().Item2);

            Console.WriteLine(differenceBetweenHeadAndTail);

            if (differenceBetweenHeadAndTail.Item1 <= 1 && differenceBetweenHeadAndTail.Item2 <= 1)
            {
                continue;
            }

            if ((differenceBetweenHeadAndTail.Item1 == 0 || differenceBetweenHeadAndTail.Item2 == 0) &&
                stepsTowardsDirectionCount > 1)
            {
                var lastHeadCoordinate = headCoordinatesList.Last();
                var lastLeftHeadCoordinate = lastHeadCoordinate.Item1;
                var lastRightHeadCoordinate = lastHeadCoordinate.Item2;


                switch (direction)
                {
                    case 'L':
                    {
                        stepsTowardsDirectionCount -= 2 * stepsTowardsDirectionCount;
                        var newCoordinates = new Tuple<int, int>(lastLeftHeadCoordinate, lastRightHeadCoordinate + stepsTowardsDirectionCount);
                        tailCoordinatesList.Add(newCoordinates);
                        break;
                    }
                    case 'D':
                    {
                        stepsTowardsDirectionCount -= 2 * stepsTowardsDirectionCount;
                        var newCoordinates = new Tuple<int, int>(lastLeftHeadCoordinate + stepsTowardsDirectionCount, lastRightHeadCoordinate);
                        tailCoordinatesList.Add(newCoordinates);
                        break;
                    }
                    case 'R':
                    {
                        var newCoordinates = new Tuple<int, int>(lastLeftHeadCoordinate, lastRightHeadCoordinate + stepsTowardsDirectionCount);
                        tailCoordinatesList.Add(newCoordinates);
                        break;
                    }
                    case 'U':
                    {
                        var newCoordinates = new Tuple<int, int>(lastLeftHeadCoordinate + stepsTowardsDirectionCount, lastRightHeadCoordinate);
                        tailCoordinatesList.Add(newCoordinates);
                        break;
                    }
                }
            }
        }

        foreach (var headCoordinates in headCoordinatesList)
        {
            Console.WriteLine($"({headCoordinates.Item1}, {headCoordinates.Item2})");
        }
    }
}
