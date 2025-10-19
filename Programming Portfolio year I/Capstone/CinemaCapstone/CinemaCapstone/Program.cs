// See https://aka.ms/new-console-template for more information
using Capstone;
using Capstone.Menus;
using System;
using System.IO;
using System.Collections.Generic;

Console.WriteLine("Hello, Capstone!");
Console.WriteLine("Welcome to Hull-ywood Cinema!");
Console.WriteLine("");

string path = $@"{Environment.CurrentDirectory}\Resources";
string[] files = Directory.GetFiles(path, "*.txt");

bool configurationLoaded = false;
while (!configurationLoaded)
{
    try
    {
        int selection = ConsoleHelpers.GetSelectionFromMenu(files, "Select a file to load");
        Console.WriteLine("");
        
        ConfigurationLoader.LoadFromFile(files[selection]);
        Console.WriteLine("Configuration loaded successfully!");
        
        // Display loaded items
        Console.WriteLine("Loaded Movies:");
        foreach (Movie movie in ConfigurationLoader.GetAllMovies())
        {
            Console.WriteLine($"- {movie}");
        }
        Console.WriteLine("");

        Console.WriteLine("Available Concessions:");
        foreach (string concession in ConfigurationLoader.GetAllConcessions())
        {
            Console.WriteLine($"- {concession}");
        }
        Console.WriteLine("");

        Console.WriteLine("Staff Members:");
        foreach (Staff staff in Staff.GetAllStaff())
        {
            Console.WriteLine($"- {staff.Name} (ID: {staff.Id})");
        }
        Console.WriteLine("");

        configurationLoaded = true;
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine("Please try again with a different file.");
    }
    catch (InvalidDataException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine("Please ensure your configuration file contains valid entries in the format:");
       
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading configuration: {ex.Message}");
        Console.WriteLine("Please try again with a different file.");
    }

    if (!configurationLoaded)
    {
        Console.WriteLine("\nPress any key to try again...");
        Console.ReadKey();
        Console.Clear();
    }
}

Sale sale = new Sale();
StaffSelectionMenu menu = new StaffSelectionMenu();
menu.Select();