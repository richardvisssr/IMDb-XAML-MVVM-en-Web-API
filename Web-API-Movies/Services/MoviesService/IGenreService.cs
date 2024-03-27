

namespace Web_API_Movies.Services.MoviesService
{
    public interface IGenreService
    {

        Task<List<Movies>> GetMoviesByGenreAsync(string genre);

    }
}
