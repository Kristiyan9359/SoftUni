int num = int.Parse(Console.ReadLine());

bool isInRange = num >= -100 && num <= 100 && num != 0;

if (isInRange)
{
    Console.WriteLine("Yes");
}
else
    Console.WriteLine("No");