public class FileReader
{
    public static async Task<string> ReadFileAsync(string name = "input.txt")
    {
        string fileContents;
        using (var reader = File.OpenText(name))
            fileContents = await reader.ReadToEndAsync();
        return fileContents;
    }

    public static List<int> FileToIntList(string listOfStrings, string splitValue = "\n")
    {
        return listOfStrings.Split(splitValue, StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();
    }

    public static List<string> FileToStringList(string listOfStrings, string splitValue = "\n")
    {
        return listOfStrings.Split(splitValue, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}