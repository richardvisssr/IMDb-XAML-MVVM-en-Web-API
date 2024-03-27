using Microsoft.EntityFrameworkCore;
using Web_API_Movies.Data;

namespace Web_API_Movies.Services.MoviesService
{
    public class GenreService : IGenreService
    {

        private readonly DataContext _context;
        public GenreService(DataContext context) {

            _context = context;

        }

        public async Task<List<Movies>> GetMoviesByGenreAsync(string genre)
        {
            var result = await _context.Movies
                .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name == genre))
                .ToListAsync();

            return result;
        }
    }
}
