
int capacity = int.Parse(Console.ReadLine());
string input;
int totalPeople = 0;
int totalIncome = 0;
int ticketPrice = 5;

while ((input = Console.ReadLine()) != "Movie time!")
{
    int peopleEntering = int.Parse(input);

    if (totalPeople + peopleEntering > capacity)
    {
        Console.WriteLine("The cinema is full.");
        Console.WriteLine($"Cinema income - {totalIncome} lv.");
        return;
    }

    totalPeople += peopleEntering;

    int currentIncome = peopleEntering * ticketPrice;

    if (peopleEntering % 3 == 0)
    {
        currentIncome -= 5;
    }

    totalIncome += currentIncome;

}

int seatsLeft = capacity - totalPeople;
Console.WriteLine($"There are {seatsLeft} seats left in the cinema.");
Console.WriteLine($"Cinema income - {totalIncome} lv.");
