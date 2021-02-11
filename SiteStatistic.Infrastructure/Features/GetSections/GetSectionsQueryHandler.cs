using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SiteStatistic.Infrastructure.EFCore;

namespace SiteStatistic.Infrastructure.Features.GetSections
{
    public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, List<SectionsDto>>
    {
        private readonly SiteStatisticDbContext _dbContext;

        public GetSectionsQueryHandler(SiteStatisticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SectionsDto>> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.SiteSections
                .Select(x => new SectionsDto 
                { 
                    Name = x.Name 
                })
                .ToListAsync();
        }
    }
}
