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

        string[] indexes = secondInput.Split();

        int firstIndex = int.Parse(indexes[0]);

        int secondIndex = int.Parse(indexes[1]);

        Swap(list, firstIndex, secondIndex);

        foreach (string input in list)
        {
            Console.WriteLine($"{input.GetType().FullName}: {input}");
        }
    }

    static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
    {
        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }
}