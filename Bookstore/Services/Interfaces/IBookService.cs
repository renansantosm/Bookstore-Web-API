using Bookstore.DTOs;

namespace Bookstore.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetBooks();
    Task<BookDTO> GetBookById(int id);
    Task AddBook(BookDTO bookDTO);
    Task UpdateBook(BookDTO bookDTO);
    Task DeleteBook(int id);
}
