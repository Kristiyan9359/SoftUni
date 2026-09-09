internal class Program
{
    static void Main()
    {
        List<Student> students = new();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] tokens = command.Split();

            string firstName = tokens[0];
            string lastName = tokens[1];
            int age = int.Parse(tokens[2]);
            string city = tokens[3];

            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                City = city
            };

            students.Add(student);
        }
        string cityName = Console.ReadLine();

        foreach (Student student in students)
        {
            if (student.City == cityName)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
