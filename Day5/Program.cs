string fileContents = await FileReader.ReadFileAsync();
List<string> content = FileReader.FileToStringList(fileContents);
List<VentSegment> segments = new List<VentSegment>();
foreach (var item in content)
{
    var ventSegment = item.Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
    segments.Add(new VentSegment(Int32.Parse(ventSegment[0][0]), Int32.Parse(ventSegment[0][1]), Int32.Parse(ventSegment[1][0]), Int32.Parse(ventSegment[1][1])));
}
void project1()
{
    List<List<int>> grid = new List<List<int>>();
    for (int i = 0; i < 1000; i++)
        grid.Add(Enumerable.Repeat(0, 1000).ToList());
    foreach (var segment in segments)
    {
        segment.MapGrid(grid, 1);
    }

    int test = 0;
    foreach(var line in grid)
    {
        foreach(var item in line)
        {
            if (item > 1)
            { test++; }
        }
    }
    Console.WriteLine(test);
}

void project2()
{
    List<List<int>> grid = new List<List<int>>();
    for (int i = 0; i < 1000; i++)
        grid.Add(Enumerable.Repeat(0, 1000).ToList());
    foreach (var segment in segments)
    {
        segment.MapGrid(grid, 2);
    }

    int test = 0;
    foreach (var line in grid)
    {
        foreach (var item in line)
        {
            if (item > 1)
            { test++; }
        }
    }
    Console.WriteLine(test);
}

project1();
project2();
