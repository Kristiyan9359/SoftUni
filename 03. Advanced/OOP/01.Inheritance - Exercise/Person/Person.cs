using System;
using System.Text;

namespace InheritanceExcercise;

public class Person
{
    private string name;
    private int age;
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public virtual int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value > 0)
            {
                age = value;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(String.Format("{0} -> ",
            this.GetType().Name));
        sb.Append(String.Format("Name: {0}, Age: {1}",
            this.Name,
            this.Age));

        return sb.ToString();
    }

}