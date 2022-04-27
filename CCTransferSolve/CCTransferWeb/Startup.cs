using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCTransferWeb.Controllers;
using CCTransferWeb.Models;
using CCTransferWeb.DbContexts;

namespace CCTransferWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CCTransferDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMonedaRepository, MonedaFakeRepository>();
            services.AddScoped<IConversor, ConversorEuroDolar>();
            services.AddScoped<IConversor, ConversorEuroLibra>();
            services.AddScoped<IConversor, ConversorEuroYen>();
            services.AddScoped<IConversor, ConversorEuroFranco>();

            services.AddControllersWithViews();
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
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{importe?}");
            });
        }
    }
}
