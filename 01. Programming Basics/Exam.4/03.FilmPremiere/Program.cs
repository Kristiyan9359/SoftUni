
string movieName = Console.ReadLine();
string drinkOrFood = Console.ReadLine();
int ticketCount = int.Parse(Console.ReadLine());

double ticketPrice = 0;
double discount = 0;

if (movieName == "John Wick")
{
    if (drinkOrFood == "Drink")
    {
        ticketPrice = 12;
    }
    else if (drinkOrFood == "Popcorn")
    {
        ticketPrice = 15;
    }
    else if (drinkOrFood == "Menu")
    {
        ticketPrice = 19;
    }
}
else if (movieName == "Star Wars")
{
    if (drinkOrFood == "Drink")
    {
        ticketPrice = 18;
    }
    else if (drinkOrFood == "Popcorn")
    {
        ticketPrice = 25;
    }
    else if (drinkOrFood == "Menu")
    {
        ticketPrice = 30;
    }

    if (ticketCount >= 4)
    {
        discount = (ticketPrice * ticketCount) * 0.30;
    }
}
else if (movieName == "Jumanji")
{
    if (drinkOrFood == "Drink")
    {
        ticketPrice = 9;
    }
    else if (drinkOrFood == "Popcorn")
    {
        ticketPrice = 11;
    }
    else if (drinkOrFood == "Menu")
    {
        ticketPrice = 14;
    }

    if (ticketCount == 2)
    {
        discount = (ticketPrice * ticketCount) * 0.15;
    }
}

double finalPrice = (ticketCount * ticketPrice) - discount;

Console.WriteLine($"Your bill is {finalPrice:F2} leva.");