Console.WriteLine("Prime Numbers");

Console.WriteLine("Please enter a number between 2 and " + uint.MaxValue);

uint number = uint.Parse(Console.ReadLine());

for (int i = 2; i<= number; i++)
    {
        if (number % i == 0)
        {
            Console.WriteLine(number + " is not prime number");
            return;
        }

    }
Console.WriteLine(number + " is a prime number");
