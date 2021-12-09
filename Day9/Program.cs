string fileContent = await FileReader.ReadFileAsync();
List<string> content = FileReader.FileToStringList(fileContent);

(int j, int i) neighbours(int j, int i, int[,] data)
{
    int min = int.MaxValue;
    int minJ = j;
    int minI = i;
    if (j > 0 && data[j - 1, i] < min)
        (min, minJ, minI) = (data[j - 1, i], j - 1, i);
    if (j < content[i].Length - 1 && data[j+1, i] < min)
        (min, minJ, minI) = (data[j + 1, i], j + 1, i);
    if (i > 0 && data[j, i - 1] < min)
        (min, minJ, minI) = (data[j, i-1], j, i-1);
    if ((i < content.Count - 1) && data[j, i + 1] < min)
        (min, minJ, minI) = (data[j, i + 1], j, i + 1);
    return (minJ, minI);
}

int[,] Data()
{
    int[,] data = new int[content[0].Length, content.Count];
    for (int i = 0; i < content.Count; i++)
        for (int j = 0; j < content[i].Length; j++)
            data[j, i] = (int)char.GetNumericValue(content[i][j]);
    return data;
}

void Project1()
{
    int[,] data = Data();
    int result = 0;

    for (int i = 0; i < content.Count; i++)
        for (int j = 0; j < content[i].Length; j++)
        {
            var neighbour = neighbours(j, i, data);
            if (data[j, i] < data[neighbour.j, neighbour.i])
                result += data[j, i] + 1;
        }
    Console.WriteLine(result);

}

void Project2()
{
    int[,] data = Data();
    int[,] basinSizes = new int[content[0].Length, content.Count];
    for(int i = 0; i < content.Count; i++)
        for(int j=0; j < content[i].Length; j++)
        {
            int activeJ = j;
            int activeI = i;
            int current = data[j, i];
            if (current == 9) 
                continue;
            (int flowJ, int flowI) = neighbours(j, i, data);
            while (data[flowJ, flowI] < current)
            {
                activeJ = flowJ;
                activeI = flowI;
                current = data[flowJ, flowI];
                (flowJ, flowI) = neighbours(activeJ, activeI, data);
            }
            basinSizes[activeJ, activeI]++;
        }
    Console.WriteLine(basinSizes.OfType<int>().OrderByDescending(x => x).Take(3).Aggregate(1, (x, y) => x * y));
}

Project1();
Project2();
