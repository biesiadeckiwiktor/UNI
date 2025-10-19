Console.WriteLine("Please select a file to load");
string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.mark");

int userInput = 0;
string id = null, lastName = null, firstName = null, challenges = null, exam = null, capstone = null;
int[] marksAsIntigers = null;
float finalMarkPercentage = 0, digitalPortfolioPercentage = 0, openBookExamPercentage = 0, capstoneProjectPercentage = 0;
string[] grades = {" First", " 2:1", " 2:2", " Third", " Fail"};
int[] gradesCount = new int[grades.Length];

for (int i = 0; i < files.Length; i++) { Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}"); } //Displaying available options
                                       
do // Asking user to chose file and validating
{
    Console.WriteLine($"Please enter number between 1 and {files.Length}");
    userInput = Int32.Parse(Console.ReadLine());
} while (userInput < 1 || userInput > files.Length);

//reading lines from a file
string[] lines = File.ReadAllLines(files[userInput - 1]);
string[] dataArray = new string[lines.Length];

// removing file extension from file name
string extension = Path.GetExtension(files[userInput - 1]);
string fileName = files[userInput - 1].Substring(0, files[userInput - 1].Length - extension.Length);

for (int i = 0; i < lines.Length; i++)
{
    id = SplitString(lines[i], "ID:", ",LastName");
    lastName = SplitString(lines[i], ",LastName:", ",FirstName:");
    firstName = SplitString(lines[i], ",FirstName:", "],Marks:");
    challenges = SplitString(lines[i], "Challenges:[", "],Exam:");
    exam = SplitString(lines[i], "],Exam:", ",Capstone:");
    capstone = SplitString(lines[i], ",Capstone:", "]");

    string[] challangesSeparated = challenges.Split(','); // Removing ',' between individaul marks

    marksAsIntigers = new int[challangesSeparated.Length]; // Parsing individaul marks to intiger
    for (int j = 0; j < challangesSeparated.Length; j++)
    {
        marksAsIntigers[j] = int.Parse(challangesSeparated[j]);
    }
    
    CalculateFianalMark(ChallengesMark(marksAsIntigers), exam, capstone);

    dataArray[i] = $"{finalMarkPercentage} - {firstName} {lastName} ({id})";

    if( finalMarkPercentage >= 70)
    {
        Console.WriteLine(dataArray[i]);
    }

    // results range counter
    if (finalMarkPercentage <= 100 && finalMarkPercentage >= 70)
    {
        gradesCount[0]++; //First
    }
    else if (finalMarkPercentage < 70 && finalMarkPercentage >= 60)
    {
        gradesCount[1]++; //2:1
    }
    else if (finalMarkPercentage < 60 && finalMarkPercentage >= 50)
    {
        gradesCount[2]++; //2:2
    }
    else if (finalMarkPercentage < 50 && finalMarkPercentage >= 40)
    {
        gradesCount[3]++; //Third
    }
    else
    {
        gradesCount[4]++; //Fail
    }
}
Array.Sort(dataArray);
Array.Reverse(dataArray);

using (StreamWriter myFile = new($"{fileName}Output.txt")) //saveing results to file
{
    for (int i = 0; i< dataArray.Length; i++)
    {
        myFile.WriteLine(dataArray[i]);
    }
}

for (int i = 0;i<gradesCount.Length;i++) // Displaying results on screen
{
    Console.WriteLine($"{gradesCount[i]}{grades[i]}"); 
}

//Methods used below
int ChallengesMark(int[] array) // Separating T1 and T2 marks, removing lowest mark and returning sum of marks achived
{
    int mark = 0;
    int[] arrayOne = new int[5];
    int[] arrayTwo = new int[3];

    for (int i = 0;i < array.Length;i++)
    {
        if (i<5)
        {
            arrayOne[i] = array[i];
        }
        else
        {
            arrayTwo[i-5]= array[i];
        }
    }

    Array.Sort(arrayOne);
    Array.Sort(arrayTwo);
    Array.Reverse(arrayOne);
    Array.Reverse(arrayTwo);

    for (int i = 0; i<arrayOne.Length-1;i++)
    {
        mark += arrayOne[i];
    }

    for(int i = 0; i<arrayTwo.Length-1;i++)
    {
        mark += arrayTwo[i];
    }
    return mark;
}
float CalculateFianalMark(int mark, string exam, string capstone) // Calculating overall score
{
    const float DIGITAL_PORTFOLIO = 30;
    const float EXAM = 20;
    const float CAPSTONE = 100;
    const float DIGITAL_PORTFOLIO_WEIGHTING = 50;
    const float EXAM_WEIGHTING = 25;
    const float CAPSTONE_WEIGHTING = 25;
    //  Calculating Percentages and rounding 
    digitalPortfolioPercentage = (100 * mark / DIGITAL_PORTFOLIO);
    digitalPortfolioPercentage = (float)Math.Round(digitalPortfolioPercentage, 0, MidpointRounding.AwayFromZero);
    openBookExamPercentage = 100 * int.Parse(exam) / EXAM;
    openBookExamPercentage = (float)Math.Round(openBookExamPercentage, 0, MidpointRounding.AwayFromZero);
    capstoneProjectPercentage = 100 * int.Parse(capstone) / CAPSTONE;
    openBookExamPercentage = (float)Math.Round(openBookExamPercentage, 0, MidpointRounding.AwayFromZero);
    // calculating overall classification and rounding 
    finalMarkPercentage = (digitalPortfolioPercentage * DIGITAL_PORTFOLIO_WEIGHTING / 100) + (openBookExamPercentage * EXAM_WEIGHTING / 100) + (capstoneProjectPercentage * CAPSTONE_WEIGHTING / 100);
    finalMarkPercentage = (float)Math.Round(finalMarkPercentage, 0, MidpointRounding.AwayFromZero);
    // If a student does not achieve a passing mark of 40% or higher in a compulsory element of assessment the entire module mark is capped at 34%.
    if (finalMarkPercentage > 34 && openBookExamPercentage < 40 || finalMarkPercentage > 34 && capstoneProjectPercentage < 40)
    {
        return finalMarkPercentage = 34;
    }
    return finalMarkPercentage;
}
string SplitString(string temp, string splitOne, string splitTwo) // Separating seklected part of string
{
    int a = temp.IndexOf(splitOne) + splitOne.Length;
    int b;
    if (splitOne == ",Capstone:")
    {
        b = temp.LastIndexOf(splitTwo);
    }
    else
    {
        b = temp.IndexOf(splitTwo);

    }
    string stringPart = temp.Substring(a, b - a);
    return stringPart;
}
