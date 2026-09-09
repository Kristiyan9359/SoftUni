
string eggsSize = Console.ReadLine();
string eggsColor = Console.ReadLine();
int batchCount = int.Parse(Console.ReadLine());

int batchPrice = 0;

if (eggsSize == "Large")
{
    if (eggsColor == "Red")
    {
        batchPrice = 16;
    }
    else if (eggsColor == "Green")
    {
        batchPrice = 12;
    }
    else if (eggsColor == "Yellow")
    {
        batchPrice = 9;
    }
}
else if (eggsSize == "Medium")
{
    if (eggsColor == "Red")
    {
        batchPrice = 13;
    }
    else if (eggsColor == "Green")
    {
        batchPrice = 9;
    }
    else if (eggsColor == "Yellow")
    {
        batchPrice = 7;
    }
}
else if (eggsSize == "Small")
{
    if (eggsColor == "Red")
    {
        batchPrice = 9;
    }
    else if (eggsColor == "Green")
    {
        batchPrice = 8;
    }
    else if (eggsColor == "Yellow")
    {
        batchPrice = 5;
    }
}

double totalSum = batchPrice * batchCount;
double produciontCosts = totalSum * 0.35;
double finalCost = totalSum - produciontCosts;

Console.WriteLine($"{finalCost:F2} leva.");