
int M = int.Parse(Console.ReadLine());

List<string> combinations = new List<string>();

for (int a = 1; a <= 9; a++)
{
    for (int b = 1; b <= 9; b++)
    {
        for (int c = 1; c <= 9; c++)
        {
            for (int d = 1; d <= 9; d++)
            {
                if (a < b && c > d && (a * b + c * d) == M)
                {
                    string combination = $"{a}{b}{c}{d}";
                    combinations.Add(combination);
                    Console.Write($"{combination} ");
                }
            }
        }
    }
}

Console.WriteLine();

if (combinations.Count >= 4)
{
    Console.WriteLine($"Password: {combinations[3]}");
}
else
{
    Console.WriteLine("No!");
}