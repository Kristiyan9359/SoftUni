class Program
{
    static void Main()
    {
        int fieldLength = int.Parse(Console.ReadLine());
        int[] bugPlaces = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] field = new int[fieldLength];

        for (int i = 0; i < bugPlaces.Length; i++)
        {
            int bugIndex = bugPlaces[i];
            if (bugIndex >= 0 && bugIndex <= field.Length - 1)
            {
                field[bugIndex] = 1;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();
            int bugIndex = int.Parse(arguments[0]);
            string direction = arguments[1];
            int distance = int.Parse(arguments[2]);

            if (bugIndex >= 0 && bugIndex <= field.Length - 1 && field[bugIndex] == 1)
            {
                field[bugIndex] = 0;
                int landIndex;
                switch (direction)
                {
                    case "right":
                        {
                            landIndex = bugIndex + distance;
                            while (landIndex >= 0 && landIndex <= field.Length - 1 && field[landIndex] == 1)
                            {
                                landIndex += distance;
                            }

                            if (landIndex >= 0 && landIndex <= field.Length - 1)
                            {
                                field[landIndex] = 1;
                            }

                            break;
                        }
                    case "left":
                        {
                            landIndex = bugIndex - distance;
                            while (landIndex >= 0 && landIndex <= field.Length - 1 && field[landIndex] == 1)
                            {
                                landIndex -= distance;
                            }

                            if (landIndex >= 0 && landIndex <= field.Length - 1)
                            {
                                field[landIndex] = 1;
                            }

                            break;
                        }
                }
            }
        }

        Console.WriteLine(string.Join(" ", field));
    }
}