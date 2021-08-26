using System.Net;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route(template:"subsidiary")]
    public class SubsidiaryController : ControllerBase
    { 
        private readonly ILogger<SubsidiaryController> _logger;
        private readonly IMediator _mediator;

        public SubsidiaryController(ILogger<SubsidiaryController> logger, IMediator mediator)
        { 
            _logger = logger;
            _mediator = mediator;
        }
        
        /// <summary>
        /// Added a subsidiary
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     POST /subsidiary
        ///     {
        ///         "name":"name",
        ///         "address":"address",
        ///         "phone1":"phone1",
        ///         "phone2":"phone2",
        ///         "userId":"userId",
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateSubsidiaryCommand command)
        { 
            var commandResult = await _mediator.Send(command);

            if (!commandResult) 
            {
                    return BadRequest();
            }

            return Ok(true);
        }
    }
}