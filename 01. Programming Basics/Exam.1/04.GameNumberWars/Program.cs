
string playerOne = Console.ReadLine();
string playerTwo = Console.ReadLine();

int pointsPlayerOne = 0;
int pointsPlayerTwo = 0;

while (true)
{
    string input = Console.ReadLine();
    if (input == "End of game")
    {
        Console.WriteLine($"{playerOne} has {pointsPlayerOne} points");
        Console.WriteLine($"{playerTwo} has {pointsPlayerTwo} points");
        break;
    }

    int cardPlayerOne = int.Parse(input);
    int cardPlayerTwo = int.Parse(Console.ReadLine());

    if (cardPlayerOne > cardPlayerTwo)
    {
        pointsPlayerOne += cardPlayerOne - cardPlayerTwo;
    }
    else if (cardPlayerTwo > cardPlayerOne)
    {
        pointsPlayerTwo += cardPlayerTwo - cardPlayerOne;
    }
    else
    {
        Console.WriteLine("Number wars!");
        cardPlayerOne = int.Parse(Console.ReadLine());
        cardPlayerTwo = int.Parse(Console.ReadLine());

        if (cardPlayerOne > cardPlayerTwo)
        {
            Console.WriteLine($"{playerOne} is winner with {pointsPlayerOne} points");
        }
        else
        {
            Console.WriteLine($"{playerTwo} is winner with {pointsPlayerTwo} points");
        }
        break;
    }
}