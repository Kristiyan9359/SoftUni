using _03.Telephony.Contracts;
using _03.Telephony.Models;

namespace _03.Telephony;

public class StartUp
{
    static void Main()
    {
        string[] phoneNumbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        ICallable callable;

        foreach (var number in phoneNumbers)
        {
            if (number.Length == 10)
            {
                callable = new Smartphone();
            }
            else
            {
                callable = new Stationaryphone();
            }
            try
            {
                Console.WriteLine(callable.Call(number));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        IBrowsable browsable = new Smartphone();

        foreach (var url in urls)
        {
            try
            {
                Console.WriteLine(browsable.Browse(url));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
