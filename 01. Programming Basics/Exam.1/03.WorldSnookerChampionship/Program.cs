
string stage = Console.ReadLine();
string ticketKind = Console.ReadLine();
int ticketCount = int.Parse(Console.ReadLine());
string picWithTrophy = Console.ReadLine();

double ticketPrice = 0;

if (stage == "Quarter final")
{
    if (ticketKind == "Standard") ticketPrice = 55.50;
    else if (ticketKind == "Premium") ticketPrice = 105.20;
    else if (ticketKind == "VIP") ticketPrice = 118.90;
}
else if (stage == "Semi final")
{
    if (ticketKind == "Standard") ticketPrice = 75.88;
    else if (ticketKind == "Premium") ticketPrice = 125.22;
    else if (ticketKind == "VIP") ticketPrice = 300.40;
}
else if (stage == "Final")
{
    if (ticketKind == "Standard") ticketPrice = 110.10;
    else if (ticketKind == "Premium") ticketPrice = 160.66;
    else if (ticketKind == "VIP") ticketPrice = 400;
}

double totalPrice = ticketCount * ticketPrice;

if (totalPrice > 4000)
{
    totalPrice *= 0.75;
}
else if (totalPrice > 2500)
{
    totalPrice *= 0.90;
}

if (picWithTrophy == "Y" && totalPrice <= 4000)
{
    totalPrice += ticketCount * 40;
}

Console.WriteLine($"{totalPrice:F2}");