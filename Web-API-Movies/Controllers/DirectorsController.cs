using Microsoft.AspNetCore.Mvc;
using Web_API_Movies.Services.MoviesService;


namespace Web_API_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorsService _directorService;

        public DirectorsController(IDirectorsService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet("{directorName}")]
        public async Task<ActionResult<List<Movies>>> GetMoviesByDirector(string directorName)
        {
            var movies = await _directorService.GetMoviesByDirectorAsync(directorName);

            if (movies == null || movies.Count == 0)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}
