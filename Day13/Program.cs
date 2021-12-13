string fileContent = await FileReader.ReadFileAsync();
List<string> content = FileReader.FileToStringList(fileContent);
List<string> folds = content.Where(x => x.Contains("f")).Select(line => string.Join("", line.Split(' ').Skip(2))).ToList();
List<List<int>> dots = content.Where(x => x.Contains(','))
    .Select(line => line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList<int>()).ToList();

int CountForTrue(bool[,] grid)
{
    int counter = 0;
    for (int y = 0; y < grid.GetLength(1); y++)
        for (int x = 0; x < grid.GetLength(0); x++)
            if (grid[x, y])
                counter++;
    return counter;
}

void GridActivateDots(bool[,] grid)
{
    foreach (var line in dots)
        grid[line[0], line[1]] = true;
}

(int,int) FindNewGridBorders(bool[,] grid)
{
    (int maxX, int maxY) = (int.MinValue, int.MinValue);
    for (int y = 0; y < grid.GetLength(1); y++)
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            if (maxX < x && grid[x, y])
                maxX = x;
            if (maxY < y && grid[x, y])
                maxY = y;
        }
    return (maxX, maxY);
}

void GenerateResultP2(int maxX, int maxY, bool[,] grid)
{
    for (int y = 0; y < maxY + 1; y++)
    {
        for (int x = 0; x < maxX + 1; x++)
        {
            if (grid[x, y])
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
}

void Day13()
{
    int maxX = dots.Select(x => x[0]).Max() + 1;
    int maxY = dots.Select(x => x[1]).Max() + 1;
    bool[,] grid = new bool[maxX, maxY];
    GridActivateDots(grid);

    for (int i = 0; i < folds.Count; i++)
    {
        var current = folds[i].Split('=').ToList();
        int foldValue = Int32.Parse(current[1]);
        switch (current[0])
        {
            case "x":
                for (int y = 0; y < grid.GetLength(1); y++)
                    for (int x = foldValue; x < grid.GetLength(0); x++)
                        if (grid[x, y])
                        {
                            grid[x, y] = false;
                            if (foldValue < x)
                                grid[foldValue * 2 - x, y] = true;
                            else
                                grid[x, y * 2 - foldValue] = true;
                        }
                break;
            case "y":
                for (int y = foldValue; y < grid.GetLength(1); y++)
                    for (int x = 0; x < grid.GetLength(0); x++)
                        if (grid[x, y])
                        {
                            grid[x, y] = false;
                            if (foldValue < y)
                                grid[x, foldValue * 2 - y] = true;
                            else
                                grid[x * 2 - foldValue, y] = true;
                        }
                break;
        }
        if (i == 0)
            Console.WriteLine(CountForTrue(grid));
    }
    (maxX, maxY) = FindNewGridBorders(grid);
    GenerateResultP2(maxX,maxY,grid);

}

Day13();