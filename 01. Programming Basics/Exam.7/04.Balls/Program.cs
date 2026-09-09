
int num = int.Parse(Console.ReadLine());

int redBalls = 0;
int orangeBalls = 0;
int yellowBalls = 0;
int whiteBalls = 0;
int otherBalls = 0;
int divides = 0;

double totalPoints = 0;

for (int i = 0; i < num; i++)
{
    string color = Console.ReadLine();

    if (color == "red")
    {
        totalPoints += 5;
        redBalls++;
    }
    else if (color == "orange")
    {
        totalPoints += 10;
        orangeBalls++;
    }
    else if (color == "yellow")
    {
        totalPoints += 15;
        yellowBalls++;
    }
    else if (color == "white")
    {
        totalPoints += 20;
        whiteBalls++;
    }
    else if (color == "black")
    {
        totalPoints = Math.Floor(totalPoints / 2);
        divides++;
    }
    else
    {
        otherBalls++;
    }
}
Console.WriteLine($"Total points: {totalPoints}");
Console.WriteLine($"Red balls: {redBalls}");
Console.WriteLine($"Orange balls: {orangeBalls}");
Console.WriteLine($"Yellow balls: {yellowBalls}");
Console.WriteLine($"White balls: {whiteBalls}");
Console.WriteLine($"Other colors picked: {otherBalls}");
Console.WriteLine($"Divides from black balls: {divides}");
