using System.Collections.Generic;

using MediatR;

namespace SiteStatistic.Infrastructure.Features.GetSections
{
    public class GetSectionsQuery : IRequest<List<SectionsDto>> 
    { 
    }
}
