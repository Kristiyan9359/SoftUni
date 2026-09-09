internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            int[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = values[j];
            }
        }

        int primaryDiagonalSum = 0;
        int secondaryDiagonalSum = 0;

        for (int i = 0; i < n; i++)
        {
            primaryDiagonalSum += matrix[i, i];
            secondaryDiagonalSum += matrix[i, n - 1 - i];
        }

        int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

        Console.WriteLine(difference);
    }
}