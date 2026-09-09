
string country = Console.ReadLine();
string item = Console.ReadLine();

double difficulty = 0;
double performance = 0;

if (country == "Russia")
{
    if (item == "ribbon")
    {
        difficulty = 9.100;
        performance = 9.400;
    }
    else if (item == "hoop")
    {
        difficulty = 9.300;
        performance = 9.800;
    }
    else if (item == "rope")
    {
        difficulty = 9.600;
        performance = 9.000;
    }
}
else if (country == "Bulgaria")
{
    if (item == "ribbon")
    {
        difficulty = 9.600;
        performance = 9.400;
    }
    else if (item == "hoop")
    {
        difficulty = 9.550;
        performance = 9.750;
    }
    else if (item == "rope")
    {
        difficulty = 9.500;
        performance = 9.400;
    }
}
else if (country == "Italy")
{
    if (item == "ribbon")
    {
        difficulty = 9.200;
        performance = 9.500;
    }
    else if (item == "hoop")
    {
        difficulty = 9.450;
        performance = 9.350;
    }
    else if (item == "rope")
    {
        difficulty = 9.700;
        performance = 9.150;
    }
}

double totalPints = difficulty + performance;

double finalPoints = 20 - totalPints;

double percent = (finalPoints / 20) * 100;

Console.WriteLine($"The team of {country} get {totalPints:F3} on {item}.");
Console.WriteLine($"{percent:F2}%");