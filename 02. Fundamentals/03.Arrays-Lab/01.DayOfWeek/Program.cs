class Program
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());

        string[] days =
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };
        if (day <= 7 && day >= 1)
        {
            int index = day - 1;
            Console.WriteLine(days[index]);
        }
        else
        {
            Console.WriteLine("Invalid day!");
        }
    }
}