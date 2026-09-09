using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models;

public class Person
{
    public const int MinAge = 12;
    public const int MaxAge = 90;

    public Person(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }

    [MyRequired]
    public string FullName { get; private set; }

    [MyRange(MinAge, MaxAge)]
    public int Age { get; private set; }
}
