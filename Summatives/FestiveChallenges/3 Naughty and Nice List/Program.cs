int lumpsOfCoal = 0;

string[] toys =
{
"Book",
"Teddy Bear",
"Barbie Doll",
"Action Man Figure",
"Lego Set",
"Toy Car",
"Bag of Sweet",
"Bike",
"Wooly Jumper",
"Orange"
};

int[] howManyToys = new int [toys.Length];

string filename = "NaughtyNiceList.txt";


StreamReader reader = new StreamReader(filename);
string[]lines = File.ReadAllLines(filename);
foreach (string line in lines)
{
    int a = line.IndexOf('[');
    int b = line.IndexOf("-");
    int goodDeeds = int.Parse(line.Substring(a +1, b- a-1));
    int c = line.IndexOf(']');
    int badDeeds = int.Parse(line.Substring(b + 1, c - b - 1));
    if (goodDeeds > badDeeds)
    {
        for (int i = 0; i < howManyToys.Length; i++)
        {
            if (line.Contains(toys[i]))
            {
                howManyToys[i]++;
            }
        }
    }
    else
    {
        lumpsOfCoal++;
    }
}

Console.WriteLine("Santa will need to bring: ");
for (int i = 0;i < howManyToys.Length;i++)
{
    Console.WriteLine($"{howManyToys[i]} {toys[i]}s");
}


