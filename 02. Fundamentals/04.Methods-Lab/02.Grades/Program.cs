class Program
{
    static void Main()
    {

        double grade = double.Parse(Console.ReadLine());

        PrintGrade(grade);
    }

    static void PrintGrade(double number)
    {
        if (number is >= 2 and <= 2.99)
        {
            Console.WriteLine("Fail");
        }
        else if (number is >= 3 and <= 3.49)
        {
            Console.WriteLine("Poor");
        }
        else if (number is >= 3.50 and <= 4.49)
        {
            Console.WriteLine("Good");
        }
        else if (number is >= 4.50 and <= 5.49)
        {
            Console.WriteLine("Very good");
        }
        else if (number is >= 5.50)
        {
            Console.WriteLine("Excellent");
        }
    }


}