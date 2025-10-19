// See https://aka.ms/new-console-template for more information
namespace ChallengeNameSpace
{
	public class Challenges
	{
		/// <summary>
		/// Swaps the values of the two arguments.
		/// After this method has been executed the first argument will have the value of the second argument
		/// and the second argument will have the value of the first argument.
		/// </summary>
		/// <param name="number1">first number to swap</param>
		/// <param name="number2">second number to swap</param>
		public static void Swap(ref int number1, ref int number2)
		{
			int temp = 0;
			temp = number1;
            number1 = number2;
            number2 = temp;
            Console.WriteLine(number1);
            Console.WriteLine(number2);
        }

		/// <summary>
		/// Finds the highest and lowest values in an array of integers.
		/// After this method has been executed the highest argument will be assigned the highest value in the array
		/// and the lowest argument will be assigned the lowest value in the array.
		/// </summary>
		/// <param name="numbers">The array of integers</param>
		/// <param name="highest">Will be assigned the highest value in the array</param>
		/// <param name="lowest">Will be assigned the lowest value in the array</param>
		public static void FindHighestAndLowest(int[] numbers, out int highest, out int lowest)
		{
			// your code here
			highest = int.MinValue;
			lowest = int.MaxValue;
            foreach (var item in numbers)
            {
                if (item > highest)
				{
					highest = item;
                }

				if (item < lowest)
				{
                    lowest = item;
                }
            }
            Console.WriteLine($"Highest number is {highest}");
            Console.WriteLine($"Lowest number is {lowest}");
        }

		/// <summary>
		/// Returns the most frequently occuring vowel in the input string.
		/// If more than one vowel occurs with the same frequency then the priority order is "aeiou"
		/// </summary>
		/// <param name="input">string to be examined</param>
		/// <returns>Returns most frequently occuring vowel</returns>
		public static char MostFrequentVowel(string input)
		{
            if (input == null)
            {
                Console.WriteLine('a');
                return 'a';
            }
            // your code here
            string vowels = "aeiou";
			char[] vowelsArray = vowels.ToCharArray();
            int[] numberOfVowels = new int[vowels.Length];
            char[] abc = input.ToCharArray();
            foreach (var item in abc)
            {
                if (item == 'a')
                {
                    numberOfVowels[0]++;
                }
                if (item == 'e')
                {
                    numberOfVowels[1]++;
                }
                if (item == 'i')
                {
                    numberOfVowels[2]++;
                }
                if (item == 'o')
                {
                   numberOfVowels[3]++;
                }
                if (item == 'u')
                {
                    numberOfVowels[4]++;
                }
            }
			if (numberOfVowels[0] == 0 && numberOfVowels[1] == 0 && numberOfVowels[2] == 0 && numberOfVowels[3] == 0 && numberOfVowels[4] == 0)
			{
                Console.WriteLine('a');
                return 'a';
            }
            for (int i = 0; i < numberOfVowels.Length - 1; i++) 
            {
                for (int j = 0; j < numberOfVowels.Length - i - 1; j++)
                {
                    if (numberOfVowels[j] < numberOfVowels[j + 1])
                    {
                        int temporaryNumber = numberOfVowels[j];
                        numberOfVowels[j] = numberOfVowels[j + 1];
                        numberOfVowels[j + 1] = temporaryNumber;

                        char temporaryChar = vowelsArray[j]; 
                        vowelsArray[j] = vowelsArray[j + 1];
                        vowelsArray[j + 1] = temporaryChar;
                    }
                }
            }
			Console.WriteLine(vowelsArray[0]);
            return vowelsArray[0];
		}

