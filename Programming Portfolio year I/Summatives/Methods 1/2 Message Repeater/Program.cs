void MessageRepeater(string Message, int Repetitions = 1)
{
    for (int i = 1; i <= Repetitions; i++)
    {
    Console.WriteLine($"{i}. {Message}");
}
}

MessageRepeater("Hello, World!", 5);
MessageRepeater("Goodbye!");

int SumValues(int[] pArray)
{
    int total = 0;

    for (int i = 0; i < pArray.Length; i++)
    {
        total = total + pArray[i];
    }

    return total;
}

int[] numbers = { 10, 2, 5, 7, 13, 8, 4 };

int sum = SumValues(numbers);

Console.WriteLine(sum); // output should be 49

numbers = new int[] { 1, 2, 3, 4, 5 };

sum = SumValues(numbers);

Console.WriteLine(sum); // output should be 15