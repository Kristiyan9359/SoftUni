
string projection = Console.ReadLine();
int r = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

double price = 0;

if (projection == "Premiere")
{
    price = 12;
}
else if (projection == "Normal")
{
    price = 7.50;
}
else if (projection == "Discount")
{
    price = 5;
}

double finalPrice = r * c * price;

Console.WriteLine($"{finalPrice:F2}");