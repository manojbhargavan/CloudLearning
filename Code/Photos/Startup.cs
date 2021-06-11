using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Photos.Services.Data;

namespace Photos
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/ExceptionHandler");
            }

            app.UseRouting();
            //Routing Area

            app.UseEndpoints(epConfig =>
            {
                epConfig.MapRazorPages();
                epConfig.MapControllerRoute("Default", "{controller}/{action}/{id?}", new { controller = "App", action = "Home" });
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddLogging();

            if (!env.IsDevelopment())
            {
                services.AddTransient<IPhotoRepository, SqLitePhotoRepository>();
            }
            else
            {
                services.AddTransient<IPhotoRepository, SqlServerPhotoRepository>();
            }
        }
    }
}