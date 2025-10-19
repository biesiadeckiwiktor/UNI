using Summative_8.Menu;
using Summative_8.Shapes;

Console.WriteLine("Hello, OO Console Menu!");

ShapeManager shapeManager = new ShapeManager();
ShapeManagerMenu menu = new ShapeManagerMenu(shapeManager);
menu.Select();