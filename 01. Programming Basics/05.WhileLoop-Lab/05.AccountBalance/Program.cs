
string input = Console.ReadLine();

double sum = 0;

while (input != "NoMoreMoney")
{
    double payment = double.Parse(input);
    
    if (payment < 0)
    {
        Console.WriteLine("Invalid operation!");
        break;
    }
    
    Console.WriteLine($"Increase: {payment:f2}");
    sum += payment;

    input = Console.ReadLine();
}
Console.WriteLine($"Total: {sum:f2}");