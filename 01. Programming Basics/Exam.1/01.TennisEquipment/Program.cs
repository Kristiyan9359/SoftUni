
double rocketPrice = double.Parse(Console.ReadLine());
int rocketsCount = int.Parse(Console.ReadLine());
int shoesCount = int.Parse(Console.ReadLine());

double shoesPrice = rocketPrice / 6;

double totalRocketPrice = rocketsCount * rocketPrice;
double totalShoesPrice = shoesCount * shoesPrice;
double totalOtherPrice = (totalRocketPrice + totalShoesPrice) * 0.20;
double finalPrice = totalRocketPrice + totalShoesPrice + totalOtherPrice;

double djokovic = Math.Floor(finalPrice / 8);
double sponsors = Math.Ceiling(finalPrice * 7 / 8);

Console.WriteLine($"Price to be paid by Djokovic {djokovic}");
Console.WriteLine($"Price to be paid by sponsors {sponsors}");
