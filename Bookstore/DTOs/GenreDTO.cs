using Bookstore.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bookstore.DTOs;

public class GenreDTO
{
    public int GenreId { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    public ICollection<Book>? Books { get; set; }

}
