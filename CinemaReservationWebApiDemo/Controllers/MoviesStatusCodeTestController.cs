using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaReservationWebApiDemo.Data;
using CinemaReservationWebApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//The purpose of creating this controller is to test and show Status Code operations
namespace CinemaReservationWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesStatusCodeTestController : ControllerBase
    {

        //set up a dbcontext variable for database connection reference
        private CinemaDBContext _dbContext;

        //add a constructor and pass the _dbContext parameter here
        public MoviesStatusCodeTestController(CinemaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<MoviesStatusCodeTestController>
        [HttpGet]
        public IActionResult Get()
        {
            //will return 200 Ok status ok if retrieving data ok
            //return Ok(_dbContext.Movies);

            //However, in order to display status code without needing to remember
            //the number, use this
            return StatusCode(StatusCodes.Status200OK);
        }

        // GET api/<MoviesStatusCodeTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<MoviesStatusCodeTestController>
        //[HttpPost]
        //public IActionResult Post([FromBody] MovieTest1 movieObj)
        //{
        //    _dbContext.Movies.Add(movieObj);
        //    _dbContext.SaveChanges();
        //    return StatusCode(StatusCodes.Status201Created); //use 201 created code
        //}

        // PUT api/<MoviesStatusCodeTestController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] MovieTest1 movieObj)
        //{
        //    var movie = _dbContext.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return NotFound("No record found for this id.");
        //    }
        //    else
            //{
            //    movie.Name = movieObj.Name;
            //    movie.Language = movieObj.Language;
            //    _dbContext.SaveChanges();
            //    return Ok("Record Updated Successfully.");
            //}
        //}

        //// DELETE api/<MoviesStatusCodeTestController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var movie = _dbContext.Movies.Find(id);

        //    if (movie == null)
        //    {
        //        return NotFound("No record found for this id.");
        //    }
        //    else
        //    {
        //        _dbContext.Movies.Remove(movie);
        //        _dbContext.SaveChanges();
        //        return Ok("Record Deleted Successfully.");
        //    }
         
        //}
    }
}
