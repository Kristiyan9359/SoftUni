namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        private static char[] replaceableSymbols = "-,.!?".ToCharArray();

        public static string ProcessLines(string inputFilePath)
        {
            using FileStream fileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new StreamReader(fileStream);

            StringBuilder resultBuilder = new StringBuilder();

            bool shouldBeIncluded = true;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (shouldBeIncluded)
                {
                    foreach (char replaceableSymbol in replaceableSymbols)
                        line = line.Replace(replaceableSymbol, '@');

                    string[] words = line.Split(' ');
                    Array.Reverse(words);

                    resultBuilder.AppendLine(string.Join(' ', words));
                }

                shouldBeIncluded = !shouldBeIncluded;
            }

            return resultBuilder.ToString();
        }
    }
}
