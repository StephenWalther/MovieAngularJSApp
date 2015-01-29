using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
using MovieAngularJSApp.Models;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity.SqlServer;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNet.Routing;

namespace MovieAngularJSApp
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			// Setup configuration sources.
			Configuration = new Configuration()
				.AddJsonFile("config.json")
				.AddEnvironmentVariables();
		}

		public IConfiguration Configuration { get; set; }


		public void ConfigureServices(IServiceCollection services)
		{
			// add Entity Framework
			services.AddEntityFramework(Configuration)
					.AddSqlServer()
					.AddDbContext<MoviesAppContext>(options =>
					{
						options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"));
					});

			// add ASP.NET Identity
			services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
				.AddEntityFrameworkStores<MoviesAppContext>();

			// add ASP.NET MVC
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseIdentity();
			app.UseMvc();

			CreateSampleData(app.ApplicationServices).Wait();
		}


		private static async Task CreateSampleData(IServiceProvider applicationServices)
		{
			using (var dbContext = applicationServices.GetService<MoviesAppContext>())
			{
				var sqlServerDatabase = dbContext.Database as SqlServerDatabase;
				if (sqlServerDatabase != null)
				{
					// Create database in user root (c:\users\your name)
					if (await sqlServerDatabase.EnsureCreatedAsync()) {
						// add some movies
						var movies = new List<Movie>
						{
							new Movie {Title="Star Wars", Director="Lucas"},
							new Movie {Title="King Kong", Director="Jackson"},
							new Movie {Title="Memento", Director="Nolan"}
						};
						movies.ForEach(m => dbContext.Movies.AddAsync(m));

						// add some users
						var userManager = applicationServices.GetService<UserManager<ApplicationUser>>();

						// add editor user
						var stephen = new ApplicationUser
						{
							UserName = "Stephen"
						};
						var result = await userManager.CreateAsync(stephen, "P@ssw0rd");
						await userManager.AddClaimAsync(stephen, new Claim("CanEdit", "true"));

						// add normal user
						var bob = new ApplicationUser
						{
							UserName = "Bob"
						};
						await userManager.CreateAsync(bob, "P@ssw0rd");
					}

				}
			}
		}



	}
}
