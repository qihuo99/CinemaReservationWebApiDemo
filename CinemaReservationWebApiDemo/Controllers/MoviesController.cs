using System;
using System.Collections.Generic;
using System.IO;
using CinemaReservationWebApiDemo.Data;
using CinemaReservationWebApiDemo.Models;
using Microsoft.AspNetCore.Http;
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
        //[HttpPost]
        //public void Post([FromBody] Movie movieObj)
        //{
        //    _dbContext.Movies.Add(movieObj);
        //    _dbContext.SaveChanges();
        //}

        [HttpPost]
        public IActionResult Post([FromForm] Movie movieObj)
        {
            var guid = Guid.NewGuid();
            var filePath = Path.Combine("wwwroot\\images\\", guid+".jpg");
            if (movieObj.Image != null)
            {
                var fileStream = new FileStream(filePath, FileMode.Create);
                movieObj.Image.CopyTo(fileStream);                
            }
            movieObj.ImageUrl = filePath;
            _dbContext.Movies.Add(movieObj);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created); //use 201 created code
            //return Ok();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Movie movieObj)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound("No record found for this id.");
            }
            else 
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot\\images\\", guid + ".jpg");
                if (movieObj.Image != null)
                {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    movieObj.Image.CopyTo(fileStream);
                }

                movie.Name = movieObj.Name;
                movie.Language = movieObj.Language;
                movie.Rating = movieObj.Rating;
                _dbContext.SaveChanges();
                return Ok("Record updated successfully.");
            }
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
