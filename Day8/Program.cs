using System.Text;

static string ComputeValue(List<string> inputsPattern, string line)
{
    if (line.Length == 5)
        if (inputsPattern[0].All(x => line.Contains(x)))
            return "3"; 
        else if (inputsPattern[3].Where(x => !inputsPattern[2].Contains(x)).All(x => line.Contains(x)))
            return "2";
        else
            return "5";
    else if (line.Length == 6)
        if (inputsPattern[1].All(x => line.Contains(x)))
            return "0";
        else if (inputsPattern[2].All(x => line.Contains(x)))
            return "9";
        else
            return "6";
    return null;
}

async Task<int> Day8(int project)
{
    List<string> fileContent = FileReader.FileToStringList(await FileReader.ReadFileAsync());
    int result = 0;
    int i = 1;
    foreach (string line in fileContent)
    {
        List<string> singleLine = line.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
        List<string> outputs = singleLine[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        if(project == 1)
        result += outputs.Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7).Count();
        else
        {
            List<string> inputsPattern = singleLine[0].Trim().Split(" ").Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7).OrderBy(i => i.Length).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var output in outputs)
            {
                sb.Append(output.Length == 2 ? "1" : output.Length == 3 ? "7" : output.Length == 4 ? "4" : output.Length == 7 ? "8" :
                          ComputeValue(inputsPattern, output));
            }
            result += int.Parse(sb.ToString());
        }
    }
    return result;
}

Console.WriteLine(await Day8(2));
