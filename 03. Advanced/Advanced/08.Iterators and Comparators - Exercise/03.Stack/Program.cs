using System.Collections;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        while (true)
        {

            string input = Console.ReadLine();

            string[] tokens = input.Split();

            if (tokens[0] == "END")
            {
                foreach (int item in stack)
                {
                    Console.WriteLine(item);
                }

                foreach (int item in stack)
                {
                    Console.WriteLine(item);
                }

                break;
            }

            if (tokens[0] == "Push")
            {
                string[] numbers = input.Substring(5).Split(',');

                foreach (string number in numbers)
                {
                    int value = int.Parse(number.Trim());
                    stack.Push(value);
                }
            }

            else if (tokens[0] == "Pop")
            {
                try
                {
                    stack.Pop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection = new List<T>();


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            collection.Add(item);
        }

        public T Pop()
        {
            if (collection.Count > 0)
            {
                T lastElement = collection[collection.Count - 1];
                collection.RemoveAt(collection.Count - 1);
                return lastElement;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }
    }
}