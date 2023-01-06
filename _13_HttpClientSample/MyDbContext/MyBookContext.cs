using _13_HttpClientSample.Models;
using Microsoft.EntityFrameworkCore;

namespace _13_HttpClientSample.MyDbContext;

public class MyBookContext : DbContext
{
    public MyBookContext(DbContextOptions<MyBookContext> options) : base(options)
    {

    }

    public DbSet<BookViewModel> Books { get; set; }
}