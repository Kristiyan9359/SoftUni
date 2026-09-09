
string movieName = Console.ReadLine();
int daysCount = int.Parse(Console.ReadLine());
int ticketsCount = int.Parse(Console.ReadLine());
double ticketPrice = double.Parse(Console.ReadLine());
double cinemaPercent = double.Parse(Console.ReadLine());

double sum = (ticketsCount * ticketPrice) * daysCount;
double sumWithPercent = (sum * cinemaPercent) / 100;
double totalSum = sum - sumWithPercent;

Console.WriteLine($"The profit from the movie {movieName} is {totalSum:F2} lv.");