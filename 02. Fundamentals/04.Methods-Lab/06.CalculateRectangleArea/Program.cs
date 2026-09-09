internal class Program
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double area = GetRectangleArea(width, height);
        Console.WriteLine(area);
    }

    private static double GetRectangleArea(double width, double height)
    {
        return width * height;
    }
}