
public class Barbarian : Character
{
    public Barbarian(string name) : base(name)
    {
        MaxHealthPoints = 18;
        MaxEnergyPoints = 12;
        HealthPoints = MaxHealthPoints;
        EnergyPoints = MaxEnergyPoints;
    }
    /// <summary>
    /// Damage: 3; Energy cost: 3
    /// </summary>
    /// <param name="target"></param>
    public void SwingAxe(Character target)
    {
        if (IsKnockedOut || EnergyPoints < 3)
        {
            return;
        }

        Console.WriteLine($"{Name} the barbarian swung their mighty axe at {target.Name}.");
        target.HealthPoints -= 5; // Taking away health points instead of energy points now
        EnergyPoints -= 3;
    }
}
