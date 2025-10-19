
public class Necromancer : Character
{
    public Necromancer(string name) : base(name)
    {
        MaxHealthPoints = 10;
        MaxEnergyPoints = 10;
        HealthPoints = MaxHealthPoints;
        EnergyPoints = MaxEnergyPoints;
    }
    /// <summary>
    /// Damage: 4; Energy cost: 2
    /// </summary>
    /// <param name="target"></param>
    public void SummonSkeletonWarrior(Character target)
    {
        if (IsKnockedOut || EnergyPoints < 2)
        {
            return;
        }

        Console.WriteLine($"{Name} the necromancer summoned a skeleton warrior. The creature attacks {target.Name}.");
        target.HealthPoints -= 4;
        EnergyPoints -= 2;
    }

}