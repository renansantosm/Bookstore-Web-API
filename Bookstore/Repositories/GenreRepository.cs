using Bookstore.Context;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresBooks()
        {
            return await _context.Genres.Include(g => g.Books).ToListAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _context.Genres.Where(g => g.GenreId == id).FirstOrDefaultAsync();
        }

        public async Task<Genre> Create(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
        public async Task<Genre> Update(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Delete(int id)
        {
            var genre = await GetGenreById(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}
