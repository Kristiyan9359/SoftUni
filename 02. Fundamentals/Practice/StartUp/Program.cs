using Practice;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main()
    {
        string[] tokens = Console.ReadLine().Split(',');
        string title = tokens[0];
        string content = tokens[1];
        string author = tokens[2];

        Article article = new Article(title, content, author);

        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string[] text = Console.ReadLine().Split(":");

            string command = text[0];

            switch (command)
            {
                case "Edit":
                    string newContent = text[1];
                    article.Edit(newContent);
                    break;
                case "ChangeAuthor":
                    string newAuthor = text[1];
                    article.ChangeAuthor(newAuthor);
                    break;
                case "Rename":
                    string newTitle = text[1];
                    article.Rename(newTitle);
                    break;
            }
        }
        Console.WriteLine(article.ToString());
    }
}