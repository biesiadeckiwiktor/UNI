
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, Green Grocers!");

string filename = "FruitAndVeg.txt";

int GetWeight(string line)
{
    return int.Parse(line.Substring(line.IndexOf(':') + 1, 3));
}

int Average(int total, int count)
{
    return total / count;
}

int Min(int currentResult, int min)
{
    if (currentResult < min)
    {
        min = currentResult;
    }
    return min;
}

int Max(int currentResult,int max)
{
    if (currentResult > max)
    {
        max = currentResult;
    }
    return max;
}

int PotatoeMax = 0;
int PotatoeMin = int.MaxValue;

int TomatoMax = 0;
int TomatoMin = int.MaxValue;

int AppleMax = 0;
int AppleMin = int.MaxValue;

int BananaMax = 0;
int BananaMin = int.MaxValue;

int CarrotMax = 0;
int CarrotMin = int.MaxValue;

int fruit = 0;
int veg = 0;

int potato = 0;
int tomato = 0;
int apple = 0;
int banana = 0;
int carrot = 0;

int potatoWeight = 0;
int tomatoWeight = 0;
int appleWeight = 0;
int bananaWeight = 0;
int carrotWeight = 0;

if (File.Exists(filename))
{
    StreamReader reader = new StreamReader(filename);
    int numberOfLines = 0;
    while (!reader.EndOfStream)
    {
        reader.ReadLine();
        numberOfLines++;
    }
    string[] lines = new string[numberOfLines];
    reader.BaseStream.Seek(0, SeekOrigin.Begin);
    int lineIndex = 0;
    while (!reader.EndOfStream)
    {
        lines[lineIndex] = reader.ReadLine();
        lineIndex++;
    }
    reader.Close();
    for (int i = 0; i < lines.Length; i++)
    {
        // Console.WriteLine(lines[i]);
    }
    for (int i = 0; i < lines.Length; i++)
    {

        if (lines[i].Contains("Potato"))
        {
            potato++;
            veg++;
            int weight = GetWeight(lines[i]);
            potatoWeight += weight;
            Min(weight, PotatoeMin);
            Max(weight, PotatoeMax);
            if (weight > PotatoeMax)
            {
                PotatoeMax = weight;
            }
            else if (weight < PotatoeMin)
            {
                PotatoeMin = weight;
            }
        }
        else if (lines[i].Contains("Tomato"))
        {
            tomato++;
            veg++;
            int weight = GetWeight(lines[i]);
            tomatoWeight += weight;
            Min(weight, TomatoMin);
            Max(weight, TomatoMax);
            if (weight > TomatoMax)
            {
                TomatoMax = weight;
            }
            else if (weight < TomatoMin)
            {
                TomatoMin = weight;
            }
        }
        else if (lines[i].Contains("Apple"))
        {
            apple++;
            fruit++;
            int weight = GetWeight(lines[i]);
            appleWeight += weight;
            Min(weight, AppleMin);
            Max(weight, AppleMax);
            if (weight > AppleMax)
            {
                AppleMax = weight;
            }
            else if (weight < AppleMin)
            {
                AppleMin = weight;
            }
        }
        else if (lines[i].Contains("Banana"))
        {
            fruit++;
            banana++;
            int weight = GetWeight(lines[i]);
            bananaWeight += weight;
            Min(weight, BananaMin);
            Max(weight, BananaMax);
            if (weight > BananaMax)
            {
                BananaMax = weight;
            }
            else if (weight < BananaMin)
            {
                BananaMin = weight;
            }
        }
        else if (lines[i].Contains("Carrot"))
        {
            veg++;
            carrot++;
            int weight = GetWeight(lines[i]);
            carrotWeight += weight;
            Min(weight, CarrotMin);
            Max(weight, CarrotMax);
            if (weight > CarrotMax)
            {
                CarrotMax = weight;
            }
            else if (weight < CarrotMin)
            {
                CarrotMin = weight;
            }

        }
        using (StreamWriter writer = new StreamWriter("Potatoes.txt"))
            foreach (string line in lines)
            {
                if (line.Contains("Potato"))
                {
                    string newLine = line.Substring(line.IndexOf(':') + 1, 3);
                    //Console.WriteLine(newLine);
                    writer.WriteLine(newLine);
                }
            }
    }
}
else
{
    Console.WriteLine($"{filename} does not exist");
}

Console.WriteLine($"Heaviest potatio is {PotatoeMax}, lightest potatoe is {PotatoeMin}");
Console.WriteLine($"Heaviest tomato is {TomatoMax}, lightest tomato is {TomatoMin}");
Console.WriteLine($"Heaviest apple is {AppleMax}, lightest apple is {AppleMin}");
Console.WriteLine($"Heaviest banana is {BananaMax}, lightest banana is {BananaMin}");
Console.WriteLine($"Heaviest carrot is {CarrotMax}, lightest carrot is {CarrotMin}");
Console.WriteLine($"Total number of vegetables is {veg}");
Console.WriteLine($"Total number of fruit is {fruit}");
Console.WriteLine($"Average weight of potatoe is {Average(potatoWeight,potato)}");
Console.WriteLine($"Average weight of tomato is {Average(tomatoWeight, tomato)}");
Console.WriteLine($"Average weight of apple is {Average(appleWeight, apple)}");
Console.WriteLine($"Average weight of banana is {Average(bananaWeight, banana)}");
Console.WriteLine($"Average weight of carrot is {Average(carrotWeight, carrot)}");


