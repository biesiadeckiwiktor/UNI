using static System.Runtime.InteropServices.JavaScript.JSType;

void NumericNurseryRhymes()
{
    int selection = 0;
    PickANurseryRhyme();

    int PickANurseryRhyme()
    {
        Console.WriteLine("Please select nursery rhyme:");
        Console.WriteLine("1. Fat Sasuages");
        Console.WriteLine("2. Speckled Frogs");
        selection = int.Parse(Console.ReadLine());
        return selection;
    }

    if (selection == 1)
    {
        Console.WriteLine("Please enter starting number of sasuages");
        int sasuages = -1;
        do
        {
            sasuages = int.Parse(Console.ReadLine());
            if (sasuages % 2 == 0)
            {
                DisplayFatSausages(sasuages);
            }
            else
            {
                Console.WriteLine("Number of sausages needs to be a even number");
                
            }
        } while (sasuages % 2 != 0);
    }
    else if (selection == 2)
    {
        Console.WriteLine("Please enter starting number of frogs");
        int frogs = int.Parse(Console.ReadLine());
        DisplaySpeckledFrogs(frogs);
    }

    void DisplaySpeckledFrogs(int StartingNumberOfFrogs)
    {
        for (int i = StartingNumberOfFrogs; i >= 1; i--)
        {
            Console.WriteLine($"{i} green speckled frogs");
            Console.WriteLine("Sitting on a speckled log");
            Console.WriteLine("Eating the most delicious bugs, yum, yum");
            Console.WriteLine();
            if (i > 2)
            {
                Console.WriteLine("1 jumped into the pool");
                Console.WriteLine("Where it was nice and cool");
                Console.WriteLine($"Now there is {i - 1} speckled frogs glub glub");
                Console.WriteLine();
            }
            else if (i == 1)
            {
                Console.WriteLine("1 jumped into the pool");
                Console.WriteLine("Where it was nice and cool");
                Console.WriteLine($"Now there is 1 speckled frog glub glub");
                Console.WriteLine();
                Console.WriteLine("He jumped into the pool");
                Console.WriteLine("Where it was nice and cool");
                Console.WriteLine("Now there are no more speckled frogs");
                Console.WriteLine();
            }
        } 
    }

    void DisplayFatSausages(int StartingNumberOfSausages)
    {
        for(int i = StartingNumberOfSausages; i > -1 ; i = i - 2)
        {
            Console.WriteLine($"{i} fat sasuages sizzling in the pan, one wnt pop and the other went bang");
        }
    }
}

void PrimeNumbersInRange()
{
    Console.WriteLine("Please enter first number from range");
    int firstNumber = int.Parse( Console.ReadLine() );
    Console.WriteLine("Please enter last number from range");
    int lastNumber = int.Parse( Console.ReadLine() );

    int numberOfPrimeNumbers = 0;
    for (int i = firstNumber; i <= lastNumber; i++)
    {
        if (IsPrime(i) == true)
        {
            numberOfPrimeNumbers++;
        }
    }

    Console.WriteLine(numberOfPrimeNumbers);

    bool IsPrime(int pNumber)
    {
        if (pNumber == 1) return false;
        if (pNumber == 2) return true;
        for (int i = 2; i <= pNumber / 2; ++i)
            if (pNumber % i == 0)
                return false;
        return true;
    }
}


void NumberOfVowelsInString()
{
    Console.WriteLine("Please choose your string");
    Console.WriteLine("1. \"Hello, World!\"");
    Console.WriteLine("2. \"C# is Fun, WOOO!\"");
    Console.WriteLine("3. \"HElLo, WOrlD!\"");
    Console.WriteLine("4. \"Queues are an Excellent Datastucture\"");

    int selection = int.Parse(Console.ReadLine() );

    string firstString = "Hello, World!";
    string secondString = "C# is Fun, WOOO!";
    string thirdString = "HElLo, WOrlD!";
    string forthString = "Queues are an Excellent Datastucture";
    

    Display();

    void Display()
    {
        if (selection == 1)
        {
            Vowel(firstString);
        }
        else if (selection == 2)
        {
            Vowel(secondString);
        }
        else if (selection == 3)
        {
            Vowel(thirdString);
        }
        else if (selection == 4)
        {
            Vowel(forthString);
        }
    }



    void Vowel(string myString)
    {
        myString = myString.ToLower();
        int counter = 0;
        for (int i = 0; i < myString.Length; ++i)
        {
            if (myString[i] == 'a' || myString[i] == 'e' || myString[i] == 'i' || myString[i] == 'o' || myString[i] == 'u')
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }

}

void PigLatin()
{
    // Your code here
}

void DisplayChallenges()
{
    int challengeSelection = 0;
    do
    {
        Console.WriteLine("1. Numeric Nursery Rhymes");
        Console.WriteLine("2. Number of Prime Numbers in Range");
        Console.WriteLine("3. Number of Vowels in a String");
        Console.WriteLine("4. Pig Latin");
        Console.WriteLine("5. Exit");
        challengeSelection = int.Parse(Console.ReadLine());

        if (challengeSelection == 1)
        {
            NumericNurseryRhymes();
        }
        else if (challengeSelection == 2)
        {
            PrimeNumbersInRange();
        }
        else if (challengeSelection == 3)
        {
            NumberOfVowelsInString();
        }
        else if (challengeSelection == 4)
        {
            PigLatin();
        }
        else if (challengeSelection == 5)
        {
            Console.WriteLine("Have a nice day. Goodbye!");
            break;
        }

    } while (true);
}

DisplayChallenges();