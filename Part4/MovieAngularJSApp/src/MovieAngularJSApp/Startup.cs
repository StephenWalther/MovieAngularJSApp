using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
using MovieAngularJSApp.Models;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;



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
			services.AddMvc();

			// Register Entity Framework
			services.AddEntityFramework(Configuration)
				.AddSqlServer()
				.AddDbContext<MoviesAppContext>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
        }

	}
}
