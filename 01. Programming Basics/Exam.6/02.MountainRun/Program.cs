
double recordInSeconds = double.Parse(Console.ReadLine());
double distanceInMeters = double.Parse(Console.ReadLine());
double timeInSecFor1Meter = double.Parse(Console.ReadLine());

double calculations = distanceInMeters * timeInSecFor1Meter;
double slowing = Math.Floor(distanceInMeters / 50) * 30;
double totalTime = calculations + slowing;

if (recordInSeconds > totalTime)
{
    Console.WriteLine($" Yes! The new record is {totalTime:F2} seconds.");
}
else
{
    double timeNeed = recordInSeconds - totalTime;
    Console.WriteLine($"No! He was {Math.Abs(timeNeed):F2} seconds slower.");
}