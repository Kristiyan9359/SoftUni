using System.Numerics;

class Program
{
    static void Main()
    {

        int number = int.Parse(Console.ReadLine());

        int bestSnow = 0;
        int bestTime = 0;
        int bestQuality = 0;

        BigInteger bestValue = 0;

        for (int i = 0; i < number; i++)
        {

            int snow = int.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            int quality = int.Parse(Console.ReadLine());

            BigInteger value = BigInteger.Pow(snow / time, quality);

            if (bestValue < value)
            {
                bestValue = value;
                bestSnow = snow;
                bestTime = time;
                bestQuality = quality;
            }
        }
        Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");

    }
}