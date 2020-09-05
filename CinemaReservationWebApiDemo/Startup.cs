using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaReservationWebApiDemo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CinemaReservationWebApiDemo
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
            services.AddDbContext<CinemaDBContext>(option => option.UseSqlServer(@"Data Source=LAPTOP-UH2ADJKS\SQLEXPRESS2017;Initial Catalog=CinemaDB;Integrated Security=true;"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // add a new dbContext variable for internal reference to create a new database
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CinemaDBContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // EnsureCreated method will make sure if a database is being created.
            // If no specified db exists, a new db will be created, otherwise no
            // action will be taken.  Only use this method if you don't have to update
            // or make changes to your database in the future.
            dbContext.Database.EnsureCreated();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
