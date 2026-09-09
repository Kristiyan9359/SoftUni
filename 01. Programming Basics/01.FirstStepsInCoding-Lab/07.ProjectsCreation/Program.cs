Console.WriteLine();
string architectName = Console.ReadLine();

Console.WriteLine();
int projectCount = int.Parse(Console.ReadLine());


int hoursPerProject = 3;
int totalHours = projectCount * hoursPerProject;

Console.WriteLine($"The architect {architectName} will need {totalHours} hours to complete {projectCount} project/s.");