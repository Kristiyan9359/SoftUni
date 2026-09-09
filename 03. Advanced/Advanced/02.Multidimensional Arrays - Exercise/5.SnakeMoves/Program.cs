internal class Program
{
    static void Main()
    {
        int[] dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int rows = dimension[0];
        int cols = dimension[1];

        string text = Console.ReadLine();

        int index = 0;

        char[,] matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++, index = (index + 1) % text.Length)

            {
                int col;
                if (i % 2 == 0)
                {
                    col = j;
                }
                else
                {
                    col = cols - (j + 1);
                }
                matrix[i, col] = text[index];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}