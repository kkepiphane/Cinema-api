using Cinema_api.Data;
using Cinema_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private CinemaDbContext _dbContext;

        public MoviesController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movieObj)
        {
            _dbContext.Movies.Add(movieObj);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movieObj)
        {

            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound("Id is not found");  
            }
            else
            {

                movie.Name = movieObj.Name;
                movie.Language = movieObj.Language;
                _dbContext.SaveChanges();
                return Ok("Record update successfuly");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound("Id is not found");
            }
            else
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return Ok("Record deleted");
            }
        }
    }
}
