using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;

namespace MovieAngularJSApp.Models
{
	public class ApplicationUser : IdentityUser {}

    public class MoviesAppContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Movie> Movies { get; set; }
	}
}