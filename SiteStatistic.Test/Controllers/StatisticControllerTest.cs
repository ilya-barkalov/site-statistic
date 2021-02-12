using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SiteStatistic.Controllers;
using SiteStatistic.Infrastructure;
using SiteStatistic.Infrastructure.EFCore;
using SiteStatistic.Infrastructure.EFCore.Helpers;
using SiteStatistic.Infrastructure.Features.GetSections;

using Xunit;

namespace SiteStatistic.Test.Controllers
{
    public class StatisticControllerTest : IDisposable
    {
        private readonly IMediator _mediator;
        private readonly SiteStatisticDbContext _dbContext;

        public StatisticControllerTest()
        {
            var services = new ServiceCollection();

            services.ConfigureInfrastructure();

            services.AddDbContext<SiteStatisticDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "InMemoryDb");
            });
            var provider = services.BuildServiceProvider();

            _mediator = provider.GetRequiredService<IMediator>();
            _dbContext = provider.GetRequiredService<SiteStatisticDbContext>();
            
            _dbContext.Database.EnsureCreated();
            DataSeeder.Seed(_dbContext);

        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Fact]
        public async Task GetSectionsMethod_ShouldWorks()
        {
            // Arrange
            var controller = new StatisticController(_mediator);

            // Act 
            var result = await controller.GetSections();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var sections = Assert.IsAssignableFrom<List<SectionsDto>>(objectResult.Value);
            Assert.NotEmpty(sections);
        }
    }
}
