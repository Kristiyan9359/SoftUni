
string mostPowerfulWord = string.Empty;
int maxPower = int.MinValue;

while (true)
{
    string word = Console.ReadLine();
    if (word == "End of words")
    {
        break;
    }

    int wordPower = 0;

    foreach (char c in word)
    {
        wordPower += c;
    }

    char firstLetter = char.ToLower(word[0]);
    bool isVowel = firstLetter == 'a' || firstLetter == 'e' || firstLetter == 'i' || firstLetter == 'o' || firstLetter == 'u' || firstLetter == 'y';

    if (isVowel)
    {
        wordPower *= word.Length;
    }
    else
    {
        wordPower /= word.Length;
    }

    if (wordPower > maxPower)
    {
        maxPower = wordPower;
        mostPowerfulWord = word;
    }
}

Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxPower}");