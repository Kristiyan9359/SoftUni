
int juryCount = int.Parse(Console.ReadLine());

int presentationCount = 0;
double allGradesSum = 0;
double currentGradeSum = 0;
string presentationName = "";

while ((presentationName = Console.ReadLine()) != "Finish")
{
    presentationCount++;

    for (int i = 1; i <= juryCount; i++)
    {
        double grade = double.Parse(Console.ReadLine());
        currentGradeSum += grade;
        allGradesSum += grade;
    }
    double averageGrade = currentGradeSum / juryCount;
    currentGradeSum = 0;

    Console.WriteLine($"{presentationName} - {averageGrade:F2}.");
}

double averageGradeAll = allGradesSum / (presentationCount * juryCount);
Console.WriteLine($"Student's final assessment is {averageGradeAll:F2}.");