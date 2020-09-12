using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaReservationWebApiDemo.Data;
using CinemaReservationWebApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaReservationWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesCRUDTestController : ControllerBase
    {
        //set up a dbcontext variable for database connection reference
        private CinemaDBContext _dbContext;

        //add a constructor and pass the _dbContext parameter here
        public MoviesCRUDTestController(CinemaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //// GET: api/<MoviesCRUDTestController>
        //[HttpGet]
        //public IEnumerable<MovieTest1> Get()
        //{
        //    return _dbContext.Movies;
        //}

        //// GET api/<MoviesCRUDTestController>/5
        //[HttpGet("{id}")]
        //public MovieTest1 Get(int id)
        //{
        //    var movie = _dbContext.Movies.Find(id); 
        //    return movie;
        //}

        //// POST api/<MoviesCRUDTestController>
        //[HttpPost]
        //public void Post([FromBody] MovieTest1 movieObj)
        //{
        //    _dbContext.Movies.Add(movieObj);
        //    _dbContext.SaveChanges();
        //}

        //// PUT api/<MoviesCRUDTestController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] MovieTest1 movieObj)
        //{
        //    var movie = _dbContext.Movies.Find(id);
        //    movie.Name = movieObj.Name;
        //    movie.Language = movieObj.Language;
        //    _dbContext.SaveChanges();
        //}

        //// DELETE api/<MoviesCRUDTestController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var movie = _dbContext.Movies.Find(id);
        //    _dbContext.Movies.Remove(movie);
        //    _dbContext.SaveChanges();
        //}
    }
}
