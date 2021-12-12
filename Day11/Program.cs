string fileContent = await FileReader.ReadFileAsync();
List<string> content = FileReader.FileToStringList(fileContent);

Octopus[,] OctopusContent()
{
    int xAmount = content[0].Length;
    int yAmount = content.Count;
    Octopus[,] octopuses = new Octopus[xAmount, yAmount];

    for (int y = 0; y < yAmount; y++)
        for (int x = 0; x < xAmount; x++)
            octopuses[x, y] = new Octopus((int)char.GetNumericValue(content[y][x]), false);
    return octopuses;
}

static void AddEnergyAdjacent(int x, int y, int sizeX, int sizeY, ref int flashed, Octopus[,] octopuses)
{
    for (int tempY = y - 1; tempY <= y + 1; tempY++)
        for (int tempX = x - 1; tempX <= x + 1; tempX++)
            if ((tempY >= 0 && tempY < sizeY) && (tempX >= 0 && tempX < sizeX))
            {
                if (octopuses[tempX, tempY]._energy != 0)
                    octopuses[tempX, tempY]._energy++;
                if (octopuses[tempX, tempY]._energy > 9)
                {
                    flashed++;
                    octopuses[tempX, tempY]._energy = 0;
                    AddEnergyAdjacent(tempX, tempY, sizeX, sizeY, ref flashed, octopuses);
                }
            }
}

void Day11(int project)
{
    int sizeX = content[0].Length;
    int sizeY = content.Count;
    Octopus[,] octopuses = OctopusContent();
    int flashed = 0, result = 0;
    int steps = project == 1 ? 101 : 1001;

    for (int i = 1; i < steps; i++)
    {
        foreach (var octopus in octopuses)
            octopus.AddEnergy();

        for (int y = 0; y < sizeY; y++)
            for (int x = 0; x < sizeX; x++)
                if (octopuses[x, y]._energy > 9)
                {
                    flashed++;
                    octopuses[x, y]._energy = 0;
                    AddEnergyAdjacent(x, y, sizeX, sizeY,ref flashed, octopuses);
                }

        if (octopuses[0, 0]._energy == 0 && octopuses[sizeX - 1, 0]._energy == 0
            && octopuses[0, sizeY - 1]._energy == 0 && octopuses[sizeX - 1, sizeY - 1]._energy == 0)
        {
            int tempCounter = 0;
            for (int y = 0; y < sizeY; y++)
                for (int x = 0; x < sizeX; x++)
                    if (octopuses[x, y]._energy == 0)
                        tempCounter++;

            if (tempCounter == sizeY * sizeX)
            {
                result = i;
                break;
            }
        }
    }
    Console.WriteLine(project == 1? flashed : result);
}

Day11(1);
Day11(2);