using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SiteStatistic.Core.Data.Entities;
using SiteStatistic.Infrastructure.EFCore;

namespace SiteStatistic.Infrastructure.Features
{
    public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, List<SiteSection>>
    {
        private readonly SiteStatisticDbContext _dbContext;

        public GetSectionsQueryHandler(SiteStatisticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SiteSection>> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.SiteSections.ToListAsync();
        }
    }
}
