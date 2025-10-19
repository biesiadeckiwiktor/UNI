# Summative 8

## Challenge Description

Add code to create a new rectangle shape, and new functionality to the ShapeManager to get the total area of all shapes, and the total area of shapes of a particular colour. Hook this code up to the menu.

You might want to take the following steps:

Adding a Rectangle Shape

In Shapes.cs create a Rectangle class that inherits from Shape. Rectangle should have a Height and a Width that should only be allowed to be between 0 and 50.
Write the necessary code to implement the abstract Shape class.
Adding the Rectangle to the Menu System

In the same way that we did for the square add an AddRectangleMenuItem that inherits from MenuItem - implement the abstract MenuItem class by adding a Select method that gets the colour, width and height of the rectangle and adds it to the ShapeManager
Add the new AddRectangleMenu item to the list of MenuItems in the AddNewShape Menu
Check that everything works as expected. You should be able to add Rectangles.

Adding the Edit Rectangle Functionality

Create another EditRectangleMenu that inherits from EditShapeMenu
Create EditRectangleWidthMenuItem and EditRectangleHeightMenuItem  classes that take a reference to the Rectangle that is being edited
Add the code to add EditRectangleMenu instances to the EditExistingShapeMenu
Check that everything works as expected. You should be able to add, remove and edit Rectangles

Bonus Challenges
As bonus challenges add the following options to the ShapeManagerMenu

The ability to output the total area of all shapes
The ability to output the total perimeter of all shapes
The ability to select a colour and output the area of all the shapes of that colour


