
double x = double.Parse(Console.ReadLine());
double y = double.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());

double window = 2.25;
double entrance = 2.4;

double greenPaintLt = (x * y * 2 - window * 2) + (x * x * 2 - entrance);
greenPaintLt = greenPaintLt / 3.4;

double redPaintLt = 2 * (x * y) + 2 * (x * h / 2);
redPaintLt = redPaintLt / 4.3;

Console.WriteLine($"{greenPaintLt:f2}");
Console.WriteLine($"{redPaintLt:f2}");