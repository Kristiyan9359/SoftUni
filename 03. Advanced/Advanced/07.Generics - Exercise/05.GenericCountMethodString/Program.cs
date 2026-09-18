public class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<string> list = new List<string>();

        for (int i = 0; i < number; i++)
        {
            string input = Console.ReadLine();

            list.Add(input);
        }

        string secondInput = Console.ReadLine();

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

public class Box<T> : IComparable<Box<T>>
    where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public int CompareTo(Box<T> other)
    {
        return value.CompareTo(other.value);
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {value}";
    }
}