
string name = Console.ReadLine();
int adultTickets = int.Parse(Console.ReadLine());
int kidTickets = int.Parse(Console.ReadLine());
double adultPrice = double.Parse(Console.ReadLine());
double servicePrice = double.Parse(Console.ReadLine());

double kidPrice = adultPrice - (adultPrice * 0.70);

double adultPriceWithSercice = adultPrice + servicePrice;
double kidPriceWithService = kidPrice + servicePrice;

double totalPrice = (adultPriceWithSercice * adultTickets) + (kidPriceWithService * kidTickets);
double agencyWin = totalPrice * 0.20;

Console.WriteLine($"The profit of your agency from {name} tickets is {agencyWin:F2} lv.");