
string actorName = Console.ReadLine();
double academyPoints = double.Parse(Console.ReadLine());
int juryCount = int.Parse(Console.ReadLine());


for (int i = 0; i < juryCount; i++)
{
    string juryName = Console.ReadLine();
    double juryPoints = double.Parse(Console.ReadLine());

    double points = (juryName.Length * juryPoints) / 2;
    academyPoints += points;

    if (academyPoints > 1250.5)
    {
        Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {academyPoints:F1}!");
        return;
    }

}
double pointsNeed = 1250.5 - academyPoints;
Console.WriteLine($"Sorry, {actorName} you need {pointsNeed:F1} more!");
