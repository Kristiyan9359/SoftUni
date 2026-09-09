class Program
{
    static void Main()
    {

        double people = double.Parse(Console.ReadLine());
        double capacity = double.Parse(Console.ReadLine());

        double totalCourses = Math.Ceiling(people / capacity);

        Console.WriteLine(totalCourses);

    }
}