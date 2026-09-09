internal class Program
{
    static void Main()
    {

        List<int> numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();

        int moves = int.Parse(Console.ReadLine());

        for (int i = 0; i < moves; i++)
        {
            int firstArr = numbers[0];
            numbers.RemoveAt(0);
            numbers.Add(firstArr);
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}