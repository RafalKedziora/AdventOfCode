public class Board
{
    List<List<string>> _valueLines;
    List<List<bool?>> _stateBoard;
    private int _steps;
    public bool shouldContinue;
    string lastValue;
    public Board(List<List<string>> rowContent)
    {
        _valueLines = rowContent;
        _stateBoard = new List<List<bool?>>();
        _steps = 0;
        shouldContinue = true;
        lastValue = String.Empty;

        foreach (var row in rowContent)
        {
            var currentRow = new List<bool?>();
            foreach (var value in row)
            {
                currentRow.Add(null);
            }
            _stateBoard.Add(currentRow);
        }
    }
    public Board(){}

    public int Step()
    {
        return _steps;
    }

    public string LastValue()
    {
        return lastValue;
    }

    private bool CheckExistColumn(int k)
    {
        bool isWin = true;
        bool result = true;
        for(int j = 0; j < _stateBoard.Count; j++)
        {
            if (!isWin.Equals(_stateBoard[j][k]))
                result = false;
        }
        return result;
    }

    public bool CheckExist(List<string> valuesToFind)
    {
        for (int i = 0; i < valuesToFind.Count; i++)
        {
            for (int j = 0; j < _valueLines.Count; j++)
            {
                for (int k = 0; k < _valueLines[j].Count; k++)
                {
                    if (_stateBoard[j][k] != true)
                    {
                        if (_valueLines[j][k] == valuesToFind[i])
                        {
                            _stateBoard[j][k] = true;
                            if (CheckExistColumn(k))
                            {
                                lastValue = valuesToFind[i];
                                return true;
                            }
                        }
                        else
                            _stateBoard[j][k] = false;
                        _steps++;
                    }
                }
            }
            if (i >= 5)
                foreach (var row in _stateBoard)
                    if (row.All(x => x.Value == true))
                        shouldContinue = false;
            if (shouldContinue == false)
            {
                lastValue = valuesToFind[i];
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        string text = "";
        text += "StateBoard\n";
        foreach (var row in _stateBoard)
        {
            foreach(var value in row)
            {
                text = text + value + ' ';
            }
            text += "\n";
        }
        text += "\nValueLines\n";
        foreach (var row in _valueLines)
        {
            foreach (var value in row)
            {
                text = text + value + ' ';
            }
            text += "\n";
        }
        return $"Board: \n{text}\nSteps: {_steps}\nScore: {Score()}\nlast:{lastValue}";
    }

    public int Score()
    {
        int score = 0;
        for(int i = 0; i < _valueLines.Count; i++)
        {
            for(int j = 0; j < _valueLines[i].Count; j++)
            {
                if(_stateBoard[i][j] == false)
                {
                    score += Int32.Parse(_valueLines[i][j]);
                }
            }
        }
        Console.WriteLine(score);
        score *= Int32.Parse(lastValue);
        return score;
    }
}
