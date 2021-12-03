string fileContents = await FileReader.ReadFileAsync();

IEnumerable<string> matchQuery(List<string> diagnosticChecks, char checkValue, int index)
{
    var matchQueyry = from number in diagnosticChecks
                      where number[index] == checkValue
                      select number;
    return matchQueyry;
}

void project1()
{
    List<string> diagnosticChecks = FileReader.FileToStringList(fileContents);
    string gammaRate = "";
    string epsilonRate = "";
    for(int i = 0; i < diagnosticChecks[0].Length; i++)
    {
        int zeroCount = matchQuery(diagnosticChecks, '0', i).Count();
        int oneCount = matchQuery(diagnosticChecks, '1', i).Count();
        if (zeroCount > oneCount)
        {
            gammaRate += '0';
            epsilonRate += '1';
        }
        else
        {
            gammaRate += '1';
            epsilonRate += '0';
        }
    }
    int gamma = Convert.ToInt32(gammaRate, 2);
    int epsilon = Convert.ToInt32(epsilonRate, 2);
    Console.WriteLine($"gammaRate: {gammaRate} in Decimal: {gamma} \n" +
                      $"epsilonRate: {epsilonRate} in Decimal: {epsilon}\n" +
                      $"Multiplied: {gamma * epsilon}");
}

string Rating(List<string> diagnosticChecks, bool oxygen)
{
    var _localDiagnosticChecks = new List<string>(diagnosticChecks);
    for (int i = 0; i < _localDiagnosticChecks[0].Length; i++)
    {
        if (_localDiagnosticChecks.Count == 1)
        {
            return _localDiagnosticChecks[0];
        }
        var zeroQuery = matchQuery(_localDiagnosticChecks, '0', i);
        var oneQuery = matchQuery(_localDiagnosticChecks, '1', i);
        int zeroCount = zeroQuery.Count();
        int oneCount = oneQuery.Count();
        if(oxygen)
        {
            if (zeroCount > oneCount)
                _localDiagnosticChecks.RemoveAll(x => oneQuery.Contains(x));
            else
                _localDiagnosticChecks.RemoveAll(x => zeroQuery.Contains(x));
        }
        else 
        {
            if (zeroCount > oneCount)
                _localDiagnosticChecks.RemoveAll(x => zeroQuery.Contains(x));
            else
                _localDiagnosticChecks.RemoveAll(x => oneQuery.Contains(x));
        }
    }
    return _localDiagnosticChecks.FirstOrDefault();
}

void project2()
{
    List<string> diagnosticChecks = FileReader.FileToStringList(fileContents);
    string oxygenRating = Rating(diagnosticChecks, true);
    string co2Rating = Rating(diagnosticChecks, false);


    int oxygenConverted = Convert.ToInt32(oxygenRating, 2);
    int co2Converted = Convert.ToInt32(co2Rating, 2);
    Console.WriteLine($"oxygenRating: {oxygenRating} Decimal: {oxygenConverted}\n" +
                      $"CO2Rating: {co2Rating} Decimal: {co2Converted}\n" +
                      $"Multiplied: {oxygenConverted*co2Converted}");
}

project1();
Console.WriteLine(Environment.NewLine);
project2();