string fileContent = await FileReader.ReadFileAsync();
List<string> content = FileReader.FileToStringList(fileContent);
Dictionary<string, List<string>> caves = new Dictionary<string, List<string>>();
List<List<string>> paths = new List<List<string>>();


void Paths(List<string> connectedToStart, bool projectV)
{
    if(connectedToStart.Last() == "end")
    {
        paths.Add(connectedToStart);
        return;
    }
    foreach (var direction in caves[connectedToStart.Last()])
    {
        if (!(connectedToStart.Contains(direction) && direction == direction.ToLowerInvariant()))
            Paths(new List<string>(connectedToStart) { direction }, projectV);
        else
            if (connectedToStart.Contains(direction) && direction == direction.ToLowerInvariant()
            && !projectV && direction != "start")
            Paths(new List<string>(connectedToStart) { direction }, true);
    }
}

void Initialize()
{
    foreach (var line in content)
    {
        List<string> path = line.Split('-').ToList();
        if (!caves.ContainsKey(path[0]))
            caves[path[0]] = new List<string>();
        if (!caves.ContainsKey(path[1]))
            caves[path[1]] = new List<string>();
        caves[path[0]].Add(path[1]);
        caves[path[1]].Add(path[0]);
    }
}

void Day12(bool projectV)
{
    if(caves.Count == 0)
        Initialize();
    Paths(new List<string> { "start" }, projectV);
    Console.WriteLine(paths.Count);
    paths.Clear();
}

Day12(true);
Day12(false);

