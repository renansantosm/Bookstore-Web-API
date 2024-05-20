using System.Text.Json.Serialization;

namespace Bookstore.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public decimal Price { get; set; }
    public int Stock {  get; set; }

    // Foreign key
    [JsonIgnore]
    public Genre? Genre { get; set; }
    public int GenreId { get; set; }
}
