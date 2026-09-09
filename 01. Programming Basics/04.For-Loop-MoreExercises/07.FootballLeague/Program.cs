
int stadiumCapacity = int.Parse(Console.ReadLine());
int fansCount = int.Parse(Console.ReadLine());

double sectorA = 0;
double sectorB = 0;
double sectorV = 0;
double sectorG = 0;

for (int i = 0; i < fansCount; i++)
{
    string sector = Console.ReadLine();

    if (sector == "A")
    {
        sectorA++;
    }
    else if (sector == "B")
    {
        sectorB++;
    }
    else if (sector == "V")
    {
        sectorV++;
    }
    else if (sector == "G")
    {
        sectorG++;
    }
}

double sectorApercent = (sectorA / fansCount) * 100;
double sectorBpercent = (sectorB / fansCount) * 100;
double sectorVpercent = (sectorV / fansCount) * 100;
double sectorGpercent = (sectorG / fansCount) * 100;
double allFansPercent = ((double)fansCount / stadiumCapacity) * 100;

Console.WriteLine($"{sectorApercent:F2}%");
Console.WriteLine($"{sectorBpercent:F2}%");
Console.WriteLine($"{sectorVpercent:F2}%");
Console.WriteLine($"{sectorGpercent:F2}%");
Console.WriteLine($"{allFansPercent:F2}%");