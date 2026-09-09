class Student
{
    public Student(string name)
    {
        Grades = new List<decimal>();
        Name = name;
    }

    public string Name { get; set; }

    public List<decimal> Grades { get; set; }

    public override string ToString()
    {

        return $"{Name} -> {Grades.Average():F2}";
    }
}

internal class Program
{
    static void Main()
    {
        Dictionary<string, Student> students = new Dictionary<string, Student>();

        int strudentsCount = int.Parse(Console.ReadLine());


        for (int i = 0; i < strudentsCount; i++)
        {
            string studentName = Console.ReadLine();
            decimal grade = decimal.Parse(Console.ReadLine());

            if (!students.ContainsKey(studentName))
            {
                students.Add(studentName, new Student(studentName));
            }

            students[studentName].Grades.Add(grade);
        }

        var filteredStudents = students.Where(g => g.Value.Grades.Average() >= 4.50m);

        foreach (var pair in filteredStudents)
        {
            Console.WriteLine($"{pair.Value}");
        }
    }
}