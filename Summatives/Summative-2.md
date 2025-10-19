# Summative 2

## Challenge Description

There are three elements of assessment in the programming portfolio module. They are the Digital Portfolio, the Open Book Programming Exam and the Capstone Project.

Each assessment is awarded a different number of marks, and each assessment has a different weighting. These are shown in the table below.

| Element of Assessment |	Weighting |	Marked out of |	Compulsory Element of Assessment |
|---|---|---|---|
| Digital Portfolio	| 50% |	30	| No |
| Open Book Programming Exam |	25% |	20 | Yes - You must pass this to pass the module |
| Capstone Project	| 25%	| 100 |	Yes - You must pass this to pass the module |

Additionally, both the Open Book Programming Exam and the Capstone Project are compulsory elements of assessment. If student's do not pass a compulsory element or assessment the entire module mark is capped at 34%.

If you do not pass a module the you will be offered reassessments in the elements of assessment that you failed. If you do not pass the reassessments and as a result fail a core module you cannot progress to the next stage of your degree. Instead you must either apply to repeat the entire year, or withdraw from your studies and be awarded credits for the modules you have passed.

Students who successfully complete an Honours degree are awarded a degree with a certain classification which is calculated from the weighted mark for your overall degree, These degree classifications are also often used to describe a students performance in an individual module. The highest classification is First-Class Honours (First or 1st) which is awarded for marks of 70% and above. The Upper Second-Class Honours (2:1, 2.i) is awarded for marks of 60-70%. The Lower Second-Class Honours (2:2, 2.ii) is awarded for marks of 50-60%. The lowest Honours degree is the third class degree (Third or 3rd) which is awarded for marks of 40-50% All mark ranges are inclusive of their lower bounds, and exclusive of their upper bounds.

Your challenge is to write a program that requests a student's raw marks for the three elements of assessment of the Programming Portfolio module, and calculates the outcome of the module. Raw marks can only be entered as whole numbers. To do this you should first convert the mark from a raw mark into a percentage. A percentage mark can be calculated by dividing the marks awarded by the total available marks, and multiplying by 100. For example the Digital Portfolio is marked out of 30, if a student scored 25 marks their percentage mark would be 100 * 25 / 30 = 83.33% (to 2 decimal places).

Once you have all three marks expressed as percentages you can calculate the overall classification by multiplying each mark by it's weighting divided by 100, and then adding the three outcomes together. So for example if a student was awarded 80% for the digital portfolio, 60% for the open book programming exam and 65% for the capstone project their overall module mark would be (80 * 50 / 100) + (60 * 25 / 100) + (65 * 25 / 100) = 40 + 15 + 16.25 = 71%

Once you have the overall module mark you can use that to determine the module outcome. The various module outcomes are described in the test data below. Remember, if a student does not achieve a passing mark of 40% or higher in a compulsory element of assessment the entire module mark is capped at 34%. 

## Code Listing

