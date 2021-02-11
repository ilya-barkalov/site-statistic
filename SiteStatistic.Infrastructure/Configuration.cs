using Microsoft.Extensions.DependencyInjection;

using MediatR;

namespace SiteStatistic.Infrastructure
{
    public static class Configuration
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Configuration));
        }
    }
}
