using Microsoft.EntityFrameworkCore;
using Web_API_Movies.Data;


namespace Web_API_Movies.Services.MoviesService
{
    public class MoviesService : IMovieService
    {
        private readonly DataContext _context;

        public MoviesService(DataContext context)
        {
            _context = context;
        }

        public async Task<MovieDTO?> GetMovieWithDetailsAsync(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .FirstOrDefaultAsync(m => m.MovieID == id);

            if (movie == null)
            {
                return null;
            }

            var director = await _context.Directors.FirstOrDefaultAsync(d => d.DirectorID == movie.DirectorID);

            var genres = movie.MovieGenres.Select(mg => mg.Genre.Name).ToList();

            var movieDetails = new MovieDTO
            {
                MovieID = movie.MovieID,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Description = movie.Description,
                AverageRating = movie.AverageRating,
                NumberOfVotes = movie.NumberOfVotes,
                GenreName = genres, 
                DirectorName = director?.Name 
            };

            return movieDetails;
        }

        public async Task<List<MovieDTO>> GetMoviesAsync()
        {
            var movies = await _context.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .ToListAsync();

            var result = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var director = await _context.Directors.FindAsync(movie.DirectorID);

                var genres = movie.MovieGenres.Select(mg => mg.Genre.Name).ToList();

                var movieDTO = new MovieDTO
                {
                    MovieID = movie.MovieID,
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Description = movie.Description,
                    AverageRating = movie.AverageRating,
                    NumberOfVotes = movie.NumberOfVotes,
                    DirectorName = director.Name,
                    GenreName = genres
                };

                result.Add(movieDTO);
            }

            return result;
        }

        public async Task AddMovieAsync(Movies movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movies movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(MovieDTO movieDto)
        {
            var movie = await _context.Movies.FindAsync(movieDto.MovieID);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(e => e.MovieID == id);
        }

    }
}