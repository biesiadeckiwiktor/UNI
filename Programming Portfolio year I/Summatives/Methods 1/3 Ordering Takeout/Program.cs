Console.WriteLine("Welcome to Mario's Pizzeria!");
Console.WriteLine("Your one stop shop for Pizza, Pasta and Burgers!");

int categorySelection = GetCategory();
string order = string.Empty;

if (categorySelection == 1)
{
    order = GetPizzaSelection();
}
else if (categorySelection == 2)
{
   order = GetPastaSelection();
}
else if (categorySelection == 3)
{
    order = GetBurgerSelection();
}

Console.WriteLine($"Enjoy your {order}");



int GetCategory()
{
    do
    {
        Console.WriteLine("What would you like to order?");
        Console.WriteLine("1. Pizza");
        Console.WriteLine("2. Pasta");
        Console.WriteLine("3. Burgers");
        categorySelection = int.Parse(Console.ReadLine());
    } while (categorySelection < 1 || categorySelection > 3);
    return categorySelection;
}

string GetPizzaSelection()
{
    int pizzaSelection = 0;
    do
    {
        Console.WriteLine("What sort of pizza would you like?");
        Console.WriteLine("1. Margherita Pizza");
        Console.WriteLine("2. Pepperoni Pizza");
        Console.WriteLine("3. Hawaiian Pizza");
        pizzaSelection = int.Parse(Console.ReadLine());
    } while (pizzaSelection < 1 || pizzaSelection > 3);

    if (pizzaSelection == 1)
    {
      order = "Margherita Pizza";
    }
    else if (pizzaSelection == 2)
    {
        order = "Pepperoni Pizza";
    }
    else if (pizzaSelection == 3)
    {
        order = "Hawaiian Pizza";
    }
    return order;
}

string GetPastaSelection()
{
    int pastaSelection = 0;
    do
    {
        Console.WriteLine("What sort of pasta would you like?");
        Console.WriteLine("1. Spaghetti Bolognaise");
        Console.WriteLine("2. Carbonara");
        Console.WriteLine("3. Macaroni Cheese");
        pastaSelection = int.Parse(Console.ReadLine());
    } while (pastaSelection < 1 || pastaSelection > 3);

    if (pastaSelection == 1)
    {
        order = "Spaghetti Bolognaise";
    }
    else if (pastaSelection == 2)
    {
        order = "Carbonara";
    }
    else if (pastaSelection == 3)
    {
        order = "Macaroni Cheese";
    }
    return order;
}

string GetBurgerSelection()
{
    int burgerSelection = 0;
    do
    {
        Console.WriteLine("What sort of burger would you like?");
        Console.WriteLine("1. Plain Burger");
        Console.WriteLine("2. Cheese Burger");
        Console.WriteLine("3. Double Cheese Burger");
        burgerSelection = int.Parse(Console.ReadLine());
    } while (burgerSelection < 1 || burgerSelection > 3);

    if (burgerSelection == 1)
    {
        order = "Plain Burger";
    }
    else if (burgerSelection == 2)
    {
        order = "Cheese Burger";
    }
    else if (burgerSelection == 3)
    {
        order = "Double Cheese Burger";
    }
    return order;
}