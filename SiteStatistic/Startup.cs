using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SiteStatistic.Data.EFCore;
using SiteStatistic.Helpers;

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

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SiteStatisticDbContext dbContext)
        {
            dbContext.Database.Migrate();
 
            if (dbContext.User.Count() == 0)
            {
                DataSeeder.SeedAsync(dbContext);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
