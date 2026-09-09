
int firstNum = int.Parse(Console.ReadLine());
int secondNum = int.Parse(Console.ReadLine());

for (int currentNum = firstNum; currentNum < secondNum; currentNum++)
{
    string currentNumAsString = currentNum.ToString();
    int evenNumSum = 0;
    int oddNumSum = 0;

    for (int digitPosition = 0; digitPosition < currentNumAsString.Length; digitPosition++)
    {
        int currentDigit = int.Parse(currentNumAsString[digitPosition].ToString());

        if (digitPosition % 2 == 0)
        {
            evenNumSum += currentDigit;
        }
        else
        {
            oddNumSum += currentDigit;
        }
    }
    if (evenNumSum == oddNumSum)
    {
        Console.Write(currentNum + " ");
    }
}