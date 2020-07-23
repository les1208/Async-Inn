using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using DB.Properties.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DB.models.Interfaces;
using DB.models.Services;

namespace DB
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //the appsettings.json, by default, is our "Configurations" for the app.

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        public void ConfigureServices(IServiceCollection services)
        {
            //This is where all dependecies are going to live
            //Enable the use of using controllers withing the MVC convention
            services.AddControllers();

            //Register with the app, that the db exists, and what options to use for it.
            services.AddDbContext<AsyncInnDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IHotel, HotelRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {   //set out default routing for our request within the API  app
                //By default, our convention is {site}/[controller]/[action]/[id]
                //id is not requiered, allowing it to be nullable
                endpoints.MapControllerRoute("default", "{Controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}
