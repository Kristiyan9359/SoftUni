public class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();


        while (true)
        {
            string input = Console.ReadLine();

            string[] tokens = input.Split();

            if (tokens[0] == "END")
                break;

            Person person = new Person(
                tokens[0],
                int.Parse(tokens[1]),
                tokens[2]
                );

            people.Add(person);
        }

        int position = int.Parse(Console.ReadLine());

        Person referencePerson = people[position - 1];

        int matches = 0;
        int notMatches = 0;


        foreach (Person person in people)
        {
            if (person.CompareTo(referencePerson) == 0)
            {
                matches++;
            }
            else
            {
                notMatches++;
            }
        }

        if (matches == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{matches} {notMatches} {people.Count}");
        }

    }

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result != 0)
            {
                return result;
            }

            int age = Age.CompareTo(other.Age);

            if (age != 0)
            {
                return age;
            }

            return City.CompareTo(other.City);
        }
    }
}