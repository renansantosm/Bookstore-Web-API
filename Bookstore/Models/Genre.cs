using System.Text.Json.Serialization;

namespace Bookstore.Models;

public class Genre
{
    public int GenreId { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}
