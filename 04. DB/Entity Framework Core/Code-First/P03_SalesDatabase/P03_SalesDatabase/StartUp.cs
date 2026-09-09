namespace P03_SalesDatabase;
public class StartUp
{
    static void Main()
    {
        using var context = new Data.SalesContext();
        context.Database.EnsureCreated();
    }
}