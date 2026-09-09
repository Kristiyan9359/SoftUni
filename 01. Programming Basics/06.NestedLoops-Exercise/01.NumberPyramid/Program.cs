
int n = int.Parse(Console.ReadLine());

int currentNum = 0;
bool isBigger = false;

for (int row = 1; row <= n; row++)
{
    for (int col = 1; col <= row; col++)
    {
        currentNum++;

        if (currentNum > n)
        {
            isBigger = true;
            break;
        }

        Console.Write(currentNum + " ");
    }

    if (isBigger)
    {
        break;
    }

    Console.WriteLine();
}