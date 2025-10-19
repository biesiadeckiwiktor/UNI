
Console.WriteLine("Fizz Buzz Application");

Console.WriteLine("How high should we go?");

Console.WriteLine();

int limit = int.Parse(Console.ReadLine());

int fizz = 0;
int buzz = 0;
int fizzBuzz = 0;
int numbers = 0;

for (int i = 0; i < limit; i++)
{
    if (i % 3 == 0)
    {
        fizz++;
    }
    else if (i % 3 == 0 && i % 5 == 0)
    {
        fizzBuzz++;
    }
    else if (i % 5 == 0)
    {
        buzz++;
    }
    else
    {
        numbers++;
    }
}

Console.WriteLine(string.Format("{0} {1} {2} {3}", fizz, buzz, fizzBuzz, numbers));