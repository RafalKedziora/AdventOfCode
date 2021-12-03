string fileContents = await FileReader.ReadFileAsync();
void project1()
{
    List<string> sbMoves = FileReader.FileToStringList(fileContents);
    Submarine sb = new Submarine(0, 0);

    foreach (string s in sbMoves)
    {
        string[] sArr = s.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        int value = Int32.Parse(sArr[1]);
        switch (sArr[0])
        {
            case "forward":
                sb.forward(value);
                break;
            case "down":
                sb.down(value);
                break;
            case "up":
                sb.up(value);
                break;
        }
    }
    Console.WriteLine(sb.ToString());
}

void project2()
{
    List<string> sbMoves = FileReader.FileToStringList(fileContents);
    AimSubmarine asb = new AimSubmarine(0, 0, 0);
    foreach (string s in sbMoves)
    {
        string[] sArr = s.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        int value = Int32.Parse(sArr[1]);
        switch (sArr[0])
        {
            case "forward":
                asb.forward(value);
                break;
            case "down":
                asb.down(value);
                break;
            case "up":
                asb.up(value);
                break;
        }
    }
    Console.WriteLine(asb.ToString());
}

project1();
project2();
