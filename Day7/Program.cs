string fileContent = await FileReader.ReadFileAsync();
List<int> content = FileReader.FileToIntList(fileContent, ",");

int Median(List<int> xs)
{
    var ys = xs.OrderBy(x => x).ToList();
    double mid = (ys.Count - 1) / 2.0;
    return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
}

void project1()
{
    var bestPosition = Median(content);
    int fuel = 0;
    foreach(var distance in content)
        if(distance > bestPosition)
            fuel += distance - bestPosition;
        else
            fuel += bestPosition - distance;
    Console.WriteLine(fuel);
}

void project2()
{
    int[] fuelInPositions = new int[2];
    int[] possiblePositions = new int[2];
    int i = 0;
    while (i<2)
    {
        switch (i)
        {
            case 0:
                possiblePositions[0] = (int)Math.Ceiling(content.Average());
                break;
            case 1:
                possiblePositions[1] = (int)Math.Floor(content.Average());
                break;
            default: break;
        }
        foreach (var distance in content)
        {
            int steps;
            if (distance > possiblePositions[i])
                steps = distance - possiblePositions[i];
            else
                steps = possiblePositions[i] - distance;

            fuelInPositions[i] += (int)((1 + steps) / 2.0 * steps);
        }
        i++;
    }
    Console.WriteLine(fuelInPositions.Min());
}

project1();
project2();