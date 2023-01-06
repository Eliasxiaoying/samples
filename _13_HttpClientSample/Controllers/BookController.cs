using System.Threading.Tasks;
using _13_HttpClientSample.Models;
using _13_HttpClientSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace _13_HttpClientSample.Controllers;

public class BookController : Controller
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    public async Task<IActionResult> GetBooks()
    {
        var books = await _service.GetBooks();
        return new JsonResult(books);
    }

    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _service.GetBookById(id);
        return Json(book);
    }

    public async Task<IActionResult> CreateBook([FromBody] BookViewModel book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _service.CreateBook(book);
        return Ok();
    }
}