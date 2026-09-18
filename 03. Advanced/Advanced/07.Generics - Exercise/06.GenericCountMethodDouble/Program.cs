public class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<double> list = new List<double>();

        for (int i = 0; i < number; i++)
        {
            double input = double.Parse(Console.ReadLine());

            list.Add(input);
        }

        double secondInput = double.Parse(Console.ReadLine());

        Console.WriteLine(Count(list, secondInput));

    }


    public static int Count<T>(List<T> list, T element)
        where T : IComparable<T>
    {
        int count = 0;
        foreach (T item in list)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }
}