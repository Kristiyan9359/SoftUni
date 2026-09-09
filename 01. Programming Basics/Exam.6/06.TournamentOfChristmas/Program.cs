
int days = int.Parse(Console.ReadLine());

double totalMoneyRaised = 0;
int totalWinDays = 0;
int totalLoseDays = 0;

for (int i = 1; i <= days; i++)
{
    int winCount = 0;
    int loseCount = 0;
    double dailyMoney = 0;

    string input;
    while ((input = Console.ReadLine()) != "Finish")
    {
        string sport = input;
        string result = Console.ReadLine();

        if (result == "win")
        {
            winCount++;
            dailyMoney += 20;
        }
        else if (result == "lose")
        {
            loseCount++;
        }
    }

    if (winCount > loseCount)
    {
        dailyMoney *= 1.10;
        totalWinDays++;
    }
    else
    {
        totalLoseDays++;
    }

    totalMoneyRaised += dailyMoney;
}

if (totalWinDays > totalLoseDays)
{
    totalMoneyRaised *= 1.20;
    Console.WriteLine($"You won the tournament! Total raised money: {totalMoneyRaised:F2}");
}
else
{
    Console.WriteLine($"You lost the tournament! Total raised money: {totalMoneyRaised:F2}");
}