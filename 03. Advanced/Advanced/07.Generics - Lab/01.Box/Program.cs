using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Box<int> box = new Box<int>();
        box.Add(1);
        box.Add(2);
        box.Add(3);
        Console.WriteLine(box.Remove(3));
        box.Add(4);
        box.Add(5);
        Console.WriteLine(box.Remove(5));
    }

    public class Box<T>
    {
        private readonly List<T> items;

        public int Count => items.Count;

        public Box()
        {
            this.items = new List<T>();
        }

        public Box(T value) : this()
        {
            items.Add(value);
        }

        public void Add(T value)
        {
            items.Add(value);
        }

        public T Remove(T value)
        {
            int index = items.IndexOf(value);
            if (index < 0) throw new InvalidOperationException("Item not found in box.");
            T removed = items[index];
            items.RemoveAt(index);
            return removed;
        }
    }

}