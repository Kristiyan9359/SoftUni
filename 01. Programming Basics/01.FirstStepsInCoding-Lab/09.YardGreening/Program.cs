
double area = double.Parse(Console.ReadLine());

double pricePerSquareMeter = 7.61;

double discountPercentage = 18.0;

double totalCostWithoutDiscount = area * pricePerSquareMeter;

double discountAmount = (discountPercentage / 100) * totalCostWithoutDiscount;

double finalCost = totalCostWithoutDiscount - discountAmount;

Console.WriteLine($"{finalCost:F2} lv.");

Console.WriteLine($"{discountAmount:F2} lv.");