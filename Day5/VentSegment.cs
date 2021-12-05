public class VentSegment
{
    int _x1;
    int _y1;
    int _x2;
    int _y2;
    public VentSegment() { }
    public VentSegment(int x1, int y1, int x2, int y2)
    {
        (_x1, _x2, _y1, _y2) = (x1, x2, y1, y2);
    }

    public void MapGrid(List<List<int>> grid, int project)
    {
        if (_x1 != _x2 && _y1 != _y2)
            if(project == 1)
            return;
        int xstep;
        if (_x1<_x2)
            xstep = 1;
        else if (_x1>_x2)
            xstep = -1;
        else
            xstep = 0;

        int ystep;
        if (_y1 < _y2)
            ystep = 1;
        else if (_y1 > _y2)
            ystep = -1;
        else
            ystep = 0;

        int tempX = _x1;
        int tempY = _y1;
        grid[tempX][tempY] += 1;
        while (tempX != _x2 || tempY != _y2)
        {
            tempX += xstep;
            tempY += ystep;
            grid[tempX][tempY] += 1;
        }
    }

    public override string ToString()
    {
        return $"X1: {_x1} X2: {_x2} Y1: {_y1} Y2: {_y2}";
    }

}