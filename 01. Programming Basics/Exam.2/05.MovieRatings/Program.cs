
int movieCount = int.Parse(Console.ReadLine());

string highestRatedMovie = string.Empty;
string lowestRatedMovie = string.Empty;
double highestRating = double.MinValue;
double lowestRating = double.MaxValue;
double totalRating = 0;

for (int i = 0; i < movieCount; i++)
{
    string movieName = Console.ReadLine();
    double rating = double.Parse(Console.ReadLine());

    if (rating > highestRating)
    {
        highestRating = rating;
        highestRatedMovie = movieName;
    }

    if (rating < lowestRating)
    {
        lowestRating = rating;
        lowestRatedMovie = movieName;
    }

    totalRating += rating;
}

double averageRating = totalRating / movieCount;

Console.WriteLine($"{highestRatedMovie} is with highest rating: {highestRating:F1}");
Console.WriteLine($"{lowestRatedMovie} is with lowest rating: {lowestRating:F1}");
Console.WriteLine($"Average rating: {averageRating:F1}");