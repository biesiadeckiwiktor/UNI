void SayHello()
{
    Console.WriteLine("Hello, World!");
}

void SayHelloWithName(string pName)
{
    Console.WriteLine($"Hello, {pName}");
}

string GetName()
{
    Console.WriteLine("What is your name?");
    string name = Console.ReadLine();
    return name;
}
SayHello();

string name = GetName();

SayHelloWithName(name);