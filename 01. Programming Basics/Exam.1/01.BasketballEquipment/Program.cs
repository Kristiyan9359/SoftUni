
double yearFee = double.Parse(Console.ReadLine());

double shoes = yearFee * 0.60;
double outfit = shoes * 0.80;
double ball = outfit / 4;
double accesoaries = ball / 5;

double finalPrice = yearFee + shoes + outfit + ball + accesoaries;

Console.WriteLine($"{finalPrice:F2}");