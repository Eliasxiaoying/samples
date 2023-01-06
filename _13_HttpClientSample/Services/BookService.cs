using _13_HttpClientSample.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace _13_HttpClientSample.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("localhost");
    }

    public async Task<IEnumerable<BookViewModel>> GetBooks()
    {
        var message = new HttpRequestMessage(HttpMethod.Get, "book/book");
        var response = await _httpClient.SendAsync(message);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<IEnumerable<BookViewModel>>(content);

        return books;
    }

    public async Task<BookViewModel> GetBookById(int id)
    {
        var message = new HttpRequestMessage(HttpMethod.Get, $"book/GetBookById/{id}");
        var response = await _httpClient.SendAsync(message);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var book = JsonConvert.DeserializeObject<BookViewModel>(content);

        return book;
    }

    public async Task CreateBook(BookViewModel book)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "book/book");
        var content = new StringContent(JsonSerializer.Serialize(book));
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException("请求失败");
        }
    }
}