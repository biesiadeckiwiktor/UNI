
Console.WriteLine("Drawing Rectangles");

Console.WriteLine("How wide should the rectangle be");
Console.WriteLine("Please enter a number between 5 and 20 inclusive");

int width = 0;
int height = 0;

while (true)
{

    width = int.Parse(Console.ReadLine());

    if(width < 5 || width > 20)
    {
        Console.WriteLine("Please enter a number between 5 and 20 inclusive");
    }
    else
    {
        break;  
    }

}

Console.WriteLine("How tall should the rectangle be");
Console.WriteLine("Please enter a number between 5 and 20 inclusive");

while (true)
{

    height = int.Parse(Console.ReadLine());

    if (height < 5 || height > 20)
    {
        Console.WriteLine("Please enter a number between 5 and 20 inclusive");
    }
    else
    {
        break;
    }
}

for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
       
        if (i == j || i == width - j -1)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
        }
        Console.Write("*");
    }
    Console.WriteLine();
}

Console.ResetColor();

