
int picsTime = int.Parse(Console.ReadLine());
int scenesCount = int.Parse(Console.ReadLine());
int sceneLenght = int.Parse(Console.ReadLine());

double preparingTime = picsTime * 0.15;
double sceneCapturing = scenesCount * sceneLenght;

double finalTime = preparingTime + sceneCapturing;

if (picsTime >= finalTime)
{
    double leftTime = picsTime - finalTime;
    Console.WriteLine($"You managed to finish the movie on time! You have {leftTime:F0} minutes left!");
}
else
{
    double timeNeed = finalTime - picsTime;
    Console.WriteLine($"Time is up! To complete the movie you need {timeNeed:F0} minutes.");
}