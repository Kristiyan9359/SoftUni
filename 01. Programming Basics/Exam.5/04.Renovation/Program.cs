
int height = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int percent = int.Parse(Console.ReadLine());

int walls = height * width * 4;
walls = (int)Math.Ceiling(walls - (walls / 100.0 * percent));

string command = Console.ReadLine();

while (command != "Tired!")
{
    walls -= int.Parse(command);
    if (walls <= 0) { break; }
    command = Console.ReadLine();
}

if (walls > 0)
{
    Console.WriteLine($"{walls} quadratic m left.");
}
else if (walls == 0)
{
    Console.WriteLine("All walls are painted! Great job, Pesho!");
}
else
{
    Console.WriteLine($"All walls are painted and you have {Math.Abs(walls)} l paint left!");
}