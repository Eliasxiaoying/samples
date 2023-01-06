using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _13_HttpClientSample.Models;

public class BookViewModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long BookId { get; set; }

    public string BookName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Author { get; set; }
}