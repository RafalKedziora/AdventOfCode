async Task<int> project1()
{
    int counter = 0;
    string fileContents = await FileReader.ReadFileAsync();
    List<int> fileLines = FileReader.FileToIntList(fileContents);
    for (int i = 1; i < fileLines.Count; i++)
        if (fileLines[i] > fileLines[i - 1])
            counter++;
    return counter;
}

async Task<int> project2()
{
    string fileContents = await FileReader.ReadFileAsync();
    List<int> fileLines = FileReader.FileToIntList(fileContents);
    var prev = fileLines[0] + fileLines[1] + fileLines[2];
    int counter = 0;
    for (int i = 1; i < fileLines.Count - 2; i++)
    {
        int current = fileLines[i] + fileLines[i + 1] + fileLines[i + 2];
        if (prev < current)
        {
            counter++;
        }
        prev = current;
    }
    return counter;
}

Console.WriteLine(await project1());
Console.WriteLine(await project2());