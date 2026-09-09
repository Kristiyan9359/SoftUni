
double rent = double.Parse(Console.ReadLine());

double statuets = rent - (rent * 0.30);
double catering = statuets - (statuets * 0.15);
double music = catering / 2;

double finalPrice = rent + statuets + catering + music;

Console.WriteLine($"{finalPrice:F2}");