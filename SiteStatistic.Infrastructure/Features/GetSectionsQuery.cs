using System.Collections.Generic;

using MediatR;

using SiteStatistic.Core.Data.Entities;

namespace SiteStatistic.Infrastructure.Features
{
    public class GetSectionsQuery : IRequest<List<SiteSection>> 
    { 
    }
}
