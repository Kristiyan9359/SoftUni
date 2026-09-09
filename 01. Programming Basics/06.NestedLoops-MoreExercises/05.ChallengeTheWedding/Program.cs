int maleCount = int.Parse(Console.ReadLine());
int femaleCount = int.Parse(Console.ReadLine());
int maxTables = int.Parse(Console.ReadLine());

int tableCounter = 0;
string result = "";

for (int male = 1; male <= maleCount; male++)
{
    for (int female = 1; female <= femaleCount; female++)
    {
        if (tableCounter >= maxTables)
        {
            break;
        }

        result += $"({male} <-> {female}) ";
        tableCounter++;
    }

    if (tableCounter >= maxTables)
    {
        break;
    }
}

Console.WriteLine(result.Trim());
