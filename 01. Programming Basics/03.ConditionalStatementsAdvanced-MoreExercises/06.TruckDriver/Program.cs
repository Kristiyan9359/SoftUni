
string season = Console.ReadLine();
double kmForMonths = double.Parse(Console.ReadLine());

double pricePerKm = 0;
double pricePerKmTaxes = 0;

if (kmForMonths <= 5000)
{
    if (season == "Spring" || season == "Autumn")
    {
        pricePerKm = 0.75;
    }
    else if (season == "Summer")
    {
        pricePerKm = 0.90;
    }
    else if (season == "Winter")
    {
        pricePerKm = 1.05;
    }
}
else if (kmForMonths > 5000 && kmForMonths <= 10000)
{
    if (season == "Spring" || season == "Autumn")
    {
        pricePerKm = 0.95;
    }
    else if (season == "Summer")
    {
        pricePerKm = 1.10;
    }
    else if (season == "Winter")
    {
        pricePerKm = 1.25;
    }
}

else if (kmForMonths > 10000 && kmForMonths <= 20000)
{
    pricePerKm = 1.45;
}

pricePerKmTaxes = pricePerKm - (pricePerKm * 0.10);
pricePerKmTaxes = pricePerKmTaxes * kmForMonths * 4;

Console.WriteLine($"{pricePerKmTaxes:f2}");

