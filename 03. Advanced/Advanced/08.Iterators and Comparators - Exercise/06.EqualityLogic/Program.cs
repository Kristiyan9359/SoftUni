using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedSet<Person> sortedPeople = new SortedSet<Person>();
        HashSet<Person> hashedPeople = new HashSet<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            Person person = new Person(name, age);

            sortedPeople.Add(person);
            hashedPeople.Add(person);
        }

        Console.WriteLine(sortedPeople.Count);
        Console.WriteLine(hashedPeople.Count);
    }
}

public class Person : IComparable<Person>, IEquatable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Person other)
    {
        int result = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);

        if (result != 0)
        {
            return result;
        }

        return Age.CompareTo(other.Age);
    }

    public bool Equals(Person other)
    {
        if (other == null)
        {
            return false;
        }

        return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase)
               && Age == other.Age;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name.ToLowerInvariant(), Age);
    }
}