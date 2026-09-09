
string studentName = Console.ReadLine();

int expelsCount = 0;
int yearsCount = 0;
double gradeSum = 0;

while (expelsCount < 2 && yearsCount < 12)
{
    double grade = double.Parse(Console.ReadLine());
    yearsCount++;

    if (grade < 4)
    {

        expelsCount++;

        continue;
    }
    else
    {
        gradeSum += grade;
    }
}

if (expelsCount < 2)
{
    double averageGrade = gradeSum / yearsCount;
    Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:F2}");
}
else
{
    Console.WriteLine($"{studentName} has been excluded at {yearsCount - 1} grade");
}