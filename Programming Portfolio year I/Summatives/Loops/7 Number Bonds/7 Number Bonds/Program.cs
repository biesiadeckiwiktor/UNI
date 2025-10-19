Console.WriteLine("Number Bonds!");

Console.WriteLine("Please enter a number between 1 and 20");

int number = 0;
int secondNumber = 0;
int thirdNumber = 0;

while (true)
{

    number = int.Parse(Console.ReadLine());

    if (number < 1 || number > 20)
    {
        Console.WriteLine("Please enter a number between 1 and 20 inclusive");
    }
    else
    {
        break;
    }

}

thirdNumber = number;

for (int i = 0; i < number; i++)
{
    Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", secondNumber, "+", thirdNumber, "=", number));
    secondNumber++;
    thirdNumber--;
} 