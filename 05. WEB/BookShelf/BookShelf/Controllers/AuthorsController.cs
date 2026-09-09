namespace BookShelf.Controllers;

using BookShelf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorsController : Controller
{
    private readonly ApplicationDbContext dbContext;
    public AuthorsController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var authors = this.dbContext
            .Authors
            .AsNoTracking()
            .OrderBy(a => a.Name)
            .ThenBy(a => a.Country)
            .ThenBy(a => a.Id)
            .ToArray();

        return View(authors);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        var author = dbContext
            .Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .AsSplitQuery()
            .SingleOrDefault(a => a.Id == id);

        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }
}
