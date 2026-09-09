class Program
{
    static void Main()
    {

        int number = int.Parse(Console.ReadLine());

        int capacity = 255;
        int pouredWater = 0;

        for (int i = 0; i < number; i++)
        {
            int quantitiy = int.Parse(Console.ReadLine());


            if (quantitiy + pouredWater > capacity)
            {
                Console.WriteLine("Insufficient capacity!");
            }
            else
            {
                pouredWater += quantitiy;
            }
        }
        Console.WriteLine(pouredWater);
    }
}