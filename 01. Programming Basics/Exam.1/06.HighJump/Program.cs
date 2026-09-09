
int targetHeight = int.Parse(Console.ReadLine());
int currentHeight = targetHeight - 30;
int totalJumps = 0;
int failedAttempts = 0;

while (true)
{
    int jumpHeight = int.Parse(Console.ReadLine());
    totalJumps++;

    if (jumpHeight > currentHeight)
    {
        failedAttempts = 0;
        if (currentHeight >= targetHeight)
        {
            Console.WriteLine($"Tihomir succeeded, he jumped over {currentHeight}cm after {totalJumps} jumps.");
            break;
        }
        currentHeight += 5;
    }
    else
    {
        failedAttempts++;
        if (failedAttempts == 3)
        {
            Console.WriteLine($"Tihomir failed at {currentHeight}cm after {totalJumps} jumps.");
            break;
        }
    }
}
