using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Routing;

namespace MovieAngularJSApp
{
	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}

	}
}
