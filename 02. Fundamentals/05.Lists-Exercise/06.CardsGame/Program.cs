internal class Program
{
    static void Main()
    {
        List<int> playerOneCards = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> playerTwoCards = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        while (playerOneCards.Count > 0 && playerTwoCards.Count > 0)
        {
            int cardOne = playerOneCards[0];
            int cardTwo = playerTwoCards[0];

            playerOneCards.RemoveAt(0);
            playerTwoCards.RemoveAt(0);

            if (cardOne > cardTwo)
            {
                playerOneCards.Add(cardOne);
                playerOneCards.Add(cardTwo);
            }
            else if (cardTwo > cardOne)
            {
                playerTwoCards.Add(cardTwo);
                playerTwoCards.Add(cardOne);
            }
        }

        if (playerOneCards.Count > 0)
        {
            Console.WriteLine($"First player wins! Sum: {playerOneCards.Sum()}");
        }
        else
        {
            Console.WriteLine($"Second player wins! Sum: {playerTwoCards.Sum()}");
        }
    }
}