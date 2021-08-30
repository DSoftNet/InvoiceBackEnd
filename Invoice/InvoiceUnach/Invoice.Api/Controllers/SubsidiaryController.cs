using System;
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
        
        /// <summary>
        /// Get subsidiary
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /subsidiary/{idSubsidiary}/{userId}
        /// 
        /// </remarks>
        /// <param name="idSubsidiary"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Produces(typeof(SubsidiaryResponse))]
        [Route("{idSubsidiary}/{userId}")]
        public async Task<IActionResult> Get(Guid idSubsidiary,Guid userId)
        {
            var queryResult = await _mediator.Send(new ReadSubsidiaryQuery(idSubsidiary,userId));

            return Ok(queryResult);
        }
        
        /// <summary>
        /// Get subsidiaries
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /subsidiary/{userId}
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [Produces(typeof(List<SubsidiaryResponse>))]
        [Route("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var queryResult = await _mediator.Send(new ReadSubsidiariesQuery(userId));

            return Ok(queryResult);
        }
    }
}