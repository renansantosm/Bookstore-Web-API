using Bookstore.DTOs;
using Bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

[Route("api/[controller]")]
[EnableCors("OriginWithAccessAllowed")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreDTO>>> Get()
    {
        var genreDto = await _genreService.GetGenres();

        if (genreDto is null)
            return NotFound("Genres not found");

        return Ok(genreDto);
    }

    [HttpGet("books")]
    public async Task<ActionResult<IEnumerable<GenreDTO>>> GetGenresBooks()
    {
        var genresDto = await _genreService.GetGenresBooks();

        if (genresDto is null)
            return NotFound("Genres not found");

        return Ok(genresDto);   
    }

    [HttpGet("{id:int}", Name = "GetGenre")]
    public async Task<ActionResult<GenreDTO>> Get(int id)
    {
        var genreDto = await _genreService.GetGenreById(id);

        if (genreDto is null)
            return NotFound("Genre not found");

        return Ok(genreDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post(GenreDTO genreDto)
    {
        if (genreDto is null)
            return BadRequest("Invalid data");

        await _genreService.AddGenre(genreDto);

        return new CreatedAtRouteResult("GetGenre", new { id = genreDto.GenreId }, genreDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, GenreDTO genreDto)
    {
        if (genreDto.GenreId != id)
            return BadRequest();

        if (genreDto is null)
            return BadRequest();

        await _genreService.UpdateGenre(genreDto);

        return Ok(genreDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<GenreDTO>> Delete(int id)
    {
        var genreDto = await _genreService.GetGenreById(id);

        if (genreDto is null)
            return NotFound("Genre not found");

        await _genreService.DeleteGenre(id);

        return Ok(genreDto);
    }
}
