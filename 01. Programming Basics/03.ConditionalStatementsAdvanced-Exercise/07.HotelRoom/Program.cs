
string month = Console.ReadLine();
int daysStay = int.Parse(Console.ReadLine());

double studioPrice = 0;
double apartmentPrice = 0;

if (month == "May" || month == "October")
{
    studioPrice = 50;
    apartmentPrice = 65;

    if (daysStay > 7 && daysStay <= 14)
    {
        studioPrice = studioPrice * 0.95;
    }
    else if (daysStay > 14)
    {
        studioPrice = studioPrice * 0.70;
    }
}

else if (month == "June" || month == "September")
{
    studioPrice = 75.20;
    apartmentPrice = 68.70;

    if (daysStay > 14)
    {
        studioPrice = studioPrice * 0.80;
    }
}

else if (month == "July" || month == "August")
{
    studioPrice = 76;
    apartmentPrice = 77;
}

if (daysStay > 14)
{
    apartmentPrice = apartmentPrice * 0.90;
}

double studioBill = daysStay * studioPrice;
double apartmentBill = daysStay *  apartmentPrice;

Console.WriteLine($"Apartment: {apartmentBill:F2} lv.");
Console.WriteLine($"Studio: {studioBill:F2} lv.");