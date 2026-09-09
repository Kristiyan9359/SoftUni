
string destination = Console.ReadLine();
string dates = Console.ReadLine();
int nights = int.Parse(Console.ReadLine());

int nightPrice = 0;

if (destination == "France")
{
    if (dates == "21-23")
    {
        nightPrice = 30;
    }
    else if (dates == "24-27")
    {
        nightPrice = 35;
    }
    else if (dates == "28-31")
    {
        nightPrice = 40;
    }
}
else if (destination == "Italy")
{
    if (dates == "21-23")
    {
        nightPrice = 28;
    }
    else if (dates == "24-27")
    {
        nightPrice = 32;
    }
    else if (dates == "28-31")
    {
        nightPrice = 39;
    }
}
else if (destination == "Germany")
{
    if (dates == "21-23")
    {
        nightPrice = 32;
    }
    else if (dates == "24-27")
    {
        nightPrice = 37;
    }
    else if (dates == "28-31")
    {
        nightPrice = 43;
    }
}

double totalSum = nightPrice * nights;
Console.WriteLine($"Easter trip to {destination} : {totalSum:F2} leva.");