class Program
{
    static void Main()
    {

        string kegModel;
        double kegRadius;
        int kegHeight;

        string biggestKegModel = "";
        double biggestKeg = 0;

        int kegCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < kegCount; i++)
        {
            kegModel = Console.ReadLine();
            kegRadius = double.Parse(Console.ReadLine());
            kegHeight = int.Parse(Console.ReadLine());

            double volume = Math.PI * (kegRadius * kegRadius) * kegHeight;

            if (biggestKeg < volume)
            {
                biggestKeg = volume;
                biggestKegModel = kegModel;
            }
        }

        Console.WriteLine(biggestKegModel);
    }
}