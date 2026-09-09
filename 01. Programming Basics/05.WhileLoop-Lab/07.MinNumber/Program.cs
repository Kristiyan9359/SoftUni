
string input = Console.ReadLine();

int min = int.MaxValue;

while (input != "Stop")
{
    int num = int.Parse(input);

    if (num < min)
    {
        min = num;
    }
    input = Console.ReadLine();
}
Console.WriteLine(min);