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
    double average = content.Average();
    int bestPosition;

    if(average - Math.Floor(average) >= 0.6)
        bestPosition = (int)Math.Ceiling(average);
    else
        bestPosition = (int)Math.Floor(average);
    
    int fuel = 0;
    foreach (var distance in content)
    {
        int steps;
        if (distance > bestPosition)
            steps = distance - bestPosition;
        else
            steps = bestPosition - distance;

        fuel += (int)((1 + steps) / 2.0 * steps);
    }
    Console.WriteLine(fuel);
}

project1();
project2();