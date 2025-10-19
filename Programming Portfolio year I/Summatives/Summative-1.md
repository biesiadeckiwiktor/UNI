# Summative 1

## Challenge Description

This time you're going to calculate the cost to hire a car. When a customer hires the car is has a full tank of petrol. The tank holds 50 litres of fuel.

The car hire cost is £25 per day hired, plus £2.50 per litre of petrol used and a £10 booking fee.

Your program should ask the user how many days the car was hired for, then how many litres of fuel were left in the tank when it was returned.

## Code Listing

```cs

using System;

namespace program
{
    class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Car hire calculator");
            Console.WriteLine("How many days was the car hired for?");

            int days = int.Parse(Console.ReadLine());

            Console.WriteLine("How much fuel was left in the tank?");

            int fuel = int.Parse(Console.ReadLine());

            int dailyCost = 25;
            double fuelPrice = 2.5;

            double result = ((days * dailyCost) + ((50 - fuel) * fuelPrice) + 10);

            Console.WriteLine("The total charge for the car hire is £" + result);

            Console.ReadLine();
        }
    }
}

```

## Test Plan

Include your test plan and results here

| Test Number | Input | Expected Output | Actual Output | Pass/Fail |
|---|---|---|---|---|
| 1 | "0", "50" | "The total charge for the car hire is £10"| "The total charge for the car hire is £10"| Pass |
| 2 | "1", "50" | "The total charge for the car hire is £35"| "The total charge for the car hire is £35"| Pass |
| 3 | "0", "49"| "The total charge for the car hire is £12.5"|"The total charge for the car hire is £12.5"| Pass |
| 4 | "1", "30" | "The total charge for the car hire is £85"	|"The total charge for the car hire is £85"	| Pass |
| 5 | 3", "50" | "The total charge for the car hire is £85"	|"The total charge for the car hire is £85"	| Pass |
| 6 | "2", "15"| "The total charge for the car hire is £147.5"|"The total charge for the car hire is £147.5"| Pass |
| 7 | "5", "20"| "The total charge for the car hire is £210"| "The total charge for the car hire is £210"| Pass |
| 8 | "cheeseburger"| Program crashes - unhandled exception|Program crashes - unhandled exception| Pass |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
