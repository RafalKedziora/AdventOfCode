public class Octopus
{
    public bool _flashed;
    public int _energy;

    public Octopus(int energy, bool flashed)
    {
        (_energy, _flashed) = (energy, flashed);
    }

    public void AddEnergy()
    {
        _energy++;
    }
}