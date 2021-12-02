public class Submarine
{
    public int Horizontal { get; set; }
    public int Depth { get; set; }
    public Submarine(int horizontal, int depth)
    {
        (Horizontal, Depth) = (horizontal, depth);
    }

    public void forward(int x)
    {
        Horizontal += x;
    }

    public void down(int x)
    {
        Depth += x;
    }

    public void up(int x)
    {
        Depth -= x;
    }

    public override string ToString()
    {
        return $"Horizontal: {Horizontal} Depth: {Depth} Multiply: {Horizontal * Depth}";
    }
}

public class AimSubmarine : Submarine
{
    int Aim { get; set; }
    public AimSubmarine(int horizontal, int depth, int aim) : base(horizontal, depth)
    {
        Aim = aim;
    }

    public new void forward(int x)
    {
        base.forward(x);
        Depth += Aim * x;
    }

    public new void down(int x)
    {
        Aim += x;
    }

    public new void up(int x)
    {
        Aim -= x;
    }

    public override string ToString()
    {
        return $"Horizontal: {Horizontal} Depth: {Depth} Aim: {Aim} Multiply: {Horizontal * Depth}";
    }
}
