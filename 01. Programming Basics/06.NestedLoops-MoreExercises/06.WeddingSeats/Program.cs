
char lastSector = char.Parse(Console.ReadLine());
int rowsInFirstSector = int.Parse(Console.ReadLine());
int seatsOddRow = int.Parse(Console.ReadLine());

int totalSeats = 0;

for (char sector = 'A'; sector <= lastSector; sector++)
{
    int rowsInCurrentSector = rowsInFirstSector + (sector - 'A');

    for (int row = 1; row <= rowsInCurrentSector; row++)
    {
        int seatsInRow;

        if (row % 2 != 0)
        {
            seatsInRow = seatsOddRow;
        }
        else
        {
            seatsInRow = seatsOddRow + 2;
        }

        for (char seat = 'a'; seat < 'a' + seatsInRow; seat++)
        {
            Console.WriteLine($"{sector}{row}{seat}");
            totalSeats++;
        }
    }
}

Console.WriteLine(totalSeats);