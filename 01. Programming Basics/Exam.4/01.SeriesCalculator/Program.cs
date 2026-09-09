
string movieName = Console.ReadLine();
int seasonsCount = int.Parse(Console.ReadLine());
int episodesCount = int.Parse(Console.ReadLine());
double episodeLenghtWithoutAd = double.Parse(Console.ReadLine());

double advertisment = episodeLenghtWithoutAd * 0.20;

double episodeLenghtWithAd = episodeLenghtWithoutAd + advertisment;

double additionalTime = seasonsCount * 10;

double lenght = episodeLenghtWithAd * episodesCount * seasonsCount + additionalTime;

Console.WriteLine($"Total time needed to watch the {movieName} series is {Math.Floor(lenght)} minutes.");