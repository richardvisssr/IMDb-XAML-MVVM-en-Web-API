using Microsoft.EntityFrameworkCore;
using Web_API_Movies.Data;

namespace Web_API_Movies.Services.MoviesService
{
    public class DirectorsService : IDirectorsService
    {

        private readonly DataContext _context;
        public DirectorsService(DataContext context)
        {

            _context = context;

        }

        public async Task<List<Movies>> GetMoviesByDirectorAsync(string director)
        {
            var result = await _context.Movies.Where(x => x.Director.Name == director).ToListAsync();

            return result;
        }

    }
}

