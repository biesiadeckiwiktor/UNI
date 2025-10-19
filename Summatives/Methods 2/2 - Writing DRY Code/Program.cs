string vowels = "aeiuo";
string consonants = "bcdfghjklmnpqrstvwxyz";
string input = string.Empty;
int CountingCharacters(string pString, string pCharactersToCount)
{
    pString = pString.ToLower();
    int numberOfCharacters = 0;
    foreach (var item in pString)
    {
        if (pCharactersToCount.Contains(item))
        {
            numberOfCharacters++;
        }
    }
    return numberOfCharacters;
}

do
{
    Console.WriteLine("Please enter a phrase");
    input = Console.ReadLine();
    Console.WriteLine("Please choose vowels (1) or consonants (2)");
    string choice = int.Parse(Console.ReadLine()) == 1 ? vowels : consonants;
    if (choice == vowels)
    {
        Console.WriteLine($"{input} has {CountingCharacters(input, vowels)} vowels.");
        break;
    }
    else if (choice == consonants)
    {
        Console.WriteLine($"{input} has {CountingCharacters(input, consonants)} consonants.");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }
} while (true);
