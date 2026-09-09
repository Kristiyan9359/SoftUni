
string season = Console.ReadLine();
string groupType = Console.ReadLine();
int studentsCount = int.Parse(Console.ReadLine());
int nightsCount = int.Parse(Console.ReadLine());

double pricePerNight = 0;
string sport = "";

if (season == "Winter")
{
    if (groupType == "boys")
    {
        pricePerNight = 9.60;
        sport = "Judo";
    }
    else if (groupType == "girls")
    {
        pricePerNight = 9.60;
        sport = "Gymnastics";
    }
    else if (groupType == "mixed")
    {
        pricePerNight = 10;
        sport = "Ski";
    }
}
else if (season == "Spring")
{
    if (groupType == "boys")
    {
        pricePerNight = 7.20;
        sport = "Tennis";
    }
    else if (groupType == "girls")
    {
        pricePerNight = 7.20;
        sport = "Athletics";
    }
    else if (groupType == "mixed")
    {
        pricePerNight = 9.50;
        sport = "Cycling";
    }
}
else if (season == "Summer")
{
    if (groupType == "boys")
    {
        pricePerNight = 15;
        sport = "Football";
    }
    else if (groupType == "girls")
    {
        pricePerNight = 15;
        sport = "Volleyball";
    }
    else if (groupType == "mixed")
    {
        pricePerNight = 20;
        sport = "Swimming";
    }
}

double totalPrice = pricePerNight * studentsCount * nightsCount;


if (studentsCount >= 50)
{
    totalPrice *= 0.50;
}
else if (studentsCount >= 20 && studentsCount < 50)
{
    totalPrice *= 0.85;
}
else if (studentsCount >= 10 && studentsCount < 20)
{
    totalPrice *= 0.95;
}

Console.WriteLine($"{sport} {totalPrice:F2} lv.");