using Bookstore.Models;

namespace Bookstore.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksPaged(int skip, int take);
    Task<IEnumerable<Book>> GetAll();
    Task<Book> GetBookById(int id);
    Task<Book> Create(Book book);
    Task<Book> Update(Book book);
    Task<Book> Delete(int id);
}