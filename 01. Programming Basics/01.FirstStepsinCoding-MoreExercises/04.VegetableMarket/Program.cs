
double veggiePrice = double.Parse(Console.ReadLine());
double fruitsPrice = double.Parse(Console.ReadLine());
int kgVeggie = int.Parse(Console.ReadLine());
int kgFruits = int.Parse(Console.ReadLine());

veggiePrice = veggiePrice * kgVeggie;
fruitsPrice = fruitsPrice * kgFruits;

double finalPrice = veggiePrice + fruitsPrice;

finalPrice = finalPrice / 1.94;

Console.WriteLine($"{finalPrice:f2}");