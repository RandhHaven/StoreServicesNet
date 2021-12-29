using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreServices.Api.ShoppingCart.Persistence;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Aplication.InsertData;
using MediatR;
using System;

namespace StoreServices.Api.ShoppingCart
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

            // Configuration EF Core
            services.AddDbContext<ContextShoppingCart>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnection"));
            });

            //Configuration MediaTR
            services.AddMediatR(typeof(InsertCartSession.Handler).Assembly);

            // Add Http Client
            services.AddHttpClient("Books", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Books"]);
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
