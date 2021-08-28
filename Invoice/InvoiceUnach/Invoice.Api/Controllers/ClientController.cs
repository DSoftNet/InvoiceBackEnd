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
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IMediator _mediator;

        public ClientController(ILogger<ClientController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Added a client
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     POST /client
        ///     {
        ///         "firstName":"firstName",
        ///         "secondName":"secondName",
        ///         "firstLastName":"firstLastName",
        ///         "secondLastName":"secondLastName",
        ///         "identificationType":"identificationType",
        ///         "identification":"identification",
        ///         "email":"email",
        ///         "address":"address",
        ///         "phone":"phone",
        ///         "cellphone":"cellphone",
        ///         "status": true or false,
        ///         "userID":"userID"
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateClientCommand command)
        {
            var commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        
        /// <summary>
        /// Get client
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /client/{idClient}/{userId}
        /// 
        /// </remarks>
        /// <param name="idClient"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Produces(typeof(ClientResponse))]
        [Route("{idClient}/{userId}")]
        public async Task<IActionResult> Get(Guid idClient,Guid userId)
        {
            var queryResult = await _mediator.Send(new ReadClientQuery(idClient,userId));

            return Ok(queryResult);
        }
        
        /// <summary>
        /// Get clients
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /client/{userId}
        /// 
        /// </remarks>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [Produces(typeof(List<ClientResponse>))]
        [Route("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var queryResult = await _mediator.Send(new ReadClientsQuery(userId));

            return Ok(queryResult);
        }
        
    }
}