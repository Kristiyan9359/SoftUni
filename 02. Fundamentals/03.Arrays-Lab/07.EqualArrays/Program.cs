class Program
{
    static void Main()
    {

        int[] arr1 = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToArray();


        int[] arr2 = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        bool isEqual = true;
        int index = 0;
        int sum = 0;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
            {
                isEqual = false;
                index = i;
                break;
            }
            sum += arr1[i];
        }

        if (isEqual)
        {
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
        else
        {
            Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
        }
    }
}