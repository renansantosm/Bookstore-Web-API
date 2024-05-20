using AutoMapper;
using Bookstore.Models;

namespace Bookstore.DTOs.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Genre, GenreDTO>().ReverseMap();
        CreateMap<Book, BookDTO>().ReverseMap();
    }
}
