int GetNumberInRange(string pPrompt, int pMin, int pMax)
{
    int result = int.MaxValue;
    do
    {
        string input;

        Console.WriteLine(pPrompt);
        Console.WriteLine($"Please enter a number between {pMin} and {pMax - 1} inclusive.");

        input = Console.ReadLine();
        try
        {
            result = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine($"{input} is not in the correct format for a number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{input} is out of range.");
        }
       

        if (result >= pMin && result < pMax)
        {
            return result;
        }
        Console.WriteLine($"{input} is not between {pMin} and {pMax - 1} inclusive.");
    } while (true);
}

int number = GetNumberInRange("Please enter a number.", 1, 101);
Console.WriteLine($"You chose {number}");
