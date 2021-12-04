string fileContents = await FileReader.ReadFileAsync();
void Day4()
{
    List<Board> boards = new List<Board>();
    List<string> content = FileReader.FileToStringList(fileContents);
    List<string> valuesToFind = content[0].Split(',').ToList();
    content.RemoveAt(0);
    List<List<string>> rowContent = content.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();

    for(int i = 0; i<rowContent.Count; i+=5)
    {
        boards.Add(new Board(rowContent.GetRange(i, 5)));
    }
    foreach(Board board in boards)
    {
        board.CheckExist(valuesToFind);
    }
    //Project1
    Board boardNo1 = boards.OrderBy(x => x.Step()).FirstOrDefault();
    Console.WriteLine(boardNo1);

    //Project2
    Board boardLast = LastBoard(valuesToFind, boards);
    Console.WriteLine(boardLast);
}

Board LastBoard(List<string> valuesToFind, List<Board> boards)
{
    Board boardLast = new Board();
    for (int i = valuesToFind.Count - 1; i > 0; i--)
    {
        foreach (Board board in boards)
        {
            if (board.LastValue() == valuesToFind[i])
            {
                boardLast = board;
                return boardLast;
            }
        }
    }
    return boardLast;
}


Day4();
