using ChallengeNameSpace;

namespace ChallengeTestProject
{
	public class Tests
	{
		[Test]
		public void TestWhen10IsSwappedWith5()
		{
			int ten = 10;
			int five = 5;
			Challenges.Swap(ref ten, ref five);
			Assert.IsTrue(ten == 5);
			Assert.IsTrue(five == 10);
		}

		[Test]
		public void TestWhen10IsSwappedWith10()
		{
			int ten1 = 10;
			int ten2 = 10;
			Challenges.Swap(ref ten1, ref ten2);
			Assert.IsTrue(ten1 == 10);
			Assert.IsTrue(ten2 == 10);
		}

		[Test]
		public void TestWhenNegativeFiveIsSwappedWith5()
		{
			int minusFive = -5;
			int five = 5;
			Challenges.Swap(ref five, ref minusFive);
			Assert.IsTrue(five == -5);
			Assert.IsTrue(minusFive == 5);
		}

		[Test]
		public void TestFindHighestAndLowestNumberInSortedArray()
		{
			int[] numbers = { 1, 2, 3, 4, 5, 6 };
			int highest;
			int lowest;
			Challenges.FindHighestAndLowest(numbers, out highest, out lowest);
			Assert.IsTrue(highest == 6);
			Assert.IsTrue(lowest == 1);
		}

		[Test]
		public void TestFindHighestAndLowestNumberInUnsortedArray()
		{
			int[] numbers = { 3, 2, 5, 6, 1, 4 };
			int highest;
			int lowest;
			Challenges.FindHighestAndLowest(numbers, out highest, out lowest);
			Assert.IsTrue(highest == 6);
			Assert.IsTrue(lowest == 1);
		}

		[Test]
		public void TestFindHighestAndLowestNumberInArrayOfSameNumber()
		{
			int[] numbers = { 5, 5, 5, 5, 5, 5 };
			int highest;
			int lowest;
			Challenges.FindHighestAndLowest(numbers, out highest, out lowest);
			Assert.IsTrue(highest == 5);
			Assert.IsTrue(lowest == 5);
		}

		[Test]
		public void TestFindHighestAndLowestNumberInArrayOfNegativeNumbers()
		{
			int[] numbers = { -1, -2, -3, -4, -5, -6 };
			int highest;
			int lowest;
			Challenges.FindHighestAndLowest(numbers, out highest, out lowest);
			Assert.IsTrue(highest == -1);
			Assert.IsTrue(lowest == -6);
		}

		[Test]
		public void TestFindMostFrequentVowelInHelloWorld()
		{
			string input = "Hello, World!";
			char vowel = Challenges.MostFrequentVowel(input);
			Assert.IsTrue(vowel == 'o');
		}

		[Test]
		public void TestFindMostFrequentVowelInBananaSundae()
		{
			string input = "Banana Sundae";
			char vowel = Challenges.MostFrequentVowel(input);
			Assert.IsTrue(vowel == 'a');
		}

		[Test]
		public void TestFindMostFrequentVowelInEmptyString()
		{
			string input = "";
			char vowel = Challenges.MostFrequentVowel(input);
			Assert.IsTrue(vowel == 'a');
		}

		[Test]
		public void TestFindMostFrequentVowelWithNullInput()
		{
			string input = null;
			char vowel = Challenges.MostFrequentVowel(input);
			Assert.IsTrue(vowel == 'a');
		}

		[Test]
		public void TestFindMostFrequentVowelInQueue()
		{
			string input = "queue";
			char vowel = Challenges.MostFrequentVowel(input);
			Assert.IsTrue(vowel == 'e');
		}

		[Test]
		public void TestPigLatinForPigLatin()
		{
			string input = "Pig Latin";
			string output = Challenges.PigLatinTranslator(input);
			Assert.IsTrue(output == "igpay atinlay");
		}

		[Test]
		public void TestPigLatinForQueuesAreAnExcellentDatastructure()
		{
			string input = "Queues are an Excellent Datastructure";
			string output = Challenges.PigLatinTranslator(input);
			Assert.IsTrue(output == "ueuesqay earay anay ellentexcay atastructureday");
		}

		[Test]
		public void TestPigLatinFor()
		{
			string input = "You can't make an omelete without breaking a few eggs";
			string output = Challenges.PigLatinTranslator(input);
			Assert.IsTrue(output == @"ouyay an'tcay akemay anay eleteomay ithoutway eakingbray aay ewfay eggsay");
		}

		[Test]
		public void TestNumberTranslatorWith1()
		{
			string result = Challenges.NumberTranslator(1);
			Assert.IsTrue(result == "one");
		}

		[Test]
		public void TestNumberTranslatorWith5()
		{
			string result = Challenges.NumberTranslator(5);
			Assert.IsTrue(result == "five");
		}

		[Test]
		public void TestNumberTranslatorWith11()
		{
			string result = Challenges.NumberTranslator(11);
			Assert.IsTrue(result == "eleven");
		}

		[Test]
		public void TestNumberTranslatorWith26()
		{
			string result = Challenges.NumberTranslator(26);
			Assert.IsTrue(result == "twentysix");
		}

		[Test]
		public void TestNumberTranslatorWith30()
		{
			string result = Challenges.NumberTranslator(30);
			Assert.IsTrue(result == "thirty");
		}

		[Test]
		public void TestNumberTranslatorWith43()
		{
			string result = Challenges.NumberTranslator(43);
			Assert.IsTrue(result == "fortythree");
		}

		[Test]
		public void TestNumberTranslatorWith58()
		{
			string result = Challenges.NumberTranslator(58);
			Assert.IsTrue(result == "fiftyeight");
		}

		[Test]
		public void TestNumberTranslatorWith100()
		{
			string result = Challenges.NumberTranslator(100);
			Assert.IsTrue(result == "one hundred");
		}

		[Test]
		public void TestNumberTranslatorWith0()
		{
			string result = Challenges.NumberTranslator(0);
			Assert.IsTrue(result == "");
		}

		[Test]
		public void TestNumberTranslatorWith101()
		{
			string result = Challenges.NumberTranslator(101);
			Assert.IsTrue(result == "");
		}
	}
}