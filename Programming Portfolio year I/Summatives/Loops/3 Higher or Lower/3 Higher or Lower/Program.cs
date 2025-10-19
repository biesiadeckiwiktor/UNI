Console.WriteLine("Higher Or Lower?");

int secretNumber = new Random().Next(1, 101);
Console.WriteLine(secretNumber);



for (int i = 1; i<=10; i++)
{ 
    Console.WriteLine($"What is your geuss number {i}?");

    int userGuess = int.Parse(Console.ReadLine());

    if (userGuess == secretNumber)
    {
        Console.WriteLine("Congratulations, You Win!");
        break;
    }
    else if (userGuess < secretNumber)
    {
        Console.WriteLine("Higher!");
    }
    else
    {
        Console.WriteLine("Lower!");
    }

    if (i == 10)
    {
        Console.WriteLine("Better luck next time!");
    }

    }



