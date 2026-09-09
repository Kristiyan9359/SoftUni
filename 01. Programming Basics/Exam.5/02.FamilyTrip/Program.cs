
double budget = double.Parse(Console.ReadLine());
int nightsCount = int.Parse(Console.ReadLine());
double nightsPrice = double.Parse(Console.ReadLine());
int addExpensesPercent = int.Parse(Console.ReadLine());

if (nightsCount > 7)
{
    nightsPrice *= 0.95;
}

double totalNightsPrice = nightsPrice * nightsCount;

double addExpenses = addExpensesPercent * budget / 100;

double totalPrice = totalNightsPrice + addExpenses;

if (budget >= totalPrice)
{
    double moneyLeft = budget - totalPrice;
    Console.WriteLine($"Ivanovi will be left with {moneyLeft:F2} leva after vacation.");
}
else
{
    double moneyNeed = totalPrice - budget;
    Console.WriteLine($"{moneyNeed:F2} leva needed.");
}