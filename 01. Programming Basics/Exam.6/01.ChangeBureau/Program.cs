
int bitcoins = int.Parse(Console.ReadLine());
double chineseYuans = double.Parse(Console.ReadLine());
double commissionPercent = double.Parse(Console.ReadLine());

double bitcoinToLeva = 1168.0;
double yuanToDollar = 0.15;
double dollarToLeva = 1.76;
double levaToEuro = 1.95;

double levaFromBitcoins = bitcoins * bitcoinToLeva;
double levaFromYuans = chineseYuans * yuanToDollar * dollarToLeva;
double totalLeva = levaFromBitcoins + levaFromYuans;

double euros = totalLeva / levaToEuro;

double commission = euros * (commissionPercent / 100);

double finalEuros = euros - commission;

Console.WriteLine($"{finalEuros:F2}");