namespace BookShop;

using BookShop.Models.Enums;
using Data;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);
    }


    //Problem 02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        StringBuilder sb = new StringBuilder();
        var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
        var books = context.Books
            .Where(b => b.AgeRestriction == ageRestriction)
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToList();
        foreach (var book in books)
        {
            sb.AppendLine(book);
        }
        return sb.ToString().TrimEnd();
    }


    //Problem 03
    public static string GetGoldenBooks(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine(book);
        }
        return sb.ToString().TrimEnd();
    }


    //Problem 04

    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.Price > 40)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .OrderByDescending(b => b.Price)
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:F2}");
        }
        return sb.ToString().TrimEnd();
    }


    //Problem 05

    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        StringBuilder sb = new StringBuilder();
        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();
        foreach (var book in books)
        {
            sb.AppendLine(book);
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 06

    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();
        var categories = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();
        var books = context.Books
            .Where(b => b.BookCategories
                .Any(bc => categories
                    .Contains(bc.Category.Name.ToLower())))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();
        foreach (var book in books)
        {
            sb.AppendLine(book);
        }
        return sb.ToString().TrimEnd();
    }


    //Problem 07

    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
        }
        return sb.ToString().TrimEnd();
    }


    //Problem 08

    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();

        var authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName
            })
            .OrderBy(a => a.FullName)
            .ToList();

        foreach (var author in authors)
        {
            sb.AppendLine(author.FullName);
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 09

    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine(book);
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 10

    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .Select(b => new
            {
                b.Title,
                AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                b.BookId
            })
            .OrderBy(b => b.BookId)
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} ({book.AuthorName})");
        }
        return sb.ToString().TrimEnd();
    }



    // Problem 11

    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        var books = context.Books
            .Where(b => b.Title.Length > lengthCheck)
            .Select(b => b.Title)
            .ToList();

        var count = 0;

        foreach (var book in books)
        {
            count++;
        }
        return count;
    }



    // Problem 12

    public static string CountCopiesByAuthor(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var bookCopies = context.Authors
              .Select(a => new
              {
                  a.FirstName,
                  a.LastName,
                  TotalCopies = a.Books.Sum(b => b.Copies)
              })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

        foreach (var author in bookCopies)
        {
            sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 13

    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var categories = context.Categories
            .Select(c => new
            {
                c.Name,
                TotalProfit = c.CategoryBooks
                .Sum(cb => cb.Book.Copies * cb.Book.Price)
            })
            .OrderByDescending(c => c.TotalProfit)
            .ThenBy(c => c.Name)
            .ToList();

        foreach (var category in categories)
        {
            sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 14

    public static string GetMostRecentBooks(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var categories = context.Categories
            .Select(c => new
            {
                c.Name,
                RecentBooks = c.CategoryBooks
                .Select(cb => cb.Book)
                .OrderByDescending(b => b.ReleaseDate)
                .Take(3)
                .ToList()
            })
            .OrderBy(c => c.Name)
            .ToList();

        foreach (var category in categories)
        {
            sb.AppendLine($"--{category.Name}");
            foreach (var book in category.RecentBooks)
            {
                sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
            }
        }
        return sb.ToString().TrimEnd();
    }

    // Problem 15

    public static void IncreasePrices(BookShopContext context)
    {
        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToList();
        foreach (var book in books)
        {
            book.Price += 5;
        }
        context.SaveChanges();
    }

    // Problem 16
    public static int RemoveBooks(BookShopContext context)
    {
        var booksToRemove = context.Books
            .Where(b => b.Copies < 4200)
            .ToList();
        var count = booksToRemove.Count;
        context.Books.RemoveRange(booksToRemove);
        context.SaveChanges();
        return count;
    }
}



