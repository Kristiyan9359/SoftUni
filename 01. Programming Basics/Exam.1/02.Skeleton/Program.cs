
int controlMinutes = int.Parse(Console.ReadLine());
int controlSeconds = int.Parse(Console.ReadLine());
double trackLength = double.Parse(Console.ReadLine());
int time100Meters = int.Parse(Console.ReadLine());

int controlTimeInSeconds = controlMinutes * 60 + controlSeconds;

double timeDecrease = (trackLength / 120.0) * 2.5;
double marinTime = (trackLength / 100.0) * time100Meters - timeDecrease;

if (marinTime <= controlTimeInSeconds)
{
    Console.WriteLine("Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {marinTime:F3}.");
}
else
{
    double timeDifference = marinTime - controlTimeInSeconds;
    Console.WriteLine($"No, Marin failed! He was {timeDifference:F3} second slower.");
}