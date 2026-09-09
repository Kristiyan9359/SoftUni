
int voucherValue = int.Parse(Console.ReadLine());
string input;
int ticketCount = 0;
int otherPurchaseCount = 0;

while ((input = Console.ReadLine()) != "End")
{
    int price = 0;

    if (input.Length > 8)
    {
        price = input[0] + input[1];
    }
    else
    {
        price = input[0];
    }

    if (voucherValue >= price)
    {
        voucherValue -= price;
        if (input.Length > 8)
        {
            ticketCount++;
        }
        else
        {
            otherPurchaseCount++;
        }
    }
    else
    {
        break;
    }
}
Console.WriteLine(ticketCount);
Console.WriteLine(otherPurchaseCount);