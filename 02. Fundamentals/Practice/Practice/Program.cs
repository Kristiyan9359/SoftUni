public class Program
{
    const char Spy = 'S';
    const char Exit = 'E';
    const char Guard = 'G';
    const char BlindSpot = 'B';
    static void Main()
    {
        var moves = new Dictionary<string, (int RowChange, int ColChange)>
        {
            ["up"] = (-1, 0),
            ["down"] = (1, 0),
            ["left"] = (0, -1),
            ["right"] = (0, 1)
        };

        int n = int.Parse(Console.ReadLine());

        char[,] field = ReadMatrix(n);

        (int spyRow, int spyCol) = FindSpy(field);

        int points = 100;


        while (true)
        {
            string command = Console.ReadLine();

            if (!moves.ContainsKey(command))
                continue;
            int newRow = spyRow + moves[command].RowChange;
            int newCol = spyCol + moves[command].ColChange;

            if (newRow < 0 || newRow >= field.GetLength(0) ||
                newCol < 0 || newCol >= field.GetLength(1))
                continue;

            field[spyRow, spyCol] = '.';

            char currentPosition = field[newRow, newCol];

            spyRow = newRow;
            spyCol = newCol;

            if (points <= 0)
            {
                Console.WriteLine("Mission failed. Spy compromised");
                field[spyRow, spyCol] = Spy;
                break;
            }
            if (currentPosition == Exit)
            {
                Console.WriteLine("Mission accomplished. Spy extracted successfully.");
                break;
            }

            else if (currentPosition == Guard)
            {
                points -= 40;

                if (points <= 0)
                {
                    Console.WriteLine("Mission failed. Spy compromised.");
                    field[spyRow, spyCol] = Spy;
                    break;
                }

                field[spyRow, spyCol] = '.';
            }
            else if (currentPosition == BlindSpot)
            {
                points += 15;
                if (points > 100)
                    points = 100;

                field[spyRow, spyCol] = '.';
            }
            field[spyRow, spyCol] = Spy;
        }

        Console.WriteLine($"Stealth level: {points} units");
        PrintMatrix(field);
    }

    static char[,] ReadMatrix(int n)
    {
        char[,] matrix = new char[n, n];

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            for (int j = 0; j < n; j++)
                matrix[i, j] = input[j];
        }

        return matrix;
    }

    static (int Row, int Col) FindSpy(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == Spy)
                    return (i, j);
            }
        }

        return (-1, -1);
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j]);

            Console.WriteLine();
        }
    }
}