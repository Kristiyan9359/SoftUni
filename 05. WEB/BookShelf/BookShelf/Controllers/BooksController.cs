namespace BookShelf.Controllers;

using BookShelf.Data;
using BookShelf.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BooksController : Controller
{
    private readonly ApplicationDbContext dbContext;
    public BooksController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Book> books = this.dbContext
            .Books
            .AsNoTracking()
            .Include(b => b.Author)
            .OrderBy(b => b.Title)
            .ToArray();

        return View(books);
    }

    [HttpGet]

    public IActionResult Create()
    {
        IEnumerable<Author> authors = dbContext
            .Authors
            .AsNoTracking()
            .OrderBy(a => a.Name)
            .ToArray();

        ViewData["Authors"] = authors;

        return View();
    }

    [HttpPost]

    public IActionResult Create(Book inputModel)
    {
        try
        {
            Author? refAuthor = dbContext
                .Authors
                .Find(inputModel.Id);

            if (refAuthor == null)
            {
                return BadRequest();
            }

            dbContext.Books.Add(inputModel);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}