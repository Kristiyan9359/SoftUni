class Program
{
    static void Main()
    {
        int peopleCount = int.Parse(Console.ReadLine());
        string typoOfPeople = Console.ReadLine();
        string day = Console.ReadLine();

        double price = 0;
        double discount = 0;

        if (typoOfPeople == "Students")
        {
            if (day == "Friday")
            {
                price = 8.45;
            }
            else if (day == "Saturday")
            {
                price = 9.80;
            }
            else if (day == "Sunday")
            {
                price = 10.46;
            }
            if (peopleCount >= 30)
            {
                discount = (peopleCount * price) * 0.15;
            }
        }
        else if (typoOfPeople == "Business")
        {
            if (day == "Friday")
            {
                price = 10.90;
            }
            else if (day == "Saturday")
            {
                price = 15.60;
            }
            else if (day == "Sunday")
            {
                price = 16;
            }
            if (peopleCount >= 100)
            {
                peopleCount -= 10;
            }
        }
        else if (typoOfPeople == "Regular")
        {
            if (day == "Friday")
            {
                price = 15;
            }
            else if (day == "Saturday")
            {
                price = 20;
            }
            else if (day == "Sunday")
            {
                price = 22.50;
            }
            if (peopleCount >= 10 && peopleCount <= 20)
            {
                discount = (peopleCount * price) * 0.10;
            }
        }
        double totalPrice = (peopleCount * price) - discount;

        Console.WriteLine($"Total price: {totalPrice:F2}");

    }
}