using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SiteStatistic.Infrastructure.EFCore;

namespace SiteStatistic.Infrastructure.Features.GetTopUsers
{
    public class GetTopUsersQueryHandler : IRequestHandler<GetTopUsersQuery, List<TopUsersDto>>
    {
        private readonly SiteStatisticDbContext _dbContext;

        /// <summary>
        /// For an empty parameter in the request
        /// </summary>
        private const int TOP_USERS = 10;

        public GetTopUsersQueryHandler(SiteStatisticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TopUsersDto>> Handle(GetTopUsersQuery request, CancellationToken cancellationToken)
        {
            var rawResult = await _dbContext.Database.GetDbConnection().QueryAsync<TopUsersDtoRaw>(
                 "[sp_GetTopUsers]",
                 new { Size = request.Size.GetValueOrDefault(TOP_USERS) },
                 commandType: CommandType.StoredProcedure);

            var result = rawResult.GroupBy(x => new { x.OrderId, x.FullName })
                .Select(x => new TopUsersDto
                {
                    OrderId = x.Key.OrderId,
                    FullName = x.Key.FullName,
                    Sections = x.Select(x => x.SectionName)
                })
                .OrderBy(x => x.OrderId);

            return result.ToList();
        }
    }
}
