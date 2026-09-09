internal class Program
{
    static void Main()
    {
        string bigNumber = Console.ReadLine();

        string multiplyNumber = Console.ReadLine();

        string product = Multiply(bigNumber, multiplyNumber);

        Console.WriteLine(product);
    }

    static string Multiply(string bigNumber, string multiplyNumber)
    {
        if (bigNumber == "0" || multiplyNumber == "0")
        {
            return "0";
        }

        int carry = 0;

        int multiplier = int.Parse(multiplyNumber);

        char[] resultCharts = new char[bigNumber.Length + 1];

        for (int i = bigNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(bigNumber[i].ToString());
            int product = digit * multiplier + carry;

            resultCharts[i + 1] = (char)((product % 10) + '0');
            carry = product / 10;
        }

        if (carry > 0)
        {
            resultCharts[0] = (char)(carry + '0');
        }

        return new string(resultCharts).TrimStart('\0');
    }
}