internal class Program
{
    class Product
    {
        string Name { get; }
        decimal Price { get; set; }
        decimal Quantity { get; set; }

        public Product(string name, decimal price, decimal quantity)
        {
            Name = name;

            Price = price;

            Quantity = quantity;
        }
        public void Update(decimal price, decimal quantity)
        {
            Price = price;

            Quantity += quantity;
        }

        public decimal TotalPrice => Price * Quantity;
        public override string ToString()
        {
            return $"{Name} -> {TotalPrice:F2}";
        }
    }

    static void Main()
    {
        Dictionary<string, Product> products = new();

        string command;
        while ((command = Console.ReadLine()) != "buy")
        {
            string[] arguments = command.Split();

            string name = arguments[0];
            decimal price = decimal.Parse(arguments[1]);
            decimal quantity = decimal.Parse(arguments[2]);

            Product product = new Product(name, price, quantity);

            if (!products.ContainsKey(name))
            {
                products.Add(name, product);
            }
            else
            {
                products[name].Update(price, quantity);
            }
        }

        foreach (var pair in products)
        {
            Console.WriteLine(pair.Value);
        }
    }
}