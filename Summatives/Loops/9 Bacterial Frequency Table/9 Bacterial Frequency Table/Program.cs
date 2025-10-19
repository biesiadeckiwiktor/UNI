Console.WriteLine("Bacterial Frequency Table");

int range1 = 0, rangeSum1 = 0, range2 = 0, rangeSum2 = 0, range3 = 0, rangeSum3 = 0, range4 = 0, rangeSum4 = 0, max = 0, min = 1000;


int score = 0;

do
{
    Console.WriteLine("Enter lenght: ");
    score = int.Parse(Console.ReadLine());


    if (score < min && score > 1 && score < 800) { min = score; }
    else if (score > max && score > 1 && score < 800) { max = score; }

    if (score <= 200)
    {
        range1 = range1 + 1;
        rangeSum1 = rangeSum1 + score;
    }
    if (score > 200 && score <= 399)
    {
        range2 = range2 + 1;
        rangeSum2 = rangeSum2 + score;
    }
    if (score > 400 && score <= 599)
    {
        range3 = range3 + 1;
        rangeSum3 = rangeSum3 + score;
    }
    if (score > 600 && score <= 799)
    {
        range4 = range4 + 1;
        rangeSum4 = rangeSum4 + score;
    }
  
} while (score < 800);


double rangeSum = rangeSum1 + rangeSum2 + rangeSum3 + rangeSum4;
double range = range1 + range2 + range3 + range4;

Console.WriteLine($"| Score Range | {"Count",-10} | {"Sum score",-10} | {"Percentage",-10}  |");
Console.WriteLine($"| { "<200", -10 }  | {range1,-10} | {rangeSum1,-10} | {(double)Math.Round(((range1 / range) * 100), 2),-10}% |");
Console.WriteLine($"| {"200 - 399",-10}  | {range2,-10} | {rangeSum2,-10} | {(double)Math.Round(((range2 / range) * 100), 2),-10}% |");
Console.WriteLine($"| {"400 - 599",-10}  | {range3,-10} | {rangeSum3,-10} | {(double)Math.Round(((range3 / range) * 100), 2),-10}% |");
Console.WriteLine($"| {"600 - 799",-10}  | {range4,-10} | {rangeSum4,-10} | {(double)Math.Round(((range4 / range) * 100), 2),-10}% |");
Console.WriteLine($"The mean lenght of bacteria is : {Math.Round((rangeSum / range), 2)}");
Console.WriteLine($"Minimum lenght of bacteria is : {min}");
Console.WriteLine($"Maximun lenght of bacteria is : {max}");