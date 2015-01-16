using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MovieAngularJSApp.Models;



namespace MovieAngularJSApp.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return new List<Movie> {
                new Movie {Id=1, Title="Star Wars", Director="Lucas"},
                new Movie {Id=2, Title="King Kong", Director="Jackson"},
                new Movie {Id=3, Title="Memento", Director="Nolan"}
            };
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(new Movie
            {
                Id=1,
                Title="Star Wars",
                Director="Lucas"
            });
        }


        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            return new ObjectResult(movie);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return new HttpStatusCodeResult(200);
        }


    }
}
