using System.Collections;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Lake<int> lake = new Lake<int>();

        string input = Console.ReadLine();

        string[] tokens = input.Split(", ");


        for (int i = 0; i < tokens.Length; i++)
        {
            int value = int.Parse(tokens[i]);

            lake.Add(value);

        }

        Console.WriteLine(string.Join(", ", lake));
    }
}
public class Lake<T> : IEnumerable<T>
{
    private List<T> collection = new List<T>();

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < collection.Count; i += 2)
        {
            yield return collection[i];
        }

        int start = collection.Count % 2 == 0
            ? collection.Count - 1
            : collection.Count - 2;

        for (int i = start; i >= 1; i -= 2)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        collection.Add(item);
    }
}