namespace P01_HospitalDatabase;
using P01_HospitalDatabase.Data;
public class StartUp
{
    static void Main()
    {
        using var context = new HospitalContext();
        context.Database.EnsureCreated();
    }
}