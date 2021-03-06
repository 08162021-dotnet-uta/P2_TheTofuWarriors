using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Api;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.BusinessLogic.Repositories;
using TofuWarrior.Storage;

namespace TofuWarrior
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TofuWarrior", Version = "v1" });
			});

			services.AddCors(options =>
			{
				options.AddPolicy("Dev", builder =>
				{
					//var allowedOrigins = Configuration.GetValue<List<string>>("CORSHosts");
					var allowedOrigins = Configuration.GetSection("CORSHosts").Get<string[]>();
					Console.WriteLine($"Allowed Origins: '{allowedOrigins}'");
					foreach (var origin in allowedOrigins)
					{
						Console.WriteLine($"Allowed Origin: {origin}");
					}
					builder.WithOrigins(allowedOrigins)
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});


			services.AddDbContext<TheTofuWarriorsDBContext>(options =>
			{
				//if db options is already configured, done do anything..
				// otherwise use the Connection string I have in secrets.json
				if (!options.IsConfigured)
				{
					options.UseSqlServer(Configuration.GetConnectionString("TheTofuWarriorsDBConnStr"));
				}
			});
			services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<IFollowingRepository, FollowingRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IRatingRepository, RatingRepository>();
			services.AddScoped<IRepository, RecipeRepo>();
			services.AddScoped<ITagRepository, TagRepository>();
			services.AddScoped<IIngredientRepository, IngredientRepository>();
			services.AddScoped<IMeasurementRepository, MeasurementRepository>();
			services.AddScoped<EdamamRecipeApi>();
			services.AddHttpClient();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TofuWarrior v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("Dev");

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
