using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SiteStatistic.Infrastructure.Features.GetSections;
using SiteStatistic.Infrastructure.Features.GetTopSections;

namespace SiteStatistic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticController(IMediator mediator) 
        {
            _mediator = mediator;
        } 

        /// <summary>
        /// Получить общую статистику
        /// </summary>
        [HttpGet("sections")]
        public async Task<IActionResult> GetSections()
        {
            var result = await _mediator.Send(new GetSectionsQuery());
            return Ok(result);
        }

        [HttpGet("topsections")]
        public async Task<IActionResult> GetTopSections(int size)
        {
            var result = await _mediator.Send(new GetTopSectionsQuery() { Size = size });
            return Ok(result);
        }
    }
}
