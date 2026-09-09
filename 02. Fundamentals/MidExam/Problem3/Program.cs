namespace Problem3;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(", ");
        int entryPoint = int.Parse(Console.ReadLine());
        string itemType = Console.ReadLine();

        int entryPrice = int.Parse(input[entryPoint]);

        int leftSum = 0;
        int rightSum = 0;

        for (int i = 0; i < entryPoint; i++)
        {
            int price = int.Parse(input[i]);

            if ((itemType == "cheap" && price < entryPrice) || (itemType == "expensive" && price >= entryPrice))
            {
                leftSum += price;
            }
        }

        for (int i = entryPoint + 1; i < input.Length; i++)
        {
            int price = int.Parse(input[i]);

            if ((itemType == "cheap" && price < entryPrice) || (itemType == "expensive" && price >= entryPrice))
            {
                rightSum += price;
            }
        }

        if (leftSum >= rightSum)
        {
            Console.WriteLine($"Left - {leftSum}");
        }
        else
        {
            Console.WriteLine($"Right - {rightSum}");
        }
    }
}