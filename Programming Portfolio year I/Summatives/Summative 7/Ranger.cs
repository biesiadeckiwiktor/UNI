
public class Ranger : Character
{
    public int NumberOfArrows { get; private set; }
    public int FiredArrows { get; private set; }

    public Ranger(string name) : base(name)
    {
        MaxHealthPoints = 10;
        MaxEnergyPoints = 8;
        NumberOfArrows = 10;
        HealthPoints = MaxHealthPoints;
        EnergyPoints = MaxEnergyPoints;
    }
    /// <summary>
    /// Collects projectile: 1
    /// </summary>
    public void CollectArrows()
    {
        NumberOfArrows += FiredArrows;
        FiredArrows = 0;
    }
    /// <summary>
    /// Damage: 1; Energy cost: 1; Projectile cost: 1
    /// </summary>
    /// <param name="target"></param>
    public void FireArrows(Character target)
    {
        if (IsKnockedOut || NumberOfArrows <= 0 || EnergyPoints < 1)
        {
            return;
        }

        EnergyPoints -= 1;
        NumberOfArrows--;
        FiredArrows++;
        Console.WriteLine($"{Name} the ranger shot an arrow at {target.Name}.");
        target.HealthPoints -= 1;
    }
}
