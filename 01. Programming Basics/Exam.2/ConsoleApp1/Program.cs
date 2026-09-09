
string movieName = Console.ReadLine();
string saalType = Console.ReadLine();
int ticketsCount = int.Parse(Console.ReadLine());

double ticketsPrice = 0;

if (movieName == "A Star Is Born")
{
    if (saalType == "normal")
    {
        ticketsPrice = 7.50;
    }
    else if (saalType == "luxury")
    {
        ticketsPrice = 10.50;
    }
    else if (saalType == "ultra luxury")
    {
        ticketsPrice = 13.50;
    }
}
else if (movieName == "Bohemian Rhapsody")
{
    if (saalType == "normal")
    {
        ticketsPrice = 7.35;
    }
    else if (saalType == "luxury")
    {
        ticketsPrice = 9.45;
    }
    else if (saalType == "ultra luxury")
    {
        ticketsPrice = 12.75;
    }
}
else if (movieName == "Green Book")
{
    if (saalType == "normal")
    {
        ticketsPrice = 8.15;
    }
    else if (saalType == "luxury")
    {
        ticketsPrice = 10.25;
    }
    else if (saalType == "ultra luxury")
    {
        ticketsPrice = 13.25;
    }
}
else if (movieName == "The Favourite")
{
    if (saalType == "normal")
    {
        ticketsPrice = 8.75;
    }
    else if (saalType == "luxury")
    {
        ticketsPrice = 11.55;
    }
    else if (saalType == "ultra luxury")
    {
        ticketsPrice = 13.95;
    }
}

double finalPrice = ticketsCount * ticketsPrice;

Console.WriteLine($"{movieName} -> {finalPrice:F2} lv.");