
int poolVolume = int.Parse(Console.ReadLine());
int firstPipeDebit = int.Parse(Console.ReadLine());
int secondPipeDebit = int.Parse(Console.ReadLine());
double workerMissingTime = double.Parse(Console.ReadLine());

double waterFromPipe1 = firstPipeDebit * workerMissingTime;
double waterFromPipe2 = secondPipeDebit * workerMissingTime;
double totalWater = waterFromPipe1 + waterFromPipe2;

if (totalWater <= poolVolume)
{
    double filledPercent = (totalWater / poolVolume) * 100;
    double pipe1Percent = (waterFromPipe1 / totalWater) * 100;
    double pipe2Percent = (waterFromPipe2 / totalWater) * 100;
    Console.WriteLine($"The pool is {filledPercent:f2}% full. Pipe 1: {pipe1Percent:f2}%. Pipe 2: {pipe2Percent:f2}%.");
}

else
{
    double overflow = totalWater - poolVolume;
    Console.WriteLine($"For {workerMissingTime:f2} hours the pool overflows with {overflow:f2} liters.");
}