float Add(float pRHS, float pLHS)
{
    return pRHS + pLHS;
}

float Subtract(float pRHS, float pLHS)
{
    return pRHS - pLHS;
}

float DoCalculation(mathFunction function)
{
    Console.WriteLine("Please enter right hand side value");
float rhs = float.Parse(Console.ReadLine());
Console.WriteLine("Please enter left hand side value");
float lhs = float.Parse(Console.ReadLine());

return function(rhs, lhs);
}

mathFunction myDelegate = Add;

float result = DoCalculation(myDelegate);

Console.WriteLine(result);

myDelegate = Subtract;

result = DoCalculation(myDelegate);

Console.WriteLine(result);

delegate float mathFunction(float pRHS, float pLHS);
