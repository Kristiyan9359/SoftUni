
double rent = double.Parse(Console.ReadLine());

double cakePrice = rent * 0.20;
double drinksPrice = cakePrice - (cakePrice * 0.45);
double animator = rent / 3;

double finalPrice = rent + cakePrice + drinksPrice + animator;

Console.WriteLine($"{finalPrice:F1}");