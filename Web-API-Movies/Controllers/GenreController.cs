using Microsoft.AspNetCore.Mvc;
using Web_API_Movies.Services.MoviesService;


namespace Web_API_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("{genre}")]
        public async Task<ActionResult<List<Movies>>> GetMoviesByGenre(string genre)
        {
            var movies = await _genreService.GetMoviesByGenreAsync(genre);

            if (movies == null || movies.Count == 0)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}
