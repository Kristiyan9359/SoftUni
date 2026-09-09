using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        private readonly IEnumerable<Book> Books = new List<Book>
        {
           new Book
    {
        Id = 1,
        Title = "1984",
        Year = 1949,
        AuthorId = 1
    },
    new Book
    {
        Id = 2,
        Title = "Animal Farm",
        Year = 1945,
        AuthorId = 1
    },
    new Book
    {
        Id = 3,
        Title = "Pride and Prejudice",
        Year = 1813,
        AuthorId = 2
    },
    new Book
    {
        Id = 4,
        Title = "Sense and Sensibility",
        Year = 1811,
        AuthorId = 2
    },
    new Book
    {
        Id = 5,
        Title = "The Adventures of Tom Sawyer",
        Year = 1876,
        AuthorId = 3
    },
    new Book
    {
        Id = 6,
        Title = "Adventures of Huckleberry Finn",
        Year = 1884,
        AuthorId = 3
    },
    new Book
    {
        Id = 7,
        Title = "Crime and Punishment",
        Year = 1866,
        AuthorId = 4
    },
    new Book
    {
        Id = 8,
        Title = "The Idiot",
        Year = 1869,
        AuthorId = 4
    },
    new Book
    {
        Id = 9,
        Title = "The Old Man and the Sea",
        Year = 1952,
        AuthorId = 5
    },
    new Book
    {
        Id = 10,
        Title = "A Farewell to Arms",
        Year = 1929,
        AuthorId = 5
    }
        };
        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasData(Books);
        }
    }
}
