Console.WriteLine("Oyster eating competition");
int competitors = 0;
do
{
    Console.WriteLine("How many competitors are there?");
    competitors = int.Parse(Console.ReadLine());

    string[] competitorsNames = new string[competitors];
    int[] oystersEaten = new int[competitors];

    for (int i = 0, j = 1; i < competitors; i++, j++)
    {
        Console.WriteLine("What's competitors number " + j + " name?");
        competitorsNames[i] = Console.ReadLine();

        Console.WriteLine($"How many oysters did {competitorsNames[i]} ate?");
        oystersEaten[i] = int.Parse(Console.ReadLine());
    }

    int n = oystersEaten.Length;

    int temporaryNumber;

    string temporaryName;

    for (int i = 0; i < n - 1; i++) // sorting loop
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (oystersEaten[j] < oystersEaten[j + 1])
            {
                temporaryNumber = oystersEaten[j];
                oystersEaten[j] = oystersEaten[j + 1];
                oystersEaten[j + 1] = temporaryNumber;

                temporaryName = competitorsNames[j]; // sorting names at the same time
                competitorsNames[j] = competitorsNames[j + 1];
                competitorsNames[j + 1] = temporaryName;
            }
        }
    }
     //saveing results to file
    using(StreamWriter myFile = new ("results.txt"))
    for (int i = 0, j = 1; i < 3; i++, j++)
    {
        myFile.WriteLine($"{j}. {competitorsNames[i]} ate {oystersEaten[i]} oysters");
    }
} while (true);

