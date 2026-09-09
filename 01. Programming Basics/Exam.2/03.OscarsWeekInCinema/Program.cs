
string movieName = Console.ReadLine();
string haalType = Console.ReadLine();
int ticketsBought = int.Parse(Console.ReadLine());

double ticketPrice = 0;

if (movieName == "A Star Is Born")
{
    if (haalType == "normal")
    {
        ticketPrice = 7.50;
    }
    else if (haalType == "luxury")
    {
        ticketPrice = 10.50;
    }
    else if (haalType == "ultra luxury")
    {
        ticketPrice = 13.50;
    }
}
else if (movieName == "Bohemian Rhapsody")
{
    if (haalType == "normal")
    {
        ticketPrice = 7.35;
    }
    else if (haalType == "luxury")
    {
        ticketPrice = 9.45;
    }
    else if (haalType == "ultra luxury")
    {
        ticketPrice = 12.75;
    }
}
else if (movieName == "Green Book")
{
    if (haalType == "normal")
    {
        ticketPrice = 8.15;
    }
    else if (haalType == "luxury")
    {
        ticketPrice = 10.25;
    }
    else if (haalType == "ultra luxury")
    {
        ticketPrice = 13.25;
    }
}
else if (movieName == "The Favourite")
{
    if (haalType == "normal")
    {
        ticketPrice = 8.75;
    }
    else if (haalType == "luxury")
    {
        ticketPrice = 11.55;
    }
    else if (haalType == "ultra luxury")
    {
        ticketPrice = 13.95;
    }
}

double totalSum = ticketsBought * ticketPrice;

Console.WriteLine($"{movieName} -> {totalSum:F2} lv.");