```cs
Console.WriteLine("Programming Portfolio Results Calculator");

// Declaring variables up front, not in functions due to scope
do
{
    int digitalPortfolioMark = 0;
    int openBookExamMark = 0;
    int capstoneProjectMark = 0;

    // Ask user to enter marks received for individual parts of the assesment and validate input

    Console.WriteLine("What was the digital portfolio mark? (out of 30)");

    do
    {
        digitalPortfolioMark = int.Parse(Console.ReadLine());

        if (digitalPortfolioMark < 0 || digitalPortfolioMark > 30)
        {
            Console.WriteLine(digitalPortfolioMark + " is not a valid mark for the digital portfolio");
            continue;
        }
        else
        {
            break;
        }

    } while (true);

    Console.WriteLine("What was the open book programming exam mark? (out of 20)");

    do
    {
        openBookExamMark = int.Parse(Console.ReadLine());

        if (openBookExamMark < 0 || openBookExamMark > 20)
        {
            Console.WriteLine(openBookExamMark + " is not a valid mark for the open book programming exam");
            continue;
        }
        else
        {
            break;
        }

    } while (true);

    Console.WriteLine("What was the capstone project mark? (out of 100)");

    do
    {
        capstoneProjectMark = int.Parse(Console.ReadLine());

        if (capstoneProjectMark < 0 || capstoneProjectMark > 100)
        {
            Console.WriteLine(capstoneProjectMark + " is not a valid mark for the capstone project");
            continue;
        }
        else
        {
            break;
        }

    } while (true);

    // Declaring variables up front, not in functions due to scope

    int finalMark = 0;
    float finalMarkPercentage = 0;
    float digitalPortfolioPercentage = 0;
    float openBookExamPercentage = 0;
    float capstoneProjectPercentage = 0;

    // Full marks and weightings are constants as they will not change

    const float DIGITAL_PORTFOLIO_FULL_MARK = 30;
    const float OPEN_BOOK_PROGRAMMING_EXAM_FULL_MARK = 20;
    const float CAPSTONE_PROJECT_FULL_MARK = 100;
    const float DIGITAL_PORTFOLIO_WEIGHTING = 50;
    const float OPEN_BOOK_PROGRAMMING_EXAM_WEIGHTING = 25;
    const float CAPSTONE_PROJECT_WEIGHTING = 25;


    //  Calculating Percentages

    finalMark = digitalPortfolioMark + openBookExamMark + capstoneProjectMark;

    digitalPortfolioPercentage = (100 * digitalPortfolioMark / DIGITAL_PORTFOLIO_FULL_MARK);
    openBookExamPercentage = 100 * openBookExamMark / OPEN_BOOK_PROGRAMMING_EXAM_FULL_MARK;
    capstoneProjectPercentage = 100 * capstoneProjectMark / CAPSTONE_PROJECT_FULL_MARK;

    // calculating overall classification and rounding 

    finalMarkPercentage = (digitalPortfolioPercentage * DIGITAL_PORTFOLIO_WEIGHTING / 100) + (openBookExamPercentage * OPEN_BOOK_PROGRAMMING_EXAM_WEIGHTING / 100) + (capstoneProjectPercentage * CAPSTONE_PROJECT_WEIGHTING / 100);


    // If a student does not achieve a passing mark of 40% or higher in a compulsory element of assessment the entire module mark is capped at 34%. 

    if (finalMarkPercentage > 34 && openBookExamPercentage < 40 || finalMarkPercentage > 34 && capstoneProjectPercentage < 40)
    {
            finalMarkPercentage = 34;
    }

    finalMarkPercentage = (float)Math.Round(finalMarkPercentage, 2, MidpointRounding.AwayFromZero);


    // displaying results
    if (finalMarkPercentage <= 100 && finalMarkPercentage >= 70)
    {
        Console.WriteLine(finalMarkPercentage + "% - 1st");
    }
    else if (finalMarkPercentage < 70 && finalMarkPercentage >= 60)
    {
        Console.WriteLine(finalMarkPercentage + "% - 2.1");
    }
    else if (finalMarkPercentage < 60 && finalMarkPercentage >= 50)
    {
        Console.WriteLine(finalMarkPercentage + "% - 2.2");
    }
    else if (finalMarkPercentage < 50 && finalMarkPercentage >= 40)
    {
        Console.WriteLine(finalMarkPercentage + "% - 3rd");
    }
    else
    {
        Console.WriteLine(finalMarkPercentage + "% - fail");
    }

} while (true);

```

## Test Plan

Include your test plan and results here

| Test Number	| Digital Portfolio Mark | Open Book Programming Exam Mark | Capstone Project Mark | Expected Output | PASS / FAIL |
|---|---|---|---|---|---|
| 1     |	-1	|		|       | -1 is not a valid mark for the digital portfolio | Pass |
| 2	    | 31	| 		|       | 31 is not a valid mark for the digital portfolio | Pass |
| 3	    | 25.5	| 		|       | program crashes | Pass |
| 4	    | 30 | 	-1		|       | -1 is not a valid mark for the open book programming exam | Pass |
| 5	    | 30	| 21	|       | 8 is not a valid mark for the open book programming exam | Pass |
| 6	    | 30	| 5.5	|       | program crashes | Pass |
| 7	    | 30	| 20	| -1	| -1 is not a valid mark for the capstone project | Pass |
| 8	    | 30	| 20	| 101	| 101 is not a valid mark for the capstone project | Pass |
| 9	    | 30	| 20	| 65.5	| program crashes | Pass |
| 10    | 30	| 20	| 100	| 100% - 1st | Pass |
| 11	| 21	| 14	| 70	| 70% - 1st | Pass |
| 12	| 21	| 14	| 69	| 69.75% - 2:1 | Pass |
| 13	| 18	| 12	| 60	| 60% - 2:1 | Pass |
| 14	| 18	| 12	| 59	| 59.75% - 2:2 | Pass |
| 15	| 15	| 10	| 50	| 50% - 2:2 | Pass |
| 16	| 15	| 10	| 49	| 49.75% - 3rd | Pass |
| 17	| 12	| 8	    | 40	| 40% - 3rd | Pass |
| 18	| 12	| 8	    | 39	|  34% - fail | Pass |
| 19	| 10	| 7	    |40	    | 34% - fail | Pass |
| 20	| 11	| 20	| 100	| 	68.33% - 2:1 | Pass |
| 21	| 30	| 7	    | 100	| 34% - fail | Pass |
| 22	| 12	| 8	    | 15	| 33.75% - fail | Pass |
| 23	| 0	    | 0	    | 0	    | 0% - fail | Pass |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
