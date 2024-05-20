using Bookstore.DTOs;

namespace Bookstore.Services.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreDTO>> GetGenres();
    Task<IEnumerable<GenreDTO>> GetGenresBooks();
    Task<GenreDTO> GetGenreById(int id);
    Task AddGenre(GenreDTO genreDto);
    Task UpdateGenre(GenreDTO genreDto);  
    Task DeleteGenre(int id);
}
