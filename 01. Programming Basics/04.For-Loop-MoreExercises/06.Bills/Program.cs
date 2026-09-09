
int months = int.Parse(Console.ReadLine());

double water = 20.00;
double internet = 15.00;

double totalCosts = 0;
double totalElectricity = 0;
double totalOther = 0;

for (int i = 0; i < months; i++)
{
    double electricity = double.Parse(Console.ReadLine());
    totalElectricity += electricity;

    double other = (electricity + water + internet) * 1.20;
    totalOther += other;
}


double totalWater = water * months;
double totalInternet = internet * months;

totalCosts = totalElectricity + totalWater + totalInternet + totalOther;

double average = totalCosts / months;

Console.WriteLine($"Electricity: {totalElectricity:F2} lv");
Console.WriteLine($"Water: {totalWater:F2} lv");
Console.WriteLine($"Internet: {totalInternet:F2} lv");
Console.WriteLine($"Other: {totalOther:F2} lv");
Console.WriteLine($"Average: {average:F2} lv");