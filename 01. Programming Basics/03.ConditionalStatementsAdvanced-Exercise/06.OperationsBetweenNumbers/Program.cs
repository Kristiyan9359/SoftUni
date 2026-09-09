
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
string operation = Console.ReadLine();

double result = 0;
bool isEven = false;

if (operation == "+")
{
    result = a + b;
    isEven = result % 2 == 0;
    {
        if (isEven)
        {
            Console.WriteLine($"{a} + {b} = {result} - even");
        }
        else
        {
            Console.WriteLine($"{a} + {b} = {result} - odd");
        }
    }
}
else if (operation == "-")
{
    result = a - b;
    isEven = result % 2 == 0;
    {
        if (isEven)
        {
            Console.WriteLine($"{a} - {b} = {result} - even");
        }
        else
        {
            Console.WriteLine($"{a} - {b} = {result} - odd");
        }
    }
}
else if (operation == "*")
{
    result = a * b;
    isEven = result % 2 == 0;
    {
        if (isEven)
        {
            Console.WriteLine($"{a} * {b} = {result} - even");
        }
        else
        {
            Console.WriteLine($"{a} * {b} = {result} - odd");
        }
    }
}
else if (operation == "/")
{
    if (b == 0)
    {
        Console.WriteLine($"Cannot divide {a} by zero");
    }
    else
    {
        result = a / (double)b;
        Console.WriteLine($"{a} / {b} = {result:F2}");
    }

}
else if (operation == "%")
{
    if (b == 0)
    {
        Console.WriteLine($"Cannot divide {a} by zero");
    }
    else
    {
        result = a % b;
        Console.WriteLine($"{a} % {b} = {result}");
    }
}