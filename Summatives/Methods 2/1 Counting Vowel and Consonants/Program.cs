void CountingVowelsAndConsonants(out int oNumberOfVowels, out int oNumberOfConsonants, string pString)
{
    string vowels = "aeiuo";
    string consonants = "bcdfghjklmnpqrstvwxyz";

    oNumberOfVowels = 0;
    oNumberOfConsonants = 0;

    pString = pString.ToLower();

    foreach (char ch in pString)
    {
        if (vowels.Contains(ch))
        {
            oNumberOfVowels++;
        }
        else if (consonants.Contains(ch))
        {
            oNumberOfConsonants++;
        }
    } 
}

int vowels = 0;
int consonants = 0;

Console.WriteLine("Please enter a phrase");
string input = Console.ReadLine();

CountingVowelsAndConsonants(out vowels, out consonants, input);

Console.WriteLine($"{input} has {vowels} vowels and {consonants} consonants.");