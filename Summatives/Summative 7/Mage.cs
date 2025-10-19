
public class Mage : Character
{
    public Mage(string name) : base(name)
    {
        MaxHealthPoints = 8;
        MaxEnergyPoints = 8;
        HealthPoints = MaxHealthPoints;
        EnergyPoints = MaxEnergyPoints;
    }
    /// <summary>
    /// Damage: 2; Energy cost: 2
    /// </summary>
    /// <param name="target"></param>
    public void ThrowFireball(Character target)
    {
        if (IsKnockedOut || EnergyPoints < 2)
        {
            return;
        }

        Console.WriteLine($"{Name} the mage threw a fireball at {target.Name}.");
        target.HealthPoints -= 2;
        EnergyPoints -= 2;
    }
    /// <summary>
    /// Restores health: 5; Energy cost: 1 
    /// </summary>
    /// <param name="target"></param>
    public void Heal(Character target)
    {
        if (IsKnockedOut || EnergyPoints < 1)
        {
            return;
        }

        EnergyPoints -= 1;
        target.HealthPoints += 5;
        Console.WriteLine($"{Name} the mage used healing spell on {target.Name}."); // Added code to display information on screen
    }
}