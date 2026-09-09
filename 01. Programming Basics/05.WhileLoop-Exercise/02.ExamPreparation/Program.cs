
int maxPoorGrades = int.Parse(Console.ReadLine());
string nameOfProblem = Console.ReadLine();
int poorGradesCounter = 0;
int problemsCounter = 0;
int allGrades = 0;
string lastProblem = "";

while (nameOfProblem != "Enough")
{
    problemsCounter++;

    int currentGrade = int.Parse(Console.ReadLine());

    if (currentGrade <= 4)
    {
        poorGradesCounter++;

        if (poorGradesCounter == maxPoorGrades)
        {
            Console.WriteLine($"You need a break, {maxPoorGrades} poor grades.");
            break;
        }
    }
    allGrades += currentGrade;
    lastProblem = nameOfProblem;

    nameOfProblem = Console.ReadLine();
}

if (nameOfProblem == "Enough")
{
    double averageGrade = (double)allGrades / problemsCounter;

    Console.WriteLine($"Average score: {averageGrade:f2}");
    Console.WriteLine($"Number of problems: {problemsCounter}");
    Console.WriteLine($"Last problem: {lastProblem}");
}

