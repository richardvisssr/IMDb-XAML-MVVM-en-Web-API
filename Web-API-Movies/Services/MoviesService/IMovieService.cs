

namespace Web_API_Movies.Services.MoviesService
{
    public interface IMovieService
    {
        Task<MovieDTO?> GetMovieWithDetailsAsync(int id);
        Task<List<MovieDTO>> GetMoviesAsync();
        Task AddMovieAsync(Movies movie);
        Task UpdateMovieAsync(Movies movie);
        Task<bool> MovieExists(int id);
        Task DeleteMovieAsync(MovieDTO movie);
    }



}
