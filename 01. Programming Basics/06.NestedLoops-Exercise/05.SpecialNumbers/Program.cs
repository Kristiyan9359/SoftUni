
int n = int.Parse(Console.ReadLine());

for (int currentNum = 1111; currentNum <= 9999; currentNum++)
{
    bool isSpecial = true;
    string currentNumAsString = currentNum.ToString();

    for (int i = 0; i < currentNumAsString.Length; i++)
    {
        int currentDigit = int.Parse(currentNumAsString[i].ToString());

        if (currentDigit == 0 || n % currentDigit != 0)
        {
            isSpecial = false;
            break;
        }
    }
    if (isSpecial)
    {
        Console.Write(currentNum + " ");
    }
}