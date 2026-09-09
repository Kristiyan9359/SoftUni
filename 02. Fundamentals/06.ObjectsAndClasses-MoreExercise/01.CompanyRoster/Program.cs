namespace _01.CompanyRoster;

public class Program
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            return $"Highest Average Salary: {this.Department}" +
                $"{this.Name} {this.Salary}";
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            decimal salary = decimal.Parse(data[1]);
            string department = data[2];

            if (!employees.Any(e => e.Name == name))
            {
                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

        }

        var topDepartment = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(g => g.Average(e => e.Salary))
            .First();

        Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

        foreach (var emp in topDepartment.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:F2}");
        }
    }
}