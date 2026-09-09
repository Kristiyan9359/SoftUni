
string city = Console.ReadLine();
double sales = double.Parse(Console.ReadLine());

double comission = 0;

if (city == "Sofia")
{
    if (sales < 0) Console.WriteLine("error");
   else if (sales >= 0 && sales <= 500)
        comission = 5;
    else if (sales > 500 &&  sales <= 1000)
        comission = 7;
    else if (sales > 1000 && sales <= 10000)
        comission = 8;
    else if (sales > 10000)
        comission = 12;
}

else if (city == "Varna")
{
    if (sales < 0) Console.WriteLine("error");
    else if (sales >= 0 && sales <= 500)
        comission = 4.5;
    else if (sales > 500 && sales <= 1000)
        comission = 7.5;
    else if (sales > 1000 && sales <= 10000)
        comission = 10;
    else if (sales > 10000)
        comission = 13;
}

else if (city == "Plovdiv")
{
    if (sales < 0) Console.WriteLine("error");
    else if (sales >= 0 && sales <= 500)
        comission = 5.5;
    else if (sales > 500 && sales <= 1000)
        comission = 8;
    else if (sales > 1000 && sales <= 10000)
        comission = 12;
    else if (sales > 10000)
        comission = 14.5;
}

else
{
    Console.WriteLine("error");
}

if (comission > 0)
{
    double output = comission * sales / 100;

    Console.WriteLine($"{output:f2}");
}