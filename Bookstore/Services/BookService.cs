using AutoMapper;
using Bookstore.DTOs;
using Bookstore.Models;
using Bookstore.Repositories;
using Bookstore.Services.Interfaces;

namespace Bookstore.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDTO>> GetBooksPaged(int skip, int take)
    {
        var books = await _bookRepository.GetBooksPaged(skip, take);
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public async Task<IEnumerable<BookDTO>> GetBooks()
    {
        var booksEntities = await _bookRepository.GetAll();
        return _mapper.Map<IEnumerable<BookDTO>>(booksEntities);
    }

    public async Task<BookDTO> GetBookById(int id)
    {
        var bookEntity = await _bookRepository.GetBookById(id);
        return _mapper.Map<BookDTO>(bookEntity);
    }

    public async Task AddBook(BookDTO bookDTO)
    {
        var bookEntity = _mapper.Map<Book>(bookDTO);
        await _bookRepository.Create(bookEntity);
        bookDTO.Id = bookEntity.Id;
    }

    public async Task UpdateBook(BookDTO bookDTO)
    {
        var bookEntity = _mapper.Map<Book>(bookDTO);
        await _bookRepository.Update(bookEntity); 
    }

    public async Task DeleteBook(int id)
    {
        var bookEntity = _bookRepository.GetBookById(id).Result;
        await _bookRepository.Delete(bookEntity.Id);
    }
}
