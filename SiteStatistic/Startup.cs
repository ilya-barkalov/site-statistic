using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SiteStatistic.Infrastructure;
using SiteStatistic.Infrastructure.EFCore;
using SiteStatistic.Infrastructure.EFCore.Helpers;

namespace SiteStatistic
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SiteStatisticDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

                options.LogTo(message => Debug.WriteLine(message));
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });

            services.ConfigureInfrastructure();

            services.AddControllers();
            
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ui/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SiteStatisticDbContext dbContext)
        {
            dbContext.Database.Migrate();
 
            if (env.IsDevelopment())
            {
                if (dbContext.User.Count() == 0)
                {
                    DataSeeder.Seed(dbContext);
                }

                app.UseDeveloperExceptionPage();
            }

            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ui";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
