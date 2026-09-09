
int studentsCount = int.Parse(Console.ReadLine());

double totalScore = 0;
double topStudents = 0;
double goodStudents = 0;
double averageStudents = 0;
double weakStudents = 0;

for (int i = 0; i < studentsCount; i++)
{
    double scores = double.Parse(Console.ReadLine());

    if (scores >= 5.00)
    {
        topStudents++;
        totalScore += scores;
    }
    else if (scores >= 4.00 && scores <= 4.99)
    {
        goodStudents++;
        totalScore += scores;
    }
    else if (scores >= 3.00 && scores <= 3.99)
    {
        averageStudents++;
        totalScore += scores;
    }
    else if (scores >= 2.00 && scores <= 2.99)
    {
        weakStudents++;
        totalScore += scores;
    }

}

double topPercent = (topStudents / studentsCount) * 100;
double goodPercent = (goodStudents / studentsCount) * 100;
double averagePercent = (averageStudents / studentsCount) * 100;
double weakPercent = (weakStudents / studentsCount) * 100;

double averageScore = totalScore / studentsCount;

Console.WriteLine($"Top students: {topPercent:F2}%");
Console.WriteLine($"Between 4.00 and 4.99: {goodPercent:F2}%");
Console.WriteLine($"Between 3.00 and 3.99: {averagePercent:F2}%");
Console.WriteLine($"Fail: {weakPercent:F2}%");
Console.WriteLine($"Average: {averageScore:f2}");