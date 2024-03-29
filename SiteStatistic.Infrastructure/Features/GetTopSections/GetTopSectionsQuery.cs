﻿using System.Collections.Generic;

using MediatR;

namespace SiteStatistic.Infrastructure.Features.GetTopSections
{
    public class GetTopSectionsQuery : IRequest<List<TopSectionsDto>>
    {
        /// <summary>
        /// Size
        /// </summary>
        public int? Size { get; set; }
    }
}
