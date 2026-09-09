class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        int studentsCount = int.Parse(Console.ReadLine());
        double priceOfSaber = double.Parse(Console.ReadLine());
        double priceOfRobes = double.Parse(Console.ReadLine());
        double priceOfBelts = double.Parse(Console.ReadLine());

        double percent = (double)studentsCount * 10 / 100;
        double allSabers = studentsCount + Math.Ceiling(percent);
        double sabers = priceOfSaber * allSabers;

        double robes = priceOfRobes * studentsCount;

        double beltDiscount = studentsCount - Math.Ceiling((double)(studentsCount / 6));
        double belts = priceOfBelts * beltDiscount;

        double totalSum = sabers + robes + belts;

        if (budget >= totalSum)
        {
            Console.WriteLine($"The money is enough - it would cost {totalSum:F2}lv.");
        }
        else
        {
            double moneyNeed = totalSum - budget;
            Console.WriteLine($"John will need {moneyNeed:F2}lv more.");
        }
    }
}