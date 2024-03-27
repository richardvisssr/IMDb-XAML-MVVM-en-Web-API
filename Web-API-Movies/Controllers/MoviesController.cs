using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Movies.Services.MoviesService;


namespace Web_API_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService moviesService)
        {
            _movieService = moviesService;
        }
      
        
        [HttpGet]
        public async Task<ActionResult<List<Movies>>> GetAllMovies()
        {
            var result = await _movieService.GetMoviesAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieWithDetailsAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movies>> PostMovie(Movies movie)
        {
            await _movieService.AddMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieID }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movies movie)
        {
            if (id != movie.MovieID)
            {
                return BadRequest();
            }

            try
            {
                await _movieService.UpdateMovieAsync(movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _movieService.MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieWithDetailsAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(movie);
            return NoContent();
        }


    }
}
