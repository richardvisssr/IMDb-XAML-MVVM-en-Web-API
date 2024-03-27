namespace Web_API_Movies.Services.MoviesService
{
    public interface IDirectorsService
    {

        Task<List<Movies>> GetMoviesByDirectorAsync(string director);
    }
}
