namespace _02.OldestFamilyMember;
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
public class Family
{
    public List<Person> People { get; set; } = new List<Person>();

    public void AddMember(Person member)
    {
        People.Add(member);
    }

    public Person GetOldestMember()
    {
        return People.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}
public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string name = data[0];
            int age = int.Parse(data[1]);

            family.AddMember(new Person(name, age));
        }

        Person oldest = family.GetOldestMember();

        if (oldest != null)
        {
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
