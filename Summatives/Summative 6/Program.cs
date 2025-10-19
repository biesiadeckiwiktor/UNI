using Summative_6;
using System.IO.Pipes;
using System.Collections.Generic;

List<Circle> circles = new List<Circle>{};

do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Create circle");
    Console.WriteLine("2. Change radius");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Please enter radius: ");
            if (double.TryParse(Console.ReadLine(), out double userRadius))
            {
                Circle circle = new Circle(userRadius);
                circles.Add(circle);
                DisplayCircle(circle);
            }
            else
            {
                Circle circle = new Circle();
                circles.Add(circle);
                DisplayCircle(circle);
            }
            break;

        case "2":
            Console.WriteLine("Choose for which circle you want to change the radius:");
            for (int i = 0; i < circles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Circle {circles[i].Id} with radius {circles[i].Radius}");
            }
            if (int.TryParse(Console.ReadLine(), out int circleIndex) && circleIndex > 0 && circleIndex <= circles.Count)
            {
                Console.Write("Enter the new radius: ");
                if (double.TryParse(Console.ReadLine(), out double newRadius))
                {
                        circles[circleIndex - 1].Radius = newRadius;
                        DisplayCircle(circles[circleIndex - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid radius.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine();
            }
            break;

        case "3":
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            Console.WriteLine();
            break;
    }
} while (true);

void DisplayCircle(Circle circle)
{
    Console.WriteLine($"Circle {circle.Id} with radius {circle.Radius}:");
    Console.WriteLine($"Area: {circle.CalculateArea():F2}");
    Console.WriteLine($"Circumference: {circle.CalculateCircumference():F2}");
    Console.WriteLine();
}