
int daysOffs = int.Parse(Console.ReadLine());

int workDays = 365 - daysOffs;

int playTime = (workDays * 63) + (daysOffs * 127);

int sleepingNorm = 30000;


int difference = playTime - sleepingNorm;


if (difference > 0)
{
    int hours = difference / 60;
    int minutes = difference % 60;
    Console.WriteLine("Tom will run away");
    Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
}
else
{
    int hours = Math.Abs(difference / 60);
    int minutes = Math.Abs(difference % 60);
    Console.WriteLine($"Tom sleeps well");
    Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
}