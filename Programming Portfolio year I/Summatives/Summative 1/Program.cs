Console.WriteLine("Car hire calculator");
Console.WriteLine("How many days was the car hired for?");

int days = int.Parse(Console.ReadLine());

 Console.WriteLine("How much fuel was left in the tank?");

int fuel = int.Parse(Console.ReadLine());

int dailyCost = 25;
double fuelPrice = 2.5;

double result = ((days * dailyCost) + ((50 - fuel) * fuelPrice) + 10);

Console.WriteLine("The total charge for the car hire is £" + result);