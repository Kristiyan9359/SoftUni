string dayOFWeek = Console.ReadLine();

if (dayOFWeek == "Monday" || dayOFWeek == "Tuesday" || dayOFWeek == "Friday")
{
    Console.WriteLine("12");
}

else if (dayOFWeek == "Wednesday" || dayOFWeek == "Thursday") 
{
    Console.WriteLine("14");
}

else if (dayOFWeek == "Saturday" ||  dayOFWeek == "Sunday")
{
    Console.WriteLine("16");
}

