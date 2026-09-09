
int magnoliiCount = int.Parse(Console.ReadLine());
int zumbulCount = int.Parse(Console.ReadLine());
int rosesCount = int.Parse(Console.ReadLine());
int cactusCount = int.Parse(Console.ReadLine());
double giftPrice = double.Parse(Console.ReadLine());

double magnoliiPrice = 3.25;
double zumbulPrice = 4;
double rosesPrice = 3.50;
double cactusPrice = 8;
//double taxFee = 0.05;

double totalPrice = (magnoliiCount * magnoliiPrice) + (zumbulCount * zumbulPrice) + (rosesCount * rosesPrice) + (cactusCount * cactusPrice);
double totalPriceWithTax = totalPrice * 0.95;

if (totalPriceWithTax >= giftPrice)
{
    double leftMoney = Math.Floor(totalPriceWithTax - giftPrice);
    Console.WriteLine($"She is left with {Math.Abs(leftMoney)} leva.");
}
else if (giftPrice >= totalPriceWithTax)
{
    double moneyNeed = Math.Ceiling(giftPrice - totalPriceWithTax);
    Console.WriteLine($"She will have to borrow {Math.Abs(moneyNeed)} leva.");
}