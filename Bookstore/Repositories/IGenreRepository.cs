using Bookstore.Models;

namespace Bookstore.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAll();
    Task<IEnumerable<Genre>> GetGenresBooks();
    Task<Genre> GetGenreById(int id);
    Task<Genre> Create(Genre genre);
    Task<Genre> Update(Genre genre);
    Task<Genre> Delete(int id);
}
