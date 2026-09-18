using System.Collections;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        ListyIterator<string> iterator = null;


        while (true)
        {
            string input = Console.ReadLine();

            string[] tokens = input.Split();

            if (tokens[0] == "END") break;

            if (tokens[0] == "Create")
            {
                List<string> collection = new List<string>();

                for (int i = 1; i < tokens.Length; i++)
                {
                    collection.Add(tokens[i]);
                }
                iterator = new ListyIterator<string>(collection);
            }
            else if (tokens[0] == "Move")
            {
                Console.WriteLine(iterator.Move());
            }
            else if (tokens[0] == "Print")
            {
                try
                {
                    iterator.Print();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            else if (tokens[0] == "PrintAll")
            {
                iterator.PrintAll();
            }

            else if (tokens[0] == "HasNext")
            {
                Console.WriteLine(iterator.HasNext());
            }
        }
    }
}


public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> collection;
    private int index = 0;


    public ListyIterator(List<T> collection)
    {
        this.collection = collection;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Move()
    {
        if (index < collection.Count - 1)
        {
            index = index + 1;
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (collection.Count > 0)
        {
            Console.WriteLine(collection[index]);
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public void PrintAll()
    {
        foreach (T item in this)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    public bool HasNext()
    {
        return index < collection.Count - 1;
    }
}