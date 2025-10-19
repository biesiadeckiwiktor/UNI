Console.WriteLine("Connect 4");

string[] playerNames = new string[2];
Console.WriteLine("Red player please enter your name.");
playerNames[0] = Console.ReadLine();

Console.WriteLine("Yellow player please enter your name.");
playerNames[1] = Console.ReadLine();

int currentPlayerIndex = 0;

int boardWidth = 7;
int boardHeight = 6;

char[,] board = new char[boardHeight, boardWidth];

do
{

    // get column from current player in the correct range
    int columnSelection;
    Console.WriteLine(playerNames[currentPlayerIndex] + " please select a column number.");

    do
    {
        Console.WriteLine("Please enter a number between 1 and 7 inclusive.");
        columnSelection = int.Parse(Console.ReadLine()) - 1;

        if ((columnSelection < boardWidth && columnSelection >= 0) && board[0, columnSelection] != '\0')
        {
            Console.WriteLine("There is no space in that column");
            columnSelection = -1;
        }
    } while (columnSelection < 0 || columnSelection >= boardWidth);

    // update the board state
    int rowSelection = boardHeight - 1;
    for (; rowSelection >= 0; rowSelection--)
    {
        if (board[rowSelection, columnSelection] == '\0')
        {
            if (currentPlayerIndex == 0)
            {
                board[rowSelection, columnSelection] = 'R';
            }
            else
            {
                board[rowSelection, columnSelection] = 'Y';
            }
            break;
        }
    }

    Console.Clear();

    // Diplay the current board state
    // first display the column numbers
    for (int columnNumber = 1; columnNumber <= board.GetLength(1); columnNumber++)
    {
        Console.Write(columnNumber);
    }
    Console.WriteLine();

    // then display the board itself
    // the board is drawn using a nested loop
    for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < board.GetLength(1); columnIndex++)
        {
            if (board[rowIndex, columnIndex] == 'R')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O");
            }
            else if (board[rowIndex, columnIndex] == 'Y')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");
            }
            else
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
    }

    // check for vertical win condition

    int sameColourInRow = 1;
    if (rowSelection <= boardHeight - 3)
    {
        for (int i = rowSelection + 1; i < boardHeight; i++)
        {
            if (board[i, columnSelection] == board[rowSelection, columnSelection])
            {
                sameColourInRow++;
            }
            else
            {
                break;
            }
        }
    }


    //START

    //CHECK FOR HORIZONTAL WIN CONDITION

    int sameColour = 1; // chip just placed

    // Check to the left
    for (int i = columnSelection - 1; i >= 0; i--)
    {
        if (board[rowSelection, i] == board[rowSelection, columnSelection])
        {
            sameColour++;
        }
        else
        {
            break;
        }

    }
    // Check to the right
    for (int i = columnSelection + 1; i < boardWidth; i++)
    {
        if (board[rowSelection, i] == board[rowSelection, columnSelection])
        {
            sameColour++;
        }
        else
        {
            break;
        }

    }

    //CHECK FOR DIAGONAL WIN CONDITION

    int sameDiagonally1 = 1; // chip just placed

    // Check up and left
    for (int i = rowSelection - 1, j = columnSelection - 1; i >= 0 && j >= 0; i--, j--)

    {
        if (board[i, j] == board[rowSelection, columnSelection])
        {
            sameDiagonally1++;
        }
        else
        {
            break;
        }
    }

    // Check down and right
    for (int i = rowSelection + 1, j = columnSelection + 1; i < boardHeight && j < boardWidth; i++, j++)
    {
        if (board[i, j] == board[rowSelection, columnSelection])
        {
            sameDiagonally1++;
        }
        else
        {
            break;
        }
    }

    int sameDiagonally2 = 1; // chip just placed, different variable to avoid win if chips L shaped

    // Check up and right
    for (int i = rowSelection - 1, j = columnSelection + 1; i >= 0 && j < boardWidth; i--, j++)
    {
        if (board[i, j] == board[rowSelection, columnSelection])
        {
            sameDiagonally2++;
        }
        else
        {
            break;
        }
    }

    // Check down and left
    for (int i = rowSelection + 1, j = columnSelection - 1; i < boardHeight && j >= 0; i++, j--)
    {
        if (board[i, j] == board[rowSelection, columnSelection])
        {
            sameDiagonally2++;
        }
        else
        {
            break;
        }
    }

    // Check win condition
    if (sameDiagonally1 >= 4 || sameDiagonally2 >= 4 || sameColour >= 4 || sameColourInRow >= 4)
    {
        break;
    }


    //END

    // swap the current player index
    if (currentPlayerIndex == 0)
    {
        currentPlayerIndex = 1;
    }
    else
    {
        currentPlayerIndex = 0;
    }
} while (true);

Console.WriteLine("Congratulations " + playerNames[currentPlayerIndex] + ", You Won!");