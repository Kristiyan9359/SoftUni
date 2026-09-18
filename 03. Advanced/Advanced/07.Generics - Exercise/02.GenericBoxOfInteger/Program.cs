public class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            int input = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(input);

            Console.WriteLine(box);
        }
    }

    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {value}";
        }
    }
}