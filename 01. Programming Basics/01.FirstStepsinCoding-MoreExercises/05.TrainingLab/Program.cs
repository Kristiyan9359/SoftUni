
double w = double.Parse(Console.ReadLine()) * 100;
double h = double.Parse(Console.ReadLine()) * 100;

double deskWidth = 70;
double deskLength = 120;
double corridor = 100;


int placesLength = (int)(w / deskLength);

double usableHeight = h - corridor;


int placesWidth = (int)(usableHeight / deskWidth);

int totalPlaces = placesLength * placesWidth;


totalPlaces -= 3;

Console.WriteLine(totalPlaces);