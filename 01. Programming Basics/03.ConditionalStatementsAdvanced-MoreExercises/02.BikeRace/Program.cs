
int juniorCyclist = int.Parse(Console.ReadLine());
int seniorCyclist = int.Parse(Console.ReadLine());
string roadType = Console.ReadLine();

double tax = 0;
double trailJuniors = 5.50;
double trailSeniors = 7;
double crossCountryJunior = 8;
double crossCountrySeniors = 9.50;
double downhillJuniors = 12.25;
double downhillSeniors = 13.75;
double roadJuniors = 20;
double roadSeniors = 21.50;

int totalCyclists = juniorCyclist + seniorCyclist;

if (roadType == "trail")
{
    tax = (juniorCyclist * trailJuniors) + (seniorCyclist * trailSeniors);
}
else if (roadType == "downhill")
{
    tax = (juniorCyclist * downhillJuniors) + (seniorCyclist * downhillSeniors);
}
else if (roadType == "road")
{
    tax = (juniorCyclist * roadJuniors) + (seniorCyclist * roadSeniors);
}
else if (roadType == "cross-country")
{
    tax = (juniorCyclist * crossCountryJunior) + (seniorCyclist * crossCountrySeniors);


    if (totalCyclists >= 50)
    {
        tax = tax - (tax * 0.25);
    }
}
tax = tax - (tax * 0.05);


Console.WriteLine($"{tax:f2}");