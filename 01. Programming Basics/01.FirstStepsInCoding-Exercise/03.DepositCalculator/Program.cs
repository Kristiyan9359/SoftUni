//Input
double deposit = double.Parse(Console.ReadLine());
int monthsTerm = int.Parse(Console.ReadLine());
double yearPercent = double.Parse(Console.ReadLine()) / 100;

//Calculating

double sum = deposit + monthsTerm * ((deposit * yearPercent) / 12);

//Output
Console.WriteLine(sum);