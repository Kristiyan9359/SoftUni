internal class Program
{
    class User
    {
        public User(string userName, string licensePlate)
        {
            UserName = userName;
            LicensePlate = licensePlate;
        }

        public string UserName { get; set; }
        public string LicensePlate { get; set; }

        public override string ToString()
        {
            return $"{UserName} => {LicensePlate}";
        }

    }

    static void Main()
    {
        Dictionary<string, User> users = new();

        int usersCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < usersCount; i++)
        {
            string[] arguments = Console.ReadLine().Split();
            string command = arguments[0];
            string userName = arguments[1];

            switch (command)
            {
                case "register":
                    string licensePlate = arguments[2];
                    User user = new User(userName, licensePlate);

                    if (!users.ContainsKey(userName))
                    {

                        users.Add(userName, user);
                        Console.WriteLine($"{userName} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                    break;

                case "unregister":

                    if (users.ContainsKey(userName))
                    {
                        users.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    break;
            }
        }
        foreach (var pair in users)
        {
            Console.WriteLine(pair.Value);
        }
    }
}