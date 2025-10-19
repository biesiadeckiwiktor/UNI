using System;
using System.Text;
using System.Collections.Generic;

namespace Capstone.Menus
{
	/// <summary>
	/// Provides helper methods for console input and output.
	/// </summary>
	internal static class ConsoleHelpers
	{
		/// <summary>
		/// Gets a string input from the user.
		/// </summary>
		/// <param name="prompt">The prompt to display to the user.</param>
		/// <returns>The string entered by the user.</returns>
		public static string GetString(string prompt)
		{
			Console.Write($"{prompt}: ");
			return Console.ReadLine();
		}

		/// <summary>
		/// Gets an integer input from the user within a specified range.
		/// </summary>
		/// <param name="min">The minimum allowed value.</param>
		/// <param name="max">The maximum allowed value.</param>
		/// <param name="prompt">The prompt to display to the user.</param>
		/// <returns>The integer entered by the user.</returns>
		/// <exception cref="Exception">Thrown when the minimum value is greater than the maximum value.</exception>
		public static int GetIntegerInRange(int min, int max, string prompt)
		{
			if (min > max)
			{
				throw new Exception($"Minimum value {min} cannot be greater than maximum value {max}");
			}

			while (true)
			{
				Console.Write($"{prompt} ({min}-{max}): ");
				if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
				{
					return result;
				}
				Console.WriteLine($"Please enter a number between {min} and {max}.");
			}
		}

		/// <summary>
		/// Gets a decimal input from the user.
		/// </summary>
		/// <param name="prompt">The prompt to display to the user.</param>
		/// <returns>The decimal entered by the user.</returns>
		public static decimal GetDecimal(string prompt)
		{
			while (true)
			{
				Console.Write($"{prompt}: ");
				if (decimal.TryParse(Console.ReadLine(), out decimal result))
				{
					return result;
				}
				Console.WriteLine("Please enter a valid number.");
			}
		}

		/// <summary>
		/// Gets a yes/no response from the user.
		/// </summary>
		/// <param name="prompt">The prompt to display to the user.</param>
		/// <returns>True if the user responds with 'y' or 'Y', false otherwise.</returns>
		public static bool GetYesNo(string prompt)
		{
			Console.Write($"{prompt} (y/n): ");
			string response = Console.ReadLine().ToLower();
			return response == "y" || response == "yes";
		}

		/// <summary>
		/// Displays a list of items as a menu and prompts the user to select one.
		/// </summary>
		/// <param name="items">The list of items to display in the menu.</param>
		/// <param name="prompt">The prompt message to display to the user.</param>
		/// <returns>The index of the selected item (zero-based).</returns>
		public static int GetSelectionFromMenu(IEnumerable<string> items, string prompt)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(prompt);

			int itemNumber = 0;

			foreach (string item in items)
			{
				itemNumber++;
				sb.AppendLine($"{itemNumber}. {item}");
			}

			if (itemNumber == 0)
			{
				Console.WriteLine("No items available to select.");
				return -1; // Return a default value indicating no selection
			}

			return GetIntegerInRange(1, itemNumber, sb.ToString()) - 1;
		}

		/// <summary>
		/// Displays the current transaction details.
		/// </summary>
		/// <param name="sale">The current sale to display.</param>
		public static void DisplayTransaction(Sale sale)
		{
			if (sale == null)
			{
				Console.WriteLine("No active transaction.");
				Console.WriteLine(new string('-', 40));
				return;
			}

			Console.WriteLine("CURRENT TRANSACTION");
			Console.WriteLine(new string('-', 40));

			if (sale.Items.Count == 0)
			{
				Console.WriteLine("No items in transaction.");
			}
			else
			{
				foreach (var item in sale.Items)
				{
					Console.WriteLine($"{item} - {FormatPrice(item.PriceInPence)}");
				}
			}

			Console.WriteLine(new string('-', 40));
			Console.WriteLine($"TOTAL: {FormatPrice(sale.TotalPrice)}");
			Console.WriteLine(new string('-', 40));
			Console.WriteLine();
		}

		/// <summary>
		/// Formats a price in pence as a string with pound symbol.
		/// </summary>
		/// <param name="priceInPence">The price in pence.</param>
		/// <returns>A formatted price string.</returns>
		public static string FormatPrice(int priceInPence)
		{
			return $"£{priceInPence / 100.0:F2}";
		}

		/// <summary>
		/// Pauses execution and waits for user input before continuing.
		/// </summary>
		public static void PauseForUser()
		{
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}
}