
int totalVisitors = int.Parse(Console.ReadLine());

int backCount = 0;
int chestCount = 0;
int legsCount = 0;
int absCount = 0;
int shakeCount = 0;
int barCount = 0;

for (int i = 0; i < totalVisitors; i++)
{
    string activity = Console.ReadLine();

    switch (activity)
    {
        case "Back":
            backCount++;
            break;
        case "Chest":
            chestCount++;
            break;
        case "Legs":
            legsCount++;
            break;
        case "Abs":
            absCount++;
            break;
        case "Protein shake":
            shakeCount++;
            break;
        case "Protein bar":
            barCount++;
            break;
    }
}

Console.WriteLine($"{backCount} - back");
Console.WriteLine($"{chestCount} - chest");
Console.WriteLine($"{legsCount} - legs");
Console.WriteLine($"{absCount} - abs");
Console.WriteLine($"{shakeCount} - protein shake");
Console.WriteLine($"{barCount} - protein bar");

double workOutPercent = (backCount + chestCount + legsCount + absCount) * 100.0 / totalVisitors;
double proteinPercent = (shakeCount + barCount) * 100.0 / totalVisitors;

Console.WriteLine($"{workOutPercent:F2}% - work out");
Console.WriteLine($"{proteinPercent:F2}% - protein");