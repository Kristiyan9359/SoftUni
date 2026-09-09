
int eggs = int.Parse(Console.ReadLine());
string input = Console.ReadLine();

int selledEggs = 0;

while (input != "Close")
{
    string buyOrFill = input;
    int eggsBoughtOrFilled = int.Parse(Console.ReadLine());

    if (buyOrFill == "Buy")
    {
        if (eggs < eggsBoughtOrFilled)
        {

            Console.WriteLine("Not enough eggs in store!");
            Console.WriteLine($"You can buy only {eggs}.");
            break;
        }
        eggs -= eggsBoughtOrFilled;
        selledEggs += eggsBoughtOrFilled;
    }
    else if (buyOrFill == "Fill")
    {
        eggs += eggsBoughtOrFilled;
    }

    input = Console.ReadLine();
}
if (input == "Close")
{
    Console.WriteLine("Store is closed!");
    Console.WriteLine($"{selledEggs} eggs sold.");

}