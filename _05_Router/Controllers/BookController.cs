using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _05_Router.Controllers
{
    /// <summary>
    /// BookController
    /// </summary>
    public class BookController : Controller
    {
        private static readonly List<Book> books;

        static BookController()
        {
            books = Enumerable.Range(1, 200000).Select(i => new Book
            {
                Id = i,
                Name = $"Book{i}",
                Price = (decimal)(i - 0.01),
                Author = $"Author{i}"
            }).ToList();
        }

        public IActionResult Index(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            return Json(book);
        }

        public IActionResult AddBook(Book book)
        {
            books.Add(book);
            return NoContent();
        }
    }

    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Author { get; set; }
    }
}