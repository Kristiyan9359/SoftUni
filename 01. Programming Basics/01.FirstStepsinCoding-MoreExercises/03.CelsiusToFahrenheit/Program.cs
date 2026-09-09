//°F = °C × 1,8 + 32

double celsius = double.Parse(Console.ReadLine());
double farhenheit = celsius * 1.8 + 32;

Console.WriteLine($"{farhenheit:f2}");