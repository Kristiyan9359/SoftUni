
int targetSum = int.Parse(Console.ReadLine()); // Сумата, която трябва да бъде събрана
int collectedSum = 0; // Сума, която е събрана до момента

int cashSum = 0;       // Обща сума, платена в брой
int cashCount = 0;     // Брой плащания в брой
int cardSum = 0;       // Обща сума, платена с карта
int cardCount = 0;     // Брой плащания с карта

bool isCashPayment = true; // Индикатор за редуване на плащанията

string input;

while ((input = Console.ReadLine()) != "End")
{
    int productPrice = int.Parse(input); // Цена на продукта

    if (isCashPayment) // Плащане в брой
    {
        if (productPrice > 100) // Проверка дали не надвишава 100лв
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            cashSum += productPrice;
            cashCount++;
            collectedSum += productPrice;
        }
    }
    else // Плащане с карта
    {
        if (productPrice < 10) // Проверка дали не е под 10лв
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            cardSum += productPrice;
            cardCount++;
            collectedSum += productPrice;
        }
    }

    if (collectedSum >= targetSum) // Ако събраната сума достигне целта
    {
        double avgCash = 0;
        double avgCard = 0;

        if (cashCount > 0)
        {
            avgCash = (double)cashSum / cashCount;
        }

        if (cardCount > 0)
        {
            avgCard = (double)cardSum / cardCount;
        }


        Console.WriteLine($"Average CS: {avgCash:F2}");
        Console.WriteLine($"Average CC: {avgCard:F2}");
        return;
    }

    isCashPayment = !isCashPayment; // Променяме редуването на плащанията
}

// Ако командата "End" е получена преди да съберем целевата сума
Console.WriteLine("Failed to collect required money for charity.");