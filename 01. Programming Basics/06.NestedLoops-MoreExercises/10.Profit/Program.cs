
int oneCount = int.Parse(Console.ReadLine());
int twoCount = int.Parse(Console.ReadLine());
int fivesCount = int.Parse(Console.ReadLine());
int targetSum = int.Parse(Console.ReadLine());

for (int ones = 0; ones <= oneCount; ones++)
{
    for (int twos = 0; twos <= twoCount; twos++)
    {
        for (int fives = 0; fives <= fivesCount; fives++)
        {
            int currentSum = ones * 1 + twos * 2 + fives * 5;

            if (currentSum == targetSum)
            {
                Console.WriteLine($"{ones} * 1 lv. + {twos} * 2 lv. + {fives} * 5 lv. = {targetSum} lv.");
            }


        }
    }
}