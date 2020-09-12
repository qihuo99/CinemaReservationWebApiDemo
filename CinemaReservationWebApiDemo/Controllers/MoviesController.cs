using System.Collections.Generic;
using CinemaReservationWebApiDemo.Data;
using CinemaReservationWebApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaReservationWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //set up a dbcontext variable for database connection reference
        private CinemaDBContext _dbContext;

        //add a constructor and pass the _dbContext parameter here
        public MoviesController(CinemaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _dbContext.Movies;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            return movie;
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] Movie movieObj)
        {
            _dbContext.Movies.Add(movieObj);
            _dbContext.SaveChanges();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MovieTest1 movieObj)
        {
            var movie = _dbContext.Movies.Find(id);
            movie.Name = movieObj.Name;
            movie.Language = movieObj.Language;
            movie.Rating = movieObj.Rating;
            _dbContext.SaveChanges();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }

    }
}
