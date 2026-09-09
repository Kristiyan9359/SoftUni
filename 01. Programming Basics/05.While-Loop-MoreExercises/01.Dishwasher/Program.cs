

int bottles = int.Parse(Console.ReadLine());
int detergent = bottles * 750;

int washedDishes = 0;
int washedPots = 0;

int counter = 0;

string input;

while ((input = Console.ReadLine()) != "End")
{
    int items = int.Parse(input);
    counter++;

    if (counter % 3 == 0)
    {
        int neededDetergent = items * 15;

        if (detergent >= neededDetergent)
        {
            detergent -= neededDetergent;
            washedPots += items;
        }
        else
        {
            Console.WriteLine($"Not enough detergent, {neededDetergent - detergent} ml. more necessary!");
            return;
        }
    }
    else
    {
        int neededDetergent = items * 5;

        if (detergent >= neededDetergent)
        {
            detergent -= neededDetergent;
            washedDishes += items;
        }
        else
        {
            Console.WriteLine($"Not enough detergent, {neededDetergent - detergent} ml. more necessary!");
            return;
        }
    }
}

Console.WriteLine("Detergent was enough!");
Console.WriteLine($"{washedDishes} dishes and {washedPots} pots were washed.");
Console.WriteLine($"Leftover detergent {detergent} ml.");
