public class FileReader
{
    public static async Task<string> ReadFileAsync()
    {
        string fileContents;
        using (var reader = File.OpenText("input.txt"))
            fileContents = await reader.ReadToEndAsync();
        return fileContents;
    }

    public static List<int> FileToIntList(string listOfStrings)
    {
        return listOfStrings.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();
    }

    public static List<string> FileToStringList(string listOfStrings)
    {
        return listOfStrings.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}