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
