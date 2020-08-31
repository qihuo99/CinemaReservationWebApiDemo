using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaReservationWebApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesTest1Controller : ControllerBase
    {

        //make sure to add static otherwise the data cannot be cached and displayed correctly
        private static List<MovieTest1> movies = new List<MovieTest1>
        {
            new MovieTest1() { Id=0, Name="Mission Impossible 7", Language="English"},
            new MovieTest1() { Id=1, Name="The Matrix 4", Language="English"},
            new MovieTest1() { Id=2, Name="Jungle Cruise", Language="English"}
        };

        [HttpGet]  //Get = read in CRUD, this will retrieve all movie data
        public IEnumerable<MovieTest1> Get()
        {
            return movies;
        }

        [HttpPost]  //this will create new movie data
        public void Post([FromBody] MovieTest1 movie)
        {
            movies.Add(movie);
        }

        //localhost:44367/api/moviestest1/2  --> this should be the url
        [HttpPut("{id}")]  //this will update existing movie data
        public void Put(int id, [FromBody] MovieTest1 movie)
        {
            movies[id] = movie;
        }

        [HttpDelete("{id}")]  //this will delete a movie data
        public void Delete(int id)
        {
            movies.RemoveAt(id);
        }

    }
}
