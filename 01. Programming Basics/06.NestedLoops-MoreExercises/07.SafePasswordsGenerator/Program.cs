
int a = int.Parse(Console.ReadLine());           // Максимална стойност за x
int b = int.Parse(Console.ReadLine());           // Максимална стойност за y
int maxPasswords = int.Parse(Console.ReadLine()); // Максимален брой пароли

int generatedPasswords = 0;  // Брояч на генерираните пароли

char symbolA = (char)35; // Начална стойност на A (ASCII 35)
char symbolB = (char)64; // Начална стойност на B (ASCII 64)

for (int x = 1; x <= a; x++)
{
    for (int y = 1; y <= b; y++)
    {
        // Генерираме паролата във формат ABxyBA
        Console.Write($"{symbolA}{symbolB}{x}{y}{symbolB}{symbolA}|");
        generatedPasswords++;

        // Проверка за достигане на максималния брой пароли
        if (generatedPasswords >= maxPasswords)
        {
            return; // Ако сме достигнали лимита, спираме програмата
        }

        // Увеличаваме стойностите на A и B
        symbolA++;
        symbolB++;

        // Проверка за границите на A и B
        if (symbolA > 55) symbolA = (char)35;
        if (symbolB > 96) symbolB = (char)64;
    }
}