using Bookstore.DTOs;
using Bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> Get()
    {
        var booksDto = await _bookService.GetBooks();

        if (booksDto is null) 
            return NotFound("books not found");

        return Ok(booksDto);
    }

    [HttpGet("{id:int}", Name = "GetBook")]
    public async Task<ActionResult<BookDTO>> Get(int id)
    {
        var bookDto = await _bookService.GetBookById(id);

        if (bookDto is null)
            return NotFound("Book not found");

        return Ok(bookDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post(BookDTO bookDTO)
    {
        if (bookDTO is null)
            return BadRequest("Data invalid");

        await _bookService.AddBook(bookDTO);

        return new CreatedAtRouteResult("GetBook", new { id =  bookDTO.Id }, bookDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, BookDTO bookDTO)
    {
        if (id != bookDTO.Id)
            return BadRequest();

        if (bookDTO is null)
            return BadRequest();

        await _bookService.UpdateBook(bookDTO);

        return Ok(bookDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<BookDTO>> Delete(int id)
    {
        var bookDto = await _bookService.GetBookById(id);

        if (bookDto is null)
            return NotFound("Not found found");

        await _bookService.DeleteBook(id);

        return Ok(bookDto);
    }
}
