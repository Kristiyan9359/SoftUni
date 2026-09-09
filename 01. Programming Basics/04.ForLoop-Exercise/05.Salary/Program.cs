
int tabsOpened = int.Parse(Console.ReadLine());
int salary = int.Parse(Console.ReadLine());

for (int i = 1; i <= tabsOpened; i++)
{
    string currentSite = Console.ReadLine();
    
    if (currentSite == "Facebook")
    {
        salary -= 150;
    }
    else if (currentSite == "Instagram")
    {
        salary -= 100;
    }
    else if (currentSite == "Reddit")
    {
        salary -= 50;
    }
    if (salary <= 0)
    {
        Console.WriteLine("You have lost your salary.");
        break;
    }
}

if (salary > 0)
{
    Console.WriteLine(salary);
}