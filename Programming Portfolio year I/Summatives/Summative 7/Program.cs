Console.WriteLine("Hello, Mini Heroes Quest!");

// Here we create some instances of characters
Ranger ranger = new Ranger("John");
Barbarian barbarian = new Barbarian("Susan");
Mage mage = new Mage("Richard");

//Forth character created
Necromancer necromancer = new Necromancer("Jimmy");

// This is how this should be used
barbarian.SwingAxe(ranger);
ranger.FireArrows(barbarian);
mage.Heal(ranger);
Console.WriteLine();
//Forth character action
Console.WriteLine($"{necromancer.Name}'s heatlh points: {necromancer.HealthPoints}");
Console.WriteLine($"{necromancer.Name}'s energy points: {necromancer.EnergyPoints}");
necromancer.SummonSkeletonWarrior(mage);
Console.WriteLine($"{necromancer.Name}'s heatlh points: {necromancer.HealthPoints}");
Console.WriteLine($"{necromancer.Name}'s energy points: {necromancer.EnergyPoints}");
barbarian.SwingAxe(necromancer);
Console.WriteLine($"{necromancer.Name}'s heatlh points: {necromancer.HealthPoints}");
Console.WriteLine($"{necromancer.Name}'s energy points: {necromancer.EnergyPoints}");
necromancer.Rest();
Console.WriteLine($"{necromancer.Name} rested during his tour. Health and energy fully restored");
Console.WriteLine($"{necromancer.Name}'s heatlh points: {necromancer.HealthPoints}");
Console.WriteLine($"{necromancer.Name}'s energy points: {necromancer.EnergyPoints}");

// This is undesirable behaviour that we want to stop happening
//barbarian.FireArrows(mage);
//mage.SwingAxe(barbarian);