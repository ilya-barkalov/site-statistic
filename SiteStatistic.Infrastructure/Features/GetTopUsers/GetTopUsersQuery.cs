using System.Collections.Generic;

using MediatR;

namespace SiteStatistic.Infrastructure.Features.GetTopUsers
{
    public class GetTopUsersQuery : IRequest<List<TopUsersDto>>
    {
        /// <summary>
        /// Size
        /// </summary>
        public int? Size { get; set; }
    }
}
