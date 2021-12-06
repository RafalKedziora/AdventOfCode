string fileContent = await FileReader.ReadFileAsync();
List<string> content = fileContent.Split(',').ToList();
void Day6(int days)
{
    var lanternfishes = new List<int>();
    long[] valuesPerDay = new long[10];
    foreach (var item in content)
        lanternfishes.Add(Int32.Parse(item));
    foreach (var currentDay in lanternfishes)
        valuesPerDay[currentDay] += 1;
    for (int i = 0; i < days; i++)
    {
        valuesPerDay[valuesPerDay.Length - 1] += valuesPerDay[0];
        valuesPerDay[valuesPerDay.Length - 3] += valuesPerDay[0];
        valuesPerDay[0] = 0;
        for (int j = 1; j < valuesPerDay.Length; j++)
            (valuesPerDay[j - 1], valuesPerDay[j]) = (valuesPerDay[j], valuesPerDay[j - 1]);
    }
    Console.WriteLine("lanternfishes: " + valuesPerDay.Sum());
}

Day6(80);
Day6(256);