		/// <summary>
		/// This method takes a string argument and translates it to PigLatin
		/// To find out abut PigLatin refer to https://en.wikipedia.org/wiki/Pig_Latin
		/// </summary>
		/// <param name="phrase">The phrase to be translated to pig latin</param>
		/// <returns>The input translated into pig latin</returns>
		public static string PigLatinTranslator(string phrase)
		{
            // your code here
            string vowels = "aeiou";
            string[] words = SplitString(phrase);

            for (int i = 0; i < words.Length; i++)
            {
                string tempString = words[i];
                tempString = tempString.ToLower();
                char firstLetter = tempString[0];
                if (!vowels.Contains(firstLetter))
                {
                    int firstVowelIndex = tempString.IndexOfAny(vowels.ToCharArray());
                    if (firstVowelIndex != -1)
                    {
                        string prefix = tempString.Substring(0, firstVowelIndex);
                        string suffix = tempString.Substring(firstVowelIndex);
                        words[i] = suffix + prefix + "ay";
                    }
                    else
                    {
                        words[i] += "ay";
                    }
                }
                else
                {
                    int secondVowelIndex = -1;
                    for (int j = 1; j < tempString.Length; j++)
                    {
                        if (vowels.Contains(tempString[j]))
                        {
                            secondVowelIndex = j;
                            break;
                        }
                    }
                    if (secondVowelIndex != -1)
                    {
                        string prefix = tempString.Substring(0, secondVowelIndex);
                        string suffix = tempString.Substring(secondVowelIndex);
                        words[i] = suffix + prefix + "ay";
                    }
                    else
                    {
                        words[i] += "ay";
                    }
                }
            }
            string finalString = string.Empty;
            foreach (var item in words)
            {
                finalString = finalString + item + " ";
            }
            Console.WriteLine(finalString);
            finalString = finalString.Trim();
            return finalString;
        }

        static int NumberOfVowels(string input)
        {
            int count = 0;
            foreach (var item in input)
            {
                if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
                {
                    count++;
                }
            }
            return count;
        }

        static string[] SplitString(string input)
        {
            string[] words = input.Split(' ');
            return words;
        }


        /// <summary>
        /// This method takes a number between 1 and 100 inclusive and returns
        /// a string that contains the same number in English words. If the number parameter
        /// is outside the specified range then an empty string is returned.
        /// </summary>
        /// <param name="pNumber">The number to be changed into English words</param>
        /// <returns>A string that contains the input number in English words</returns>
        public static string NumberTranslator(int pNumber)
		{
            if (pNumber < 1 || pNumber > 100)
            {
                return string.Empty;
            }
            else
            {
                string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                       "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (pNumber < 20)
                {
                    Console.WriteLine(units[pNumber]);
                    return units[pNumber];
                }
                else if (pNumber < 100)
                {
                    int ten = pNumber / 10;
                    int unit = pNumber % 10;
                    Console.WriteLine(unit == 0 ? tens[ten] : $"{tens[ten]}{units[unit]}");
                    return unit == 0 ? tens[ten] : $"{tens[ten]}{units[unit]}";
                }
                else
                {
                    Console.WriteLine("one hundred");
                    return "one hundred";
                }
            }
            // your code here
		}

		static void Main()
		{
			// you can make method calls here if you like
			int number1 = 10;
            int number2 = 5;
            Swap(ref number1, ref number2);

			//int[] numbers = { 1, 2, 3, 4, 5, 6 };
            //int[] numbers = { 3, 2, 5, 6, 1, 4 };
			//int[] numbers = { 5, 5, 5, 5, 5, 5 };
			int[] numbers = { -1, -2, -3, -4, -5, -6 };

			FindHighestAndLowest(numbers, out int highest, out int lowest);
       
			MostFrequentVowel("Hello, World!");
			MostFrequentVowel("Banana Sundae");
			MostFrequentVowel("");
            MostFrequentVowel(null);
			MostFrequentVowel("queue");

            //PigLatinTranslator("Pig Latin");
            PigLatinTranslator("Queues are an Excellent Datastructure");
            //PigLatinTranslator("You can't make an omelete without breaking a few eggs");

            NumberTranslator(1);
            NumberTranslator(10);
            NumberTranslator(11);
            NumberTranslator(12);
            NumberTranslator(13);
            NumberTranslator(14);
            NumberTranslator(20);
            NumberTranslator(30);
            NumberTranslator(37);
            NumberTranslator(99);
            NumberTranslator(100);
            NumberTranslator(101);
        }
    }
}
