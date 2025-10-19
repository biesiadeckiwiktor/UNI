Console.WriteLine("How many items do you need to buy?");

int numberOfItems = int.Parse(Console.ReadLine());

string[] shoppingList = new string[numberOfItems];
string filename;

for (int i = 0; i < numberOfItems; i++)
{
    Console.WriteLine($"Please enter item number {i+1}");
    shoppingList[i] = Console.ReadLine();
}

filename = GetFileName();
WritetoFile();

string GetFileName()
{
    Console.WriteLine("What file would you like to save your shopping list to?");
    do
    {
        filename = Console.ReadLine();
        if (File.Exists(filename) == true)
        {
            Console.WriteLine("This file already exists, please enter different name");
            continue;
        }
        else
        {
            break;
        }
    } while (true);
    return filename;
}

void WritetoFile()
{
    using (StreamWriter writer = new StreamWriter(filename))
    {
        writer.WriteLine("Shopping List " + DateTime.Now.Date);

        foreach (string item in shoppingList)
        {
            writer.WriteLine(item);
        }
    }
}