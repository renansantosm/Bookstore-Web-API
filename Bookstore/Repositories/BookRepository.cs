using Bookstore.Context;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooksPaged(int skip, int take)
    {
        return await _context.Books.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Book> GetBookById(int id)
    {
        return await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> Create(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }
    public async Task<Book> Update(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> Delete(int id)
    {
        var book = await GetBookById(id);
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return book;
    }
}
