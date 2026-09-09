
int n = int.Parse(Console.ReadLine());

double totalSales = 0;
double totalRating = 0;

for (int i = 0; i < n; i++)
{
    int salesAndRating = int.Parse(Console.ReadLine()); // Възможни продажби и рейтинг

    int rating = salesAndRating % 10; // Извличане на рейтинга (последната цифра)
    int possibleSales = salesAndRating / 10; // Извличане на възможните продажби (първите цифри)

    // Стъпка 3: Изчисляване на направените продажби на база рейтинг
    double currentSales = 0;
    if (rating == 2)
    {
        currentSales = 0; // 0% от възможните продажби
    }
    else if (rating == 3)
    {
        currentSales = possibleSales * 0.50; // 50% от възможните продажби
    }
    else if (rating == 4)
    {
        currentSales = possibleSales * 0.70; // 70% от възможните продажби
    }
    else if (rating == 5)
    {
        currentSales = possibleSales * 0.85; // 85% от възможните продажби
    }
    else if (rating == 6)
    {
        currentSales = possibleSales * 1.00; // 100% от възможните продажби
    }

    // Добавяне на текущите продажби и рейтинг към общите
    totalSales += currentSales;
    totalRating += rating;
}

// Стъпка 4: Изчисляване на средния рейтинг
double averageRating = totalRating / n;

// Стъпка 5: Отпечатване на резултатите
Console.WriteLine($"{totalSales:F2}");
Console.WriteLine($"{averageRating:F2}");