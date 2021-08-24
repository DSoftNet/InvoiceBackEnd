using System.Net;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly IMediator _mediator;

        public CatalogController(ILogger<CatalogController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Added a catalog
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     POST /catalog
        ///     {
        ///         "name":"name",
        ///         "code":"code",
        ///         "value":"value",
        ///         "description":"description",
        ///         "status": true or false,
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateCatalogCommand command)
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