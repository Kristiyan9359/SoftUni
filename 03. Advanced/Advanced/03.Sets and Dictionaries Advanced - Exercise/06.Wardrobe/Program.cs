internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, int>> wardrobe = new();



        for (int i = 0; i < n; i++)
        {
            string[] text = Console.ReadLine().Split(" -> ");

            string color = text[0];
            string[] clothes = text[1].Split(",");

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }

            foreach (var item in clothes)
            {
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color][item] = 0;
                }
                wardrobe[color][item]++;
            }
        }
        string[] wish = Console.ReadLine().Split();

        foreach (var (color, clothes) in wardrobe)
        {
            Console.WriteLine($"{color} clothes:");

            foreach (var (item, count) in clothes)
            {
                string found = string.Empty;
                if (color == wish[0] && item == wish[1])
                {
                    found = " (found!)";
                }
                Console.WriteLine($"* {item} - {count}{found}");
            }
        }

    }
}