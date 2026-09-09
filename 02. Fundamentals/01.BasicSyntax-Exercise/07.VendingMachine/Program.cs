class Program
{
    static void Main()
    {
        double nutsPrice = 2;
        double waterPrice = 0.7;
        double crispsPrice = 1.5;
        double sodaPrice = 0.8;
        double cokePrice = 1;

        string input;
        double balance = 0;

        while ((input = Console.ReadLine()) != "Start")
        {
            double coin = double.Parse(input);

            if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
            {
                balance += coin;
            }
            else
            {
                Console.WriteLine($"Cannot accept {coin}");
            }
        }

        while ((input = Console.ReadLine()) != "End")
        {
            switch (input)
            {
                case "Nuts":
                    if (balance >= nutsPrice)
                    {
                        balance -= nutsPrice;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    break;
                case "Water":
                    if (balance >= waterPrice)
                    {
                        balance -= waterPrice;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    break;
                case "Crisps":
                    if (balance >= crispsPrice)
                    {
                        balance -= crispsPrice;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    break;
                case "Soda":
                    if (balance >= sodaPrice)
                    {
                        balance -= sodaPrice;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    break;
                case "Coke":
                    if (balance >= cokePrice)
                    {
                        balance -= cokePrice;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid product");
                    break;
            }

        }
        Console.WriteLine($"Change: {balance:F2}");
    }
}