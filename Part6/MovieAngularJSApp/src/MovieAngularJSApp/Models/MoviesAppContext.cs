using Microsoft.Data.Entity;
using System;

namespace MovieAngularJSApp.Models
{
    public class MoviesAppContext:DbContext
    {

		public DbSet<Movie> Movies { get; set; }

	}
}