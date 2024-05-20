using AutoMapper;
using Bookstore.DTOs;
using Bookstore.Models;
using Bookstore.Repositories;
using Bookstore.Services.Interfaces;

namespace Bookstore.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreDTO>> GetGenres()
    {
        var genresEntities = await _genreRepository.GetAll();
        return _mapper.Map<IEnumerable<GenreDTO>>(genresEntities);
    }
    public async Task<IEnumerable<GenreDTO>> GetGenresBooks()
    {
        var genresEntities = await _genreRepository.GetGenresBooks();
        return _mapper.Map<IEnumerable<GenreDTO>>(genresEntities);
    }

    public async Task<GenreDTO> GetGenreById(int id)
    {
        var genreEntity = await _genreRepository.GetGenreById(id);
        return _mapper.Map<GenreDTO>(genreEntity);
    }

    public async Task AddGenre(GenreDTO genreDto)
    {
        var genreEntity = _mapper.Map<Genre>(genreDto);
        await _genreRepository.Create(genreEntity);
        genreDto.GenreId = genreEntity.GenreId; 
    }

    public async Task UpdateGenre(GenreDTO genreDto)
    {
        var genreEntity = _mapper.Map<Genre>(genreDto);
        await _genreRepository.Update(genreEntity);
    }

    public async Task DeleteGenre(int id)
    {
        var genreEntity = _genreRepository.GetGenreById(id).Result;
        await _genreRepository.Delete(genreEntity.GenreId);
    }
}
