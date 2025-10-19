# Summative 5

Goals
Write reusable methods to reduce the overall amount of code
Add exception handling where appropriate
Setting Up Your Project
For this summative challenge you should use your digital portfolio repository. You should complete this work in your Digital Portfolio Repository in GitHub.

If you have not already accepted this assignment in GitHub classroom you can do so by clicking this link: https://classroom.github.com/a/exniitfLLinks to an external site.

Problem Specification
For this task some code has been written for you here RPGCharacterCreator.csDownload RPGCharacterCreator.cs

Download the code and add it to your project.

Once you have downloaded the code read through it and try to get an understanding of what it does.

This week your job is not to add any additional functionality. Instead you are going to refactor the code. Some of the code in this solution is very similar, and performs a very similar function. In each case your job is to replace that code with a call to a method. By reusing code you have less code, and that means fewer bugs.

For example this picture shows two areas of similar code:

Include a decription of the challenge here.

## Code Listing

```cs
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to the RPG Character Creator");
// TODO 5. In the method to get a number in a range add exception handling to avoid
//FormatException(use try-catch rather than TryParse) 

int GetNumberInRange(int min, int max)
{
    if (min > max)
    {
        throw new Exception("Cannot have minimum value that's more than maximum value");
    }
    do
    {
        int number = 0;
        Console.WriteLine($"Please select number between {min} and {max} inclusive");
        try
        {
            number = int.Parse(Console.ReadLine());
        }
        catch
        {
            throw new Exception("Input must be a number");
            
        }

        if (number < min || number > max)
        {
            continue;
        }
        else
        {
            return number;
        }
    } while (true);
}

int GetSelection(string prompt, string[] options, int min, int max)
{
    Console.WriteLine(prompt);
    foreach (string element in options)
    {
        Console.WriteLine(element);
    }

    int selection = GetNumberInRange(min, max);
    return selection;
}


string GetYesOrNo(string prompt)
{
    string input = string.Empty;
    Console.WriteLine(prompt);
    Console.WriteLine("Enter Y for yes or N for no.");
    do
    {
        input = Console.ReadLine();
        if (input != "Y" && input != "N")
        {
            Console.WriteLine("Wrong input - enter Y for yes or N for no.");
        }
        else
        {
            break;
        }
    } while (input != "Y" || input != "N");
    return input;

}

// Main body

string[] menuOptions = { "1. Create a new character.", "2. Load an existing character." };
string mainMenuPrompt = "Select an option:";
int min = 1;

string[] characterTypes = { "1. Human.", "2. Elvish.", "3. Dwarvish.", "4. Goblin.", "5. Orcish."};
string characterTypePrompt = "What is your character's name?";
string input;

string classPrompt = "What is your character's class type?";
string[] classes = { "1. Warrior.", "2. Wizard.", "3. Rogue.", "4. Bard." };

string savePrompt = "Would you like to save this character to a file?";
string continuePrompt = "Would you like to make another character?";

do
{
    int selection;
    // TODO 3. Write a method to get a selection from a menu (hint, this method
    //could call the number in a range method)
do
    {
      //  Console.WriteLine("Select an option:");
       // Console.WriteLine("1. Create a new character.");
       // Console.WriteLine("2. Load an existing character.");
       // selection = int.Parse(Console.ReadLine());
       selection = GetSelection(mainMenuPrompt, menuOptions, min, menuOptions.Length);
    } while (selection < 1 || selection > 3);
    string Name = string.Empty;
    string CreatureType = string.Empty;
    string CharacterClass = string.Empty;
    int HitPoints = 20;
    int Strength = 20;
    int Magic = 10;
    int Speed = 20;
    if (selection == 1) // manual character creation
    {
        Console.WriteLine("What is your character's name?");
        Name = Console.ReadLine();
        do
        {
            // Console.WriteLine("What is your character's creature type?");
            //  Console.WriteLine("1. Human.");
            //Console.WriteLine("2. Elvish.");
            //Console.WriteLine("3. Dwarvish.");
            //Console.WriteLine("4. Goblin.");
            //Console.WriteLine("5. Orcish.");
            //Console.WriteLine("Enter a number between 1 and 5 inclusive.");
            //selection = int.Parse(Console.ReadLine());
            selection = GetSelection(characterTypePrompt, characterTypes, min, characterTypes.Length);
        } while (selection < 1 || selection > 5);
        if (selection == 1) // Human
        {
            CreatureType = "Human";
            HitPoints += 70;
            Strength += 50;
            Magic += 10;
            Speed += 30;
        }
        else if (selection == 2) // Elf
        {
            CreatureType = "Elvish";
            HitPoints += 50;
            Strength += 30;
            Magic += 40;
            Speed += 50;
        }
        else if (selection == 3) // Dwarf
        {
            CreatureType = "Dwarvish";
            HitPoints += 100;
            Strength += 80;
            Magic += 10;
            Speed += 10;
        }
        else if (selection == 4) // Goblin
        {
            CreatureType = "Goblin";
            HitPoints += 10;
            Strength += 10;
            Magic += 10;
            Speed += 40;
        }
        else if (selection == 5) // Orc
        {
            CreatureType = "Orcish";
            HitPoints += 120;
            Strength += 100;
            Speed += 20;
        }
        // TODO 4. Use the get a selection from a menu method wherever appropriate

        do
        {
            //Console.WriteLine("What is your character's class type?");
            //Console.WriteLine("1. Warrior.");
            //Console.WriteLine("2. Wizard.");
            //Console.WriteLine("3. Rogue.");
            //Console.WriteLine("4. Bard.");
            //Console.WriteLine("Enter a number between 1 and 4 inclusive.");
            //selection = int.Parse(Console.ReadLine());
            selection = GetSelection(classPrompt, classes, min, classes.Length);
        } while (selection < 1 || selection > 4);
        if (selection == 1) // Warrior
        {
            CharacterClass = "Warrior";
            Strength += 50;
            HitPoints += 50;
        }
        else if (selection == 2) // Wizard
        {
            CharacterClass = "Wizard";
            Magic += 100;
        }
        else if (selection == 3) // Rogue
        {
            CharacterClass = "Rogue";
            HitPoints += 20;
            Magic += 30;
            Speed += 50;
        }
        else if (selection == 4) // Bard
        {
            CharacterClass = "Bard";
            HitPoints += 20;
            Magic += 50;
            Speed += 30;
        }
        int bonusPointsRemaining = 30;
        int bonusPointsToAdd;
        // TODO 1. Write a method to get a number in a range
        do
        {
            Console.WriteLine($"You have {bonusPointsRemaining} bonus points to allocate to your character.");
            Console.WriteLine("How many points would you like to add to Hit Points ? ");
            // Console.WriteLine($"Enter a number between 0 and { bonusPointsRemaining} inclusive.");
            // bonusPointsToAdd = int.Parse(Console.ReadLine());
            bonusPointsToAdd = GetNumberInRange(min, bonusPointsRemaining);
        } while (bonusPointsToAdd < 0 || bonusPointsToAdd > bonusPointsRemaining);
        HitPoints += bonusPointsToAdd;
        bonusPointsRemaining -= bonusPointsToAdd;
        if (bonusPointsRemaining > 0)
        {
            // TODO 2. Use the get a number in range method wherever appropriate
            
        do
            {
                Console.WriteLine($"You have {bonusPointsRemaining} bonus points to allocate to your character.");
                Console.WriteLine("How many points would you like to add to Strength ? ");
               // Console.WriteLine($"Enter a number between 0 and { bonusPointsRemaining} inclusive.");
               // bonusPointsToAdd = int.Parse(Console.ReadLine());
                bonusPointsToAdd = GetNumberInRange(min, bonusPointsRemaining);
            } while (bonusPointsToAdd < 0 || bonusPointsToAdd >
        bonusPointsRemaining);
            Strength += bonusPointsToAdd;
            bonusPointsRemaining -= bonusPointsToAdd;
        }
        if (bonusPointsRemaining > 0)
        {
            do
            {
                Console.WriteLine($"You have {bonusPointsRemaining} bonus points to allocate to your character.");
                Console.WriteLine("How many points would you like to add to Magic ? ");
                Console.WriteLine("Any remaining points will be added to Speed.");
                //Console.WriteLine($"Enter a number between 0 and { bonusPointsRemaining} inclusive.");
                //bonusPointsToAdd = int.Parse(Console.ReadLine());
                bonusPointsToAdd = GetNumberInRange(min, bonusPointsRemaining);
            } while (bonusPointsToAdd < 0 || bonusPointsToAdd >
            bonusPointsRemaining);
            Magic += bonusPointsToAdd;
            bonusPointsRemaining -= bonusPointsToAdd;
            Speed += bonusPointsRemaining;
        }
    }
    else if (selection == 2) // load character from file
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.character");
        if (files.Length == 0)
        {
            Console.WriteLine("There are no character files to load.");
        }
        else
        {
            do
            {
                Console.WriteLine("Select an option:");
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{ files[i].Substring(files[i].LastIndexOf('\\') + 1)}");
                }
                selection = int.Parse(Console.ReadLine()) - 1;
            } while (selection < 0 && selection > files.Length - 1);
            /* Format is
            Name - name  
            Type - creature type
            Class - character class
            Stats - HitPoints Strength Magic Speed
            */
            string[] lines = File.ReadAllLines(files[selection]);
            Name = lines[0].Substring(lines[0].LastIndexOf(' ') + 1);
            CreatureType = lines[1].Substring(lines[1].LastIndexOf(' ') + 1);
            CharacterClass = lines[2].Substring(lines[2].LastIndexOf(' ') +
            1);
            lines = lines[3].Split(' ');
            HitPoints = int.Parse(lines[2]);
            Strength = int.Parse(lines[3]);
            Magic = int.Parse(lines[4]);
            Speed = int.Parse(lines[5]);
        }
    }
    Console.WriteLine($"You created {Name}, the {CreatureType} { CharacterClass} ");
    Console.WriteLine($"Hit Points - {HitPoints}");
    Console.WriteLine($"Stength - {Strength}");
    Console.WriteLine($"Magic - {Magic}");
    Console.WriteLine($"Speed - {Speed}");
    // TODO 6. Add a method to get a yes or no value from the user
   // do
   // {
        //Console.WriteLine("Would you like to save this character to a file?");
        //Console.WriteLine("Enter Y for yes or N for no.");
        //input = Console.ReadLine();
 //   } while (input != "Y" && input != "N");
    input = GetYesOrNo(savePrompt);
    if (input == "Y")
    {
        StreamWriter writer = new
        StreamWriter($"{Name}_the_{CreatureType}_{CharacterClass}.character");
        writer.WriteLine($"Name - {Name}");
        writer.WriteLine($"Type - {CreatureType}");
        writer.WriteLine($"Class - {CharacterClass}");
        writer.WriteLine($"Stats - {HitPoints} {Strength} {Magic} {Speed}");
        writer.Close();
    }
    // TODO 7. Use the get a yes or no value from the user wherever appropriate
    //do
    //{
    //    Console.WriteLine("Would you like to make another character?");
    //    Console.WriteLine("Enter Y for yes or N for no.");
    //    input = Console.ReadLine();
    //} while (input != "Y" && input != "N");
    input = GetYesOrNo(continuePrompt);
} while (input == "Y");
Console.WriteLine("Thank you for using the RPG Character Creator");
Console.WriteLine("Goodbye");

```


