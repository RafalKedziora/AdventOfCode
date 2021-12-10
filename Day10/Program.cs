string fileContent = await FileReader.ReadFileAsync();
List<string> content = FileReader.FileToStringList(fileContent);
Dictionary<char, char> brackets = new Dictionary<char, char>()
{
    { '{', '}' },
    { '[', ']' },
    { '(', ')' },
    { '<', '>' }
};

int Project1()
{
    Dictionary<char, int> points = new Dictionary<char, int>()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 }
    };
    Stack<char> characters = new Stack<char>();
    int result = 0;
    foreach(var row in content)
        foreach(var letter in row)
        {
            if (brackets.ContainsKey(letter))
                characters.Push(letter);
            else
            {
                char top = characters.Pop();
                if(letter != brackets[top])
                    if(points.ContainsKey(letter))
                        result += points[letter];
            }
        }
    return result;
}

long Project2()
{
    Dictionary<char, int> points = new Dictionary<char, int>()
    {
        { '(', 1 },
        { '[', 2 },
        { '{', 3 },
        { '<', 4 }
    };
    List<long> results = new List<long>();
    foreach(var row in content)
    {
        Stack<char> characters = new Stack<char>();
        bool incomplete = false;
        long result = 0;
        foreach (var letter in row)
        {
            if (brackets.ContainsKey(letter))
                characters.Push(letter);
            else
            {
                char top = characters.Pop();
                if(letter != brackets[top])
                {
                    incomplete = true;
                    break;
                }
            }
        }
        while(characters.Count > 0 && !incomplete)
        {
            char letter = characters.Pop();
            if(points.ContainsKey(letter))
                result = result*5 + points[letter];
        }
        results.Add(result);
    }
    results.RemoveAll(x => x == 0);
    results.Sort();
    return results[results.Count / 2];
}

Console.WriteLine( Project1() );
Console.WriteLine( Project2() );
