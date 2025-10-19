# Summative 3

## Challenge Description

"At the New Orleans Oyster Festival, eight eaters will slurp down as many mollusks as they can in the allotted eight minutes. The winner takes home $1,000 from Major League Eating (MLE), which also oversees the ESPN-televised Nathan’s Famous hot dog eating contest on Coney Island every summer." (The world of competitive oyster eating: 'your stomach is like a human Tetris' | Food | The GuardianLinks to an external site.)

You are tasked with writing a program that allows you to enter the number of competitors in the competition, the name of each competitor, and the number of oysters each competitor ate. Once all the competitors are entered you should sort them with respect to the number of oysters eaten (write your own sorting algorithm - do not use the built in sort), output them to the Console and save the results to a file called results.txt.

## Code Listing

```cs
Console.WriteLine("Oyster eating competition");
int competitors = 0;
do
{
    Console.WriteLine("How many competitors are there?");
    competitors = int.Parse(Console.ReadLine());

    string[] competitorsNames = new string[competitors];
    int[] oystersEaten = new int[competitors];

    for (int i = 0, j = 1; i < competitors; i++, j++)
    {
        Console.WriteLine("What's competitors number " + j + " name?");
        competitorsNames[i] = Console.ReadLine();

        Console.WriteLine($"How many oysters did {competitorsNames[i]} ate?");
        oystersEaten[i] = int.Parse(Console.ReadLine());
    }

    int n = oystersEaten.Length;

    int temporaryNumber;

    string temporaryName;

    for (int i = 0; i < n - 1; i++) // sorting loop
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (oystersEaten[j] < oystersEaten[j + 1])
            {
                temporaryNumber = oystersEaten[j];
                oystersEaten[j] = oystersEaten[j + 1];
                oystersEaten[j + 1] = temporaryNumber;

                temporaryName = competitorsNames[j]; // sorting names at the same time
                competitorsNames[j] = competitorsNames[j + 1];
                competitorsNames[j + 1] = temporaryName;
            }
        }
    }
     //saveing results to file
    using(StreamWriter myFile = new StreamWriter("results.txt"))
    for (int i = 0, j = 1; i < n; i++, j++)
    {
        myFile.WriteLine($"{j}. {competitorsNames[i]} ate {oystersEaten[i]} oysters");
    }
} while (true);
```

## Test Plan

Include your test plan and results here

| Test Number | Input | Expected Output | Actual Output | Pass / Fail |
|---|---|---|---|---|
| 1 | 	5             | 1. Sonya Thomas ate 492 oysters    | 1. Sonya Thomas ate 492 oysters | Pass |
|   |   Simon Grey    | 2. Adrian Morgan ate 432 oysters   | 2. Adrian Morgan ate 432 oysters  | |
|   |  232            | 3. David Parker ate 286 oysters    | 3. David Parker ate 286 oysters | |
|   |  David Parker   | 4. Simon Grey ate 232 oysters      | 4. Simon Grey ate 232 oysters | |
|   |    286          | 5. John Dixon ate 212 oysters      | 5. John Dixon ate 212 oysters  | |
|   |   John Dixon    |                                    |  | |
|   | 212             |                                    |  | |
|   | Adrian Morgan   |                                    |  | |
|   | 432             |                                    |  | |
|   | Sonya Thomas    |                                    |  | |
|   | 492             |                                    |  | |
| 2 | 	3             | 1. Darron Breeden ate 480 oysters  | 1. Darron Breeden ate 480 oysters | Pass |
|   |  Michelle Lesco | 2. Michelle Lesco ate 324 oysters  | 2. Michelle Lesco ate 324 oysters | |
|   |  324            | 3. Adrian Morgan ate 312 oysters   | 3. Adrian Morgan ate 312 oysters  | |
|   |  Darron Breeden |                                    |  | |
|   |  480            |                                    |  | |
|   |  Adrian Morgan  |                                    |  | |
|   |  312            |                                    |  | |
| 3 |       8         | 1. Jackson White ate 61 oysters    | 1. Jackson White ate 61 oysters | Pass |
|   |    Lily Anderson| 2. Ava Brown ate 55 oysters        | 2. Ava Brown ate 55 oysters | |
|   |  47             | 3. Ethan Miller ate 53 oysters     | 3. Ethan Miller ate 53 oysters | |
|   | Ethan Miller    | 4. Noah Johnson ate 50 oysters     | 4. Noah Johnson ate 50 oysters | |
|   | 53              | 5. Mason Harris ate 48 oysters     | 5. Mason Harris ate 48 oysters  | |
|   | Olivia Smith    | 6. Lily Anderson ate 47 oysters    | 6. Lily Anderson ate 47 oysters | |
|   |39               | 7. Sophia Lee ate 45 oysters       | 7. Sophia Lee ate 45 oysters | |
|   |Jackson White    | 8. Olivia Smith ate 39 oysters     | 8. Olivia Smith ate 39 oysters | |
|   |61               |                                    |  | |
|   |      Sophia Lee |                                    |  | |
|   |    45           |                                    |  | |
|   |  Noah Johnson   |                                    |  | |
|   |50               |                                    |  | |
|   |Ava Brown        |                                    |  | |
|   |55               |                                    |  | |
|   |Mason Harris     |                                    |  | |
|   |48               |                                    |  | |




## Feedback Request

If there is anything specific you want to ask for feedback on include that here
