void DrawStar(int pOffset)
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    string spaces = new string(' ', pOffset);
    Console.Write(spaces);
    Console.WriteLine("*");
    Console.ForegroundColor = ConsoleColor.White;
}

void DrawTree(int pHeight)
{
    DrawStar(pHeight);
    
    for (int i = 0; i < pHeight; i++)
    {
        for (int j = 0; j < pHeight - i; j++)
        {
            Console.Write(" ");
        }
        for (int j = 0; j < 2 * i + 1; j++)
        {
            Random rnd = new Random();
            int light = rnd.Next(0,2);
            if (light != 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(' ');
            }
            else
            {
                Random abc = new Random();
                int colour = abc.Next(0,4);
                Console.BackgroundColor = ConsoleColor.Green;
                if (colour == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('*');
                }
                if (colour == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('*');
                }
                if (colour == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('*');
                }
                if (colour == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('*');
                }
                if (colour == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('*');
                }
                Console.ForegroundColor= ConsoleColor.White;
            }
        }
        Console.BackgroundColor = ConsoleColor.Black;
       
        Console.WriteLine();
    }
}

void DrawTrunk(int offset, int thickness, int height)
{
    for (int i = 0;i < height;i++)
    {
        for (int j=0; j < offset - thickness/2;j++)
        {
            Console.Write(' ');
        }
        for(int j = 0;j < thickness;j++)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        Console.WriteLine();
    }
}

DrawTree(30);
DrawTrunk(30, 3, 2);


