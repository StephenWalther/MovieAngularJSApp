using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
using MovieAngularJSApp.Models;

namespace MovieAngularJSApp
{
	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			// Register Entity Framework
			services.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<MoviesAppContext>(options =>
				{
					options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MoviesDatabase;Trusted_Connection=True");
				});
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
        }

	}
}
