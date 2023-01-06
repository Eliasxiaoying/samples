using _01_HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_HelloWorld.DbContexts;

public class PersonContext : Microsoft.EntityFrameworkCore.DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
}