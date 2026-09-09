
double budget = double.Parse(Console.ReadLine());
string input;

while ((input = Console.ReadLine()) != "ACTION")
{
    if (input.Length > 15)
    {
        double actorPayment = budget * 0.20;
        budget -= actorPayment;
    }
    else
    {
        double actorPayment = double.Parse(Console.ReadLine());
        budget -= actorPayment;
    }

    if (budget < 0)
    {
        Console.WriteLine($"We need {Math.Abs(budget):F2} leva for our actors.");
        return;
    }
}

Console.WriteLine($"We are left with {budget:F2} leva.");