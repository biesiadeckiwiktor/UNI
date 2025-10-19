# Summative 4
## Challenge Description

Goals
Use methods to breakdown a large problem into smaller parts, reduce scope and improve readability
Read input from a file
Setting Up Your Project
For this summative challenge you should use your digital portfolio repository. You should complete this work in your Digital Portfolio Repository in GitHub.

If you have not already accepted this assignment in GitHub classroom you can do so by clicking this link:  https://classroom.github.com/a/exniitfL

Problem Specification
You have been provided with data files containing the marks of students on the Programming Portfolio module.

Your task is to do the following.

Ask the user to select a file from a list of available files with the .mark extension from the current directory
Load the data from the file
Calculate the overall module marks for each student according to the rules described in 📒Summative Challenge 2
Note that in this case there are a total of 8 digital portfolio marks - one for each challenge.
To account for unexpected absence we award the best 4 challenge marks of the first 5 challenges, and the best 2 challenge marks of the last 3 challenges to generate a mark out of 30 from 6 challenges
Count the number of students with 1st class, 2:1, 2:2 and 3rd class results and output this to the console
Sort the students by overall module mark
Output the sorted results to another file in the specified format
You should pay special attention to your use of methods to breakdown a large problem into smaller parts, reduce scope and improve readability.

## Code Listing

```cs
Console.WriteLine("Please select a file to load");
string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.mark");

int userInput = 0;
string id = null;
string lastName = null;
string firstName = null;
string challenges = null;
int[] array = null;
int mark;
string exam = null;
string capstone = null;
float finalMarkPercentage = 0;
int first = 0;
int twoOne = 0;
int twoTwo = 0;
int third = 0;
int fail = 0;
float digitalPortfolioPercentage = 0;
float openBookExamPercentage = 0;
float capstoneProjectPercentage = 0;


DisplayAvailableOptions();
UserInput();

//reading lines from a file
string[] lines = File.ReadAllLines(files[userInput - 1]);

string[] dataArray = new string[lines.Length];

// removing file extension from file name
string extension = Path.GetExtension(files[userInput - 1]);
string fileName = files[userInput - 1].Substring(0, files[userInput - 1].Length - extension.Length);

for (int i = 0; i < lines.Length; i++)
{
    mark = 0;
    string temp = lines[i];
    
    GetId(temp);
    GetLastName(temp);
    GetFirstName(temp);
    GetChallenges(temp);
    GetExam(temp);
    GetCapstone(temp);
    
    string[] challangesSeparated = challenges.Split(',');

    ParseArray(challangesSeparated);

    ChallengesMark(array);

    int examMark = int.Parse(exam);
    int capstoneMark = int.Parse(capstone);

    CalculateFianalMark(mark, examMark, capstoneMark);
    
    dataArray[i] = $"{finalMarkPercentage} - {firstName} {lastName} ({id})";

    // results range counter
        if (finalMarkPercentage <= 100 && finalMarkPercentage >= 70)
        {
            first++;
        }
        else if (finalMarkPercentage < 70 && finalMarkPercentage >= 60)
        {
            twoOne++;
        }
        else if (finalMarkPercentage < 60 && finalMarkPercentage >= 50)
        {
            twoTwo++;
        }
        else if (finalMarkPercentage < 50 && finalMarkPercentage >= 40)
        {
            third++;
        }
        else
        {
            fail++;
        }
}

Array.Sort(dataArray);
Array.Reverse(dataArray);
//saveing results to file
using (StreamWriter myFile = new($"{fileName}Output.txt"))
{
    for (int i = 0; i< dataArray.Length; i++)
    {
        myFile.WriteLine(dataArray[i]);
    }
}


Console.WriteLine(first + " First");
Console.WriteLine(twoOne + " 2:1");
Console.WriteLine(twoTwo + " 2:2");
Console.WriteLine(third + " Third");
Console.WriteLine(fail + " Fail");

//Methods used below

int[] ParseArray(string[] challangesSeparated) // Parsing string array of marks into intiger array
{
    array = new int[challangesSeparated.Length];
    for (int i = 0; i < challangesSeparated.Length; i++)
    {
        int temp = int.Parse(challangesSeparated[i]);
        array[i] = temp;
    }
    return array;
}
int ChallengesMark(int[] array) // Separating T1 and T2 marks, removing lowest mark and returning sum of marks achived
{
    int[] arrayOne = new int[5];
    int[] arrayTwo = new int[3];
    arrayOne[0] = array[0];
    arrayOne[1] = array[1];
    arrayOne[2] = array[2];
    arrayOne[3] = array[3];
    arrayOne[4] = array[4];

    arrayTwo[0] = array[5];
    arrayTwo[1] = array[6];
    arrayTwo[2] = array[7];

    Array.Sort(arrayOne);
    Array.Sort(arrayTwo);
    Array.Reverse(arrayOne);
    Array.Reverse(arrayTwo);

    for (int i = 0; i<arrayOne.Length-1;i++)
    {
        mark = mark + arrayOne[i];
    }

    for(int i = 0; i<arrayTwo.Length-1;i++)
    {
        mark = mark + arrayTwo[i];
    }
    return mark;
   
}
void DisplayAvailableOptions() //displaying available options
{
    for (int i = 0; i < files.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
    }
}
int UserInput() //asking for user input and validating
{
    do
    {
        Console.WriteLine($"Please enter number between 1 and {files.Length}");
        userInput = Int32.Parse(Console.ReadLine());
    } while (userInput < 1 || userInput > files.Length);
    return userInput;
}

float CalculateFianalMark(int mark, int examMark, int capstoneMark) // Calculating overall score
{
    const float DIGITAL_PORTFOLIO_FULL_MARK = 30;
    const float OPEN_BOOK_PROGRAMMING_EXAM_FULL_MARK = 20;
    const float CAPSTONE_PROJECT_FULL_MARK = 100;
    const float DIGITAL_PORTFOLIO_WEIGHTING = 50;
    const float OPEN_BOOK_PROGRAMMING_EXAM_WEIGHTING = 25;
    const float CAPSTONE_PROJECT_WEIGHTING = 25;
    //  Calculating Percentages and rounding 
    digitalPortfolioPercentage = (100 * mark / DIGITAL_PORTFOLIO_FULL_MARK);
    digitalPortfolioPercentage = (float)Math.Round(digitalPortfolioPercentage, 0, MidpointRounding.AwayFromZero);
    openBookExamPercentage = 100 * examMark / OPEN_BOOK_PROGRAMMING_EXAM_FULL_MARK;
    openBookExamPercentage = (float)Math.Round(openBookExamPercentage, 0, MidpointRounding.AwayFromZero);
    capstoneProjectPercentage = 100 * capstoneMark / CAPSTONE_PROJECT_FULL_MARK;
    openBookExamPercentage = (float)Math.Round(openBookExamPercentage, 0, MidpointRounding.AwayFromZero);
    // calculating overall classification and rounding 
    finalMarkPercentage = (digitalPortfolioPercentage * DIGITAL_PORTFOLIO_WEIGHTING / 100) + (openBookExamPercentage * OPEN_BOOK_PROGRAMMING_EXAM_WEIGHTING / 100) + (capstoneProjectPercentage * CAPSTONE_PROJECT_WEIGHTING / 100);
    finalMarkPercentage = (float)Math.Round(finalMarkPercentage, 0, MidpointRounding.AwayFromZero);
    if (CompulsoryPass() == true)
    {
        finalMarkPercentage = 34;
    }
    Console.WriteLine(finalMarkPercentage);

    return finalMarkPercentage;
}
string GetId(string temp) // Separating studend ID from data string
{
    int a = temp.IndexOf("ID:") + "ID:".Length;
    int b = temp.IndexOf(",LastName");
    id = temp.Substring(a, b - a);
    return id;
}
string GetLastName(string temp) // Separating slast name from data string
{
    int c = temp.IndexOf(",LastName:") + ",LastName:".Length;
    int d = temp.IndexOf(",FirstName:");
    lastName = temp.Substring(c, d - c);
    return lastName;
}
string GetFirstName(string temp) // Separating first name from data string
{
    int e = temp.IndexOf(",FirstName:") + ",FirstName:".Length;
    int f = temp.IndexOf("],Marks:");
    firstName = temp.Substring(e, f - e);
    return firstName;
}
string GetChallenges(string temp) // Separating challanges marks from data string
{
    int g = temp.IndexOf("Challenges:[") + "Challenges:[".Length;
    int h = temp.IndexOf("],Exam:");
    challenges = temp.Substring(g, h - g);
    return challenges;
}
string GetExam(string temp) // Separating exam mark from data string
{
    int k = temp.IndexOf("],Exam:") + "],Exam:".Length;
    int l = temp.IndexOf(",Capstone:");
    exam = temp.Substring(k, l - k);
    return exam;
}
string GetCapstone(string temp) // Separating capstone mark from data string
{
    int m = temp.IndexOf(",Capstone:") + ",Capstone:".Length;
    int n = temp.LastIndexOf(']');
    capstone = temp.Substring(m, n - m);
    return capstone;
}
bool CompulsoryPass() // Compulsory pass validation
{
    // If a student does not achieve a passing mark of 40% or higher in a compulsory element of assessment the entire module mark is capped at 34%.
    if (finalMarkPercentage > 34 && openBookExamPercentage < 40 || finalMarkPercentage > 34 && capstoneProjectPercentage < 40)
    {
        return true;
    }
    return false;
}


```

## Test Plan

Include your test plan and results here

| Test Number | Input File| Expected Output | Actual Output |
|---|---|---|---|
| 1 | 1_1StudentFail32.mark | 0 First, 0 2:1, 0 2:2, 0 Third, 1 Fail | Same |
| 2 | 2_1StudentFail36.mark | 0 First, 0 2:1, 0 2:2, 0 Third, 1 Fail | Same |
| 3 | 3_StudentFail39.mark | 0 First, 0 2:1, 0 2:2, 0 Third, 1 Fail | Same |
| 4 | 4_StudentFailCappedCapstone34.mark | 0 First, 0 2:1, 0 2:2, 0 Third, 1 Fail | Same |
| 5 | 5_1StudentFailCappedExam34.mark | 0 First, 0 2:1, 0 2:2, 0 Third, 1 Fail | Same |
| 6 | 6_1StudentFailZeroMarks.mark | 0 First, 0 2:1, 0 2:2, 0 Third, 1 Fail | Same |
| 7 | 7_1StudentThird40.mark | 0 First, 0 2:1, 0 2:2, 1 Third, 0 Fail | Same |
| 8 | 8_1StudentThird41.mark | 0 First, 0 2:1, 0 2:2, 1 Third, 0 Fail | Same |
| 9 | 9_1StudentTwoOne60.mark | 0 First, 1 2:1, 0 2:2, 0 Third, 0 Fail | Same |
| 10 | a_1StudentTwoOne69.mark | 0 First, 1 2:1, 0 2:2, 0 Third, 0 Fail | Same |
| 11 | b_1StudentTwoTwo59.mark | 0 First, 0 2:1, 1 2:2, 0 Third, 0 Fail | Same |
| 12 | c_1StudentFirst.mark | 1 First, 0 2:1, 0 2:2, 0 Third, 0 Fail | Same |
| 13 | d_5StudentsOneEachClassification.mark | 1 First, 1 2:1, 1 2:2, 1 Third, 1 Fail | Same |
| 14 | e_256Students.mark | 109 First, 19 2:1, 10 2:2, 3 Third, 115 Fail | Same |
| 15 | f_326Students.mark | 132 First, 36 2:1, 15 2:2, 3 Third, 140 Fail | Same |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
