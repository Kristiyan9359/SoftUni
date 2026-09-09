class Program
{
    static void Main()
    {
        int lostGames = int.Parse(Console.ReadLine());
        double headsetPrice = double.Parse(Console.ReadLine());
        double mousePrice = double.Parse(Console.ReadLine());
        double keyboardPrice = double.Parse(Console.ReadLine());
        double displayPrice = double.Parse(Console.ReadLine());

        int headsetTrashed = 0;
        double miceTrashed = 0;
        double keyboardTrashed = 0;
        double displayTrashed = 0;


        for (int i = 1; i <= lostGames; i++)
        {
            if (i % 2 == 0)
            {
                headsetTrashed++;
            }
            if (i % 3 == 0)
            {
                miceTrashed++;
            }
            if (i % 2 == 0 && i % 3 == 0)
            {
                keyboardTrashed++;
                if (keyboardTrashed % 2 == 0)
                {
                    displayTrashed++;
                }
            }
        }

        double expenses = miceTrashed * mousePrice + keyboardTrashed * keyboardPrice + displayTrashed * displayPrice + headsetTrashed * headsetPrice;

        Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
    }
}