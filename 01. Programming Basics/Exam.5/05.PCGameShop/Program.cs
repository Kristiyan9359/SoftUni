
int selledGames = int.Parse(Console.ReadLine());

int hearthstone = 0;
int fornite = 0;
int overwatch = 0;
int others = 0;

for (int i = 0; i < selledGames; i++)
{
    string game = Console.ReadLine();

    if (game == "Hearthstone")
    {
        hearthstone++;
    }
    else if (game == "Fornite")
    {
        fornite++;
    }
    else if (game == "Overwatch")
    {
        overwatch++;
    }
    else
    {
        others++;
    }
}
double hearthstonePercent = (double)hearthstone / selledGames * 100;
Console.WriteLine($"Hearthstone - {hearthstonePercent:F2}%");
double fornitePercent = (double)fornite / selledGames * 100;
Console.WriteLine($"Fornite - {fornitePercent:F2}%");
double overwatchPercent = (double)overwatch / selledGames * 100;
Console.WriteLine($"Overwatch - {overwatchPercent:F2}%");
double othersPercent = (double)others / selledGames * 100;
Console.WriteLine($"Others - {othersPercent:F2}%");