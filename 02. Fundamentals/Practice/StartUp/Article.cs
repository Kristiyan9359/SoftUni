namespace Practice;

public class Article
{
    private string title;
    private string content;
    private string author;
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    string Title { get; set; }
    string Content { get; set; }
    string Author { get; set; }

    public void Edit(string newContent)
    {
        Content = newContent;
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public void Rename(string newTitle)
    {
        Title = newTitle;
    }
    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }

}
