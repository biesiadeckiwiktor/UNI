Console.WriteLine("Tardy Train Monitoring Application");
int late = 0;
int howMany = 0;
int lastLate = 0;
do
{
    Console.WriteLine("How many minutes was the train late?");
    late = int.Parse(Console.ReadLine());
    howMany++;
    if (late > 0)
    {
        lastLate = late;
    }

} while (late > 0);

Console.WriteLine($"{howMany} out of {howMany} trains were late");
Console.WriteLine($"last train was {lastLate} minutes late");