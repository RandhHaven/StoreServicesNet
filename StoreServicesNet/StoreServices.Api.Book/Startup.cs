using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreServices.Api.Book.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using MediatR;
using AutoMapper;
using System.Reflection;
using FluentValidation;

namespace StoreServices.Api.Book
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
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // Configuration EF Core
            services.AddDbContext<ContextBook>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnection"));
            });

            //Configuration MediaTR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Phonebook API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
