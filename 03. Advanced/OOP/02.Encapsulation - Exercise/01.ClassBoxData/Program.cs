namespace _01.ClassBoxData;

public class Program
{
    static void Main()
    {
        try
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new(length, width, height);

            Console.WriteLine(box);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}