﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SiteStatistic.Infrastructure.EFCore;

namespace SiteStatistic.Infrastructure.Features.GetTopSections
{
    public class GetTopSectionsQueryHandler : IRequestHandler<GetTopSectionsQuery, List<TopSectionsDto>>
    {
        private readonly SiteStatisticDbContext _dbContext;

        /// <summary>
        /// For an empty parameter in the request
        /// </summary>
        private const int TOP_SECTIONS = 3;

        public GetTopSectionsQueryHandler(SiteStatisticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TopSectionsDto>> Handle(GetTopSectionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Database.GetDbConnection().QueryAsync<TopSectionsDto>(
                "[sp_GetTopSections]",
                new { Size = request.Size.GetValueOrDefault(TOP_SECTIONS) }, 
                commandType: CommandType.StoredProcedure);

            return result.OrderByDescending(x => x.NumberOfVisits).ToList();
        }
    }
}
