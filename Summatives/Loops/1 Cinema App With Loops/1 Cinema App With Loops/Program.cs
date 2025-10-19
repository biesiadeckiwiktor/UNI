Console.WriteLine("Welcome to the AMAZING Nicorama Cage-athon!");
Console.WriteLine("A celebration of 30 years of Nic Cage.");

Console.WriteLine("What film would you like to see?");

Console.WriteLine("1. Leaving Las Vegas(1995) (18)");
Console.WriteLine("2. The Rock(1996)(15)");
Console.WriteLine("3. Face / Off(1997)(18)");
Console.WriteLine("4. Con Air(1997)(18)");
Console.WriteLine("5. Gone In 60 Seconds(1999)(15)");
Console.WriteLine("6. The Wicker Man(2005) (12)");
Console.WriteLine("7. Kick - Ass(2009)(15)");
Console.WriteLine("8. The Croods(2012)(U)");
Console.WriteLine("9. The Croods 2: A New Age (2020) (U)");

//int filmSelection = int.Parse(Console.ReadLine());


int filmSelection;

do
{
    Console.WriteLine("Please enter a number between 1 and 9 inclusive.");
    filmSelection = int.Parse(Console.ReadLine());
} while (filmSelection < 1 || filmSelection > 9);



if (filmSelection == 8 || filmSelection == 7)
{
    Console.WriteLine("Enjoy the film");
}
else
{
    Console.WriteLine("How old are you?");
    int age = int.Parse(Console.ReadLine());

    if (age >= 18)
    {
        Console.WriteLine("Enjoy the film");
    }
    else if (age >= 15)
    {
        if (filmSelection == 1 || filmSelection == 3 || filmSelection == 4)
        {
            Console.WriteLine("You are not old enough to see this film");
        }
        else
        {
            Console.WriteLine("Enjoy the film");
        }
    }
    else if (age >= 12)
    {
        if (filmSelection == 6)
        {
            Console.WriteLine("Enjoy the film");
        }
        else
        {
            Console.WriteLine("You are not old enough to see this film");
        }
    }
    else
    {
        Console.WriteLine("You are not old enough to see this film");
    }
}