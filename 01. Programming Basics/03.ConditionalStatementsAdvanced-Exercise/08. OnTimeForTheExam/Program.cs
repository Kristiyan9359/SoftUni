
int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());

int examTime = examHour * 60 + examMinute;
int arrivalTime = arrivalHour * 60 + arrivalMinute;

int timeDifference = arrivalTime - examTime;

if (timeDifference > 0)
{
    Console.WriteLine("Late");
    if (timeDifference < 60)
    {
        Console.WriteLine($"{timeDifference} minutes after the start");
    }
    else
    {
        int hours = timeDifference / 60;
        int minutes = timeDifference % 60;
        Console.WriteLine($"{hours}:{minutes:D2} hours after the start");
    }
}
else if (timeDifference >= -30)
{
    Console.WriteLine("On time");
    if (timeDifference < 0)
    {
        Console.WriteLine($"{Math.Abs(timeDifference)} minutes before the start");
    }
}
else
{
    Console.WriteLine("Early");
    int absDifference = Math.Abs(timeDifference);
    if (absDifference < 60)
    {
        Console.WriteLine($"{absDifference} minutes before the start");
    }
    else
    {
        int hours = absDifference / 60;
        int minutes = absDifference % 60;
        Console.WriteLine($"{hours}:{minutes:D2} hours before the start");
    }
}