using Emp.Repository;
using Emp.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLConnect.Repository;
using SQLConnect.Service;
 

namespace SQLConnect
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

		public IConfiguration _configuation;
		public Startup(IConfiguration configuation)
		{
			_configuation = configuation;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options => options.EnableEndpointRouting = false)
				.AddJsonOptions(jsonOptions =>
				{
					jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
				})
		   .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			var dbConfig = _configuation.GetSection("ConnectionStrings").GetSection("SqlConnection").Value;
			services.AddDbContextPool<EmpContext>(options => options.UseSqlServer(dbConfig.ToString(), op => op.EnableRetryOnFailure()));
			services.AddTransient<IEmpContext,EmpContext>();
			services.AddTransient<IEmpRepository, EmpRepository>();
			services.AddTransient<IEmpService, EmpService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=emp}/{action=Index}/{id?}");
			});

			app.UseRouting();
		}
	}
}
