    // Parent charactyer class - contains all common methods and inforemation for characters
public class Character
{
    private int _healthPoints;
    private int _energyPoints;
    public string Name { get; private set; }
    public int MaxHealthPoints { get; protected set; }
    public int MaxEnergyPoints { get; protected set; }

    public int HealthPoints
    {
        get { return _healthPoints; }
        set
        {
            if (value < MaxHealthPoints) { _healthPoints = value; }
            else { _healthPoints = MaxHealthPoints; }
        }
    }

    public int EnergyPoints
    {
        get { return _energyPoints; }
        protected set
        {
            if (value < MaxEnergyPoints) { _energyPoints = value; }
            else { _energyPoints = MaxEnergyPoints; }
        }
    }
    
    public Character(string name)
    {
        Name = name;
    }

    public bool IsKnockedOut => HealthPoints <= 0;
    /// <summary>
    /// Fully resores health and energy.
    /// </summary>
    public virtual void Rest()
    {
        if (!IsKnockedOut)
        {
            EnergyPoints = MaxEnergyPoints;
            HealthPoints = MaxHealthPoints;
        }
    }
    public void Slap(Character target)
    {
        if (IsKnockedOut || EnergyPoints < 1)
        {
            return;
        }

        Console.WriteLine($"{Name} slapped {target.Name}.");
        target.HealthPoints -= 1;
        EnergyPoints -= 1;
    }

}
