using Bookstore.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bookstore.DTOs;

public class BookDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Title is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(3)]
    [MaxLength(255)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The author is Required")]
    [MinLength(1)]
    [MaxLength(100)]
    public string? Author { get; set; }

    [Required(ErrorMessage = "The Price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    public int Stock { get; set; }

    [JsonIgnore]
    public Genre? Genre { get; set; }

    public int GenreId { get; set; }

}
