internal class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        int studentsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentsCount; i++)
        {
            string[] studentsNames = Console.ReadLine().Split();

            Student student = new Student(studentsNames[0],
                studentsNames[1],
                double.Parse(studentsNames[2]));

            students.Add(student);
        }

        students = students.OrderByDescending(x => x.Grade).ToList();

        Console.WriteLine(string.Join("\n", students));

    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}