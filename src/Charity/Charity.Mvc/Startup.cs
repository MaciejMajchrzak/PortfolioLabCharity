using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Charity.Mvc
{
    public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
		}


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<CharityDonationContext>(builder =>
			{
				//builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
				builder.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=charity-donation;Integrated Security=True");
			});

			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
