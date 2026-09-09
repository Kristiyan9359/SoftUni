
double skumriqPrice = double.Parse(Console.ReadLine());
double cacaPrice = double.Parse(Console.ReadLine());
double palamudKilogram = double.Parse(Console.ReadLine());
double safridKilogram = double.Parse(Console.ReadLine());
double midiKilogram = double.Parse(Console.ReadLine());

double palamudPrice = 0;
double safridPrice = 0;
double midiPrice = 7.50;

palamudPrice = skumriqPrice * 1.60;
safridPrice = cacaPrice * 1.80;

double moneyNeeded = palamudPrice * palamudKilogram + safridPrice * safridKilogram + midiPrice * midiKilogram;


Console.WriteLine($"{moneyNeeded:f2}");