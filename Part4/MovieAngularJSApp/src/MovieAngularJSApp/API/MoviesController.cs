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
		private readonly MoviesAppContext _dbContext;

		public MoviesController(MoviesAppContext dbContext) 
		{
			_dbContext = dbContext;
		}

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
			return _dbContext.Movies;
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
			var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
			if (movie == null) {
				return new HttpNotFoundResult();
			} else {
				return new ObjectResult(movie);
            } 
		}


        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
			if (movie.Id == 0)
			{
				_dbContext.Movies.Add(movie);
				_dbContext.SaveChanges();
				return new ObjectResult(movie);
			}
			else
			{
				var original = _dbContext.Movies.FirstOrDefault(m => m.Id == movie.Id);
				original.Title = movie.Title;
				original.Director = movie.Director;
				_dbContext.SaveChanges();
				return new ObjectResult(original);
			}
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
			var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
			_dbContext.Movies.Remove(movie);
			_dbContext.SaveChanges();
            return new HttpStatusCodeResult(200);
        }


    }
}
