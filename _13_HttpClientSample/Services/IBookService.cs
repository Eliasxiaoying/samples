using System.Collections.Generic;
using System.Threading.Tasks;
using _13_HttpClientSample.Models;
using Refit;

namespace _13_HttpClientSample.Services;

public interface IBookService
{
    [Get("/book/book")]
    Task<IEnumerable<BookViewModel>> GetBooks();

    [Get("/book/GetBookById/{id}")]
    Task<BookViewModel> GetBookById(int id);

    [Post("/book/book")]
    Task CreateBook([Body(BodySerializationMethod.Serialized)] BookViewModel book);
}