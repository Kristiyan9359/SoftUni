
int totalEggs = int.Parse(Console.ReadLine());

int redEggs = 0;
int orangeEggs = 0;
int blueEggs = 0;
int greenEggs = 0;

string maxColor = "";
int maxEggs = 0;

for (int i = 0; i < totalEggs; i++)
{
    string color = Console.ReadLine();

    switch (color)
    {
        case "red":
            redEggs++;
            break;
        case "orange":
            orangeEggs++;
            break;
        case "blue":
            blueEggs++;
            break;
        case "green":
            greenEggs++;
            break;
    }
}

if (redEggs > maxEggs)
{
    maxEggs = redEggs;
    maxColor = "red";
}
if (orangeEggs > maxEggs)
{
    maxEggs = orangeEggs;
    maxColor = "orange";
}
if (blueEggs > maxEggs)
{
    maxEggs = blueEggs;
    maxColor = "blue";
}
if (greenEggs > maxEggs)
{
    maxEggs = greenEggs;
    maxColor = "green";
}

Console.WriteLine($"Red eggs: {redEggs}");
Console.WriteLine($"Orange eggs: {orangeEggs}");
Console.WriteLine($"Blue eggs: {blueEggs}");
Console.WriteLine($"Green eggs: {greenEggs}");
Console.WriteLine($"Max eggs: {maxEggs} -> {maxColor}");