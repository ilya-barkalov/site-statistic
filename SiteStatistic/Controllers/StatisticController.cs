using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SiteStatistic.Infrastructure.Features.GetSections;

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
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _mediator.Send(new GetSectionsQuery());
            return Ok(result);
        }
    }
}
