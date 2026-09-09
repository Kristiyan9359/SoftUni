
string bestMovie = "";
int highestPoints = int.MinValue;
int movieCount = 0;

while (movieCount < 7)
{
    string movieTitle = Console.ReadLine();

    if (movieTitle == "STOP")
    {
        break;
    }

    movieCount++;

    int moviePoints = 0;

    for (int i = 0; i < movieTitle.Length; i++)
    {
        char currentChar = movieTitle[i];
        moviePoints += currentChar;

        if (char.IsLower(currentChar))
        {
            moviePoints -= 2 * movieTitle.Length;
        }
        else if (char.IsUpper(currentChar))
        {
            moviePoints -= movieTitle.Length;
        }
    }

    if (moviePoints > highestPoints)
    {
        highestPoints = moviePoints;
        bestMovie = movieTitle;
    }
}

if (movieCount == 7)
{
    Console.WriteLine("The limit is reached.");
}

Console.WriteLine($"The best movie for you is {bestMovie} with {highestPoints} ASCII sum.");