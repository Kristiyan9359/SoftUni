
int totalTickets = 0;
int studentTickets = 0;
int standardTickets = 0;
int kidTickets = 0;

string movieName = Console.ReadLine();

while (movieName != "Finish")
{
    int freeSeats = int.Parse(Console.ReadLine());
    int ticketsSoldForMovie = 0;

    for (int i = 0; i < freeSeats; i++)
    {
        string ticketType = Console.ReadLine();

        if (ticketType == "End")
        {
            break;
        }

        ticketsSoldForMovie++;
        totalTickets++;

        if (ticketType == "student")
        {
            studentTickets++;
        }
        else if (ticketType == "standard")
        {
            standardTickets++;
        }
        else if (ticketType == "kid")
        {
            kidTickets++;
        }
    }

    double fullnessPercentage = (ticketsSoldForMovie / (double)freeSeats) * 100;
    Console.WriteLine($"{movieName} - {fullnessPercentage:F2}% full.");

    movieName = Console.ReadLine();
}

Console.WriteLine($"Total tickets: {totalTickets}");
Console.WriteLine($"{(studentTickets / (double)totalTickets) * 100:F2}% student tickets.");
Console.WriteLine($"{(standardTickets / (double)totalTickets) * 100:F2}% standard tickets.");
Console.WriteLine($"{(kidTickets / (double)totalTickets) * 100:F2}% kids tickets.");