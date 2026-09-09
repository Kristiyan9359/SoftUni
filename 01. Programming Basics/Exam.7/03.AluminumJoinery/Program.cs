
int windowCount = int.Parse(Console.ReadLine());
string windowType = Console.ReadLine();
string deliveryOption = Console.ReadLine();

if (windowCount < 10)
{
    Console.WriteLine("Invalid order");
    return;
}

double pricePerWindow = 0;
double discount = 0;

if (windowType == "90X130")
{
    pricePerWindow = 110;
    if (windowCount > 60)
        discount = 0.08;
    else if (windowCount > 30)
        discount = 0.05;
}
else if (windowType == "100X150")
{
    pricePerWindow = 140;
    if (windowCount > 80)
        discount = 0.10;
    else if (windowCount > 40)
        discount = 0.06;
}
else if (windowType == "130X180")
{
    pricePerWindow = 190;
    if (windowCount > 50)
        discount = 0.12;
    else if (windowCount > 20)
        discount = 0.07;
}
else if (windowType == "200X300")
{
    pricePerWindow = 250;
    if (windowCount > 50)
        discount = 0.14;
    else if (windowCount > 25)
        discount = 0.09;
}

double totalPrice = pricePerWindow * windowCount;

totalPrice -= totalPrice * discount;

if (deliveryOption == "With delivery")
{
    totalPrice += 60;
}

if (windowCount > 99)
{
    totalPrice -= totalPrice * 0.04;
}

Console.WriteLine($"{totalPrice:F2} BGN");