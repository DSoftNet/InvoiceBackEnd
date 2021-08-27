using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using Invoice.Application.Dtos.Responses;
using Invoice.Application.Queries;
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

        /// <summary>
        /// Get catalogs
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /catalog
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [Produces(typeof(List<CatalogResponse>))]
        public async Task<IActionResult> Get()
        {
            var queryResult = await _mediator.Send(new ReadCatalogsQuery());

            return Ok(queryResult);
        }

        /// <summary>
        /// Get catalogs
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /catalog/{code}
        /// 
        /// </remarks>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Produces(typeof(CatalogResponse))]
        [Route("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var queryResult = await _mediator.Send(new ReadCatalogQuery(code));

            return Ok(queryResult);
        }
    }
}