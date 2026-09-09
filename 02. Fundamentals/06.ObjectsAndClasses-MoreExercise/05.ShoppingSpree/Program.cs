namespace _05.ShoppingSpree;

public class Person
{
    public string Name { get; set; }
    public double Money { get; set; }
    public List<Product> Bag { get; set; }

    public Person(string name, double money)
    {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public bool BuyProduct(Product product)
    {
        if (Money >= product.Cost)
        {
            Money -= product.Cost;
            Bag.Add(product);
            return true;
        }
        return false;
    }
}

public class Product
{
    public string ProductName { get; set; }
    public double Cost { get; set; }

    public Product(string productName, double cost)
    {
        ProductName = productName;
        Cost = cost;
    }
}

public class Program
{
    static void Main()
    {
        var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        var productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, Person> people = new();
        Dictionary<string, Product> products = new();

        foreach (var personInfo in peopleInput)
        {
            var tokens = personInfo.Split('=');
            string name = tokens[0];
            double money = double.Parse(tokens[1]);
            people[name] = new Person(name, money);
        }

        foreach (var productInfo in productInput)
        {
            var tokens = productInfo.Split('=');
            string productName = tokens[0];
            double cost = double.Parse(tokens[1]);
            products[productName] = new Product(productName, cost);
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split(' ');
            string personName = tokens[0];
            string productName = tokens[1];

            Person person = people[personName];
            Product product = products[productName];

            if (person.BuyProduct(product))
            {
                Console.WriteLine($"{personName} bought {productName}");
            }
            else
            {
                Console.WriteLine($"{personName} can't afford {productName}");
            }
        }

        foreach (var person in people.Values)
        {
            string boughtProducts = person.Bag.Count > 0
                ? string.Join(", ", person.Bag.Select(p => p.ProductName))
                : "Nothing bought";

            Console.WriteLine($"{person.Name} - {boughtProducts}");
        }
    }
}
