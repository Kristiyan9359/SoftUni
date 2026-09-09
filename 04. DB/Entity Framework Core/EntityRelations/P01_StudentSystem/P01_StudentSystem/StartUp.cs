namespace P01_StudentSystem;

public class StartUp
{
    static void Main()
    {
        using var context = new Data.StudentSystemContext();
        context.Database.EnsureCreated();
    }
}