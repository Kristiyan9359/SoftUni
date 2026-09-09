class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] firstArr = input.Split();

        input = Console.ReadLine();


        string[] secondArr = input.Split();

        for (int j = 0; j < secondArr.Length; j++)
        {
            for (int i = 0; i < firstArr.Length; i++)
            {
                if (firstArr[i] == secondArr[j])
                {
                    Console.Write($"{firstArr[i]} ");
                    break;
                }
            }
        }
    }
}