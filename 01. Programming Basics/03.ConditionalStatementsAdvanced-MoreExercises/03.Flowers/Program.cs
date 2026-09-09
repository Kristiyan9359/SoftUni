
int hrizantemsBought = int.Parse(Console.ReadLine());
int rosesBought = int.Parse(Console.ReadLine());
int laletaBought = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
string holidayOrNot = Console.ReadLine();

double hrizantemsPrice = 0;
double rosesPrice = 0;
double laletaPrice = 0;



if (season == "Spring" || season == "Summer")
{
    hrizantemsPrice = 2.00;
    rosesPrice = 4.10;
    laletaPrice = 2.50;
}

else if (season == "Autumn" || season == "Winter")
{
    hrizantemsPrice = 3.75;
    rosesPrice = 4.50;
    laletaPrice = 4.15;
}

double flowerPrice = (hrizantemsBought * hrizantemsPrice) + (rosesBought * rosesPrice) + (laletaBought * laletaPrice);

if (laletaBought > 7 && season == "Spring")
{
    flowerPrice -= flowerPrice * 0.05;
}

if (rosesBought >= 10 && season == "Winter")
{
    flowerPrice -= flowerPrice * 0.10;
}
if (hrizantemsBought + rosesBought + laletaBought > 20)
{
    flowerPrice -= flowerPrice * 0.20;
}

if (holidayOrNot == "Y")
{
    flowerPrice += flowerPrice * 0.15;
}
flowerPrice += 2;

Console.WriteLine($"{flowerPrice:f2}");