using P02_FootballBetting.Data;

namespace P02_FootballBetting;


public class Program
{
    static void Main()
    {
        static void Main(string[] args)
        {
            try
            {
                using FootballBettingContext context = new FootballBettingContext();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Database created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}