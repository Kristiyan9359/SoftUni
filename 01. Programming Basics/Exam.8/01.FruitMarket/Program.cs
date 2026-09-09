
double strawberriesPrice = double.Parse(Console.ReadLine());
double bananasInKg = double.Parse(Console.ReadLine());
double orangesInKg = double.Parse(Console.ReadLine());
double raspberriesInKg = double.Parse(Console.ReadLine());
double strawberriesInKg = double.Parse(Console.ReadLine());

double raspberriesPrice = strawberriesPrice / 2;
double orangesPrice = raspberriesPrice - (raspberriesPrice * 0.40);
double bananasPrice = raspberriesPrice - (raspberriesPrice * 0.80);

double totalPrice = (strawberriesInKg * strawberriesPrice) + (bananasInKg * bananasPrice) + (orangesInKg * orangesPrice) + (raspberriesPrice * raspberriesInKg);

Console.WriteLine($"{totalPrice:F2}");