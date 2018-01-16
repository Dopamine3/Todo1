using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TodoFromDB.Entities;
using Microsoft.EntityFrameworkCore;
using TodoFromDB.Models;
using TodoFromDB.Repositories;
using Microsoft.Extensions.Configuration;

namespace TodoFromDB
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TodoContext>(options => options.UseNpgsql(Configuration["ConectionString"]));
            services.AddScoped<TodoContext>();
            services.AddScoped<Todo>();
            services.AddScoped<TodoRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();

        }
    }
}
