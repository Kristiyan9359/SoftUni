
int moves = int.Parse(Console.ReadLine());

double score = 0;
double zeroToTen = 0;
double tenToTwenty = 0;
double twentyToThirty = 0;
double thirtyToFourty = 0;
double fourtyToFifty = 0;
double invalidNumbers = 0;

for (int i = 0; i < moves; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (number >= 0 && number <= 9)
    {
        score += number * 0.20;
        zeroToTen++;
    }
    else if (number >= 10 && number <= 19)
    {
        score += number * 0.30;
        tenToTwenty++;
    }
    else if (number >= 20 && number <= 29)
    {
        score += number * 0.40;
        twentyToThirty++;
    }
    else if (number >= 30 && number <= 39)
    {
        score += 50;
        thirtyToFourty++;
    }
    else if (number >= 40 && number <= 50)
    {
        score += 100;
        fourtyToFifty++;
    }
    else
    {
        score /= 2;
        invalidNumbers++;
    }
}

double zeroPercent = (zeroToTen / moves) * 100;
double tenPercent = (tenToTwenty / moves) * 100;
double twentyPercent = (twentyToThirty / moves) * 100;
double thirtyPercent = (thirtyToFourty / moves) * 100;
double fourtyPercent = (fourtyToFifty / moves) * 100;
double invalidPercent = (invalidNumbers / moves) * 100;

Console.WriteLine($"{score:F2}");
Console.WriteLine($"From 0 to 9: {zeroPercent:F2}%");
Console.WriteLine($"From 10 to 19: {tenPercent:F2}%");
Console.WriteLine($"From 20 to 29: {twentyPercent:F2}%");
Console.WriteLine($"From 30 to 39: {thirtyPercent:F2}%");
Console.WriteLine($"From 40 to 50: {fourtyPercent:F2}%");
Console.WriteLine($"Invalid numbers: {invalidPercent:F2}%");