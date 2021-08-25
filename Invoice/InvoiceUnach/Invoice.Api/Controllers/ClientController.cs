﻿using System.Net;
using System.Threading.Tasks;
using Invoice.Application.Commands;
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
        /// Added a catalog
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     POST /catalog
        ///     {
        ///         "firstName":"firstName",
        ///         "secondName":"secondName",
        ///         "firstLastName":"firstLastName",
        ///         "secondLastName":"secondLastName",
        ///         "identificationType":"identificationType",
        ///         "identification":"identification",
        ///         "email":"email",
        ///         "address":"secondLastName",
        ///         "address":"secondLastName",
        ///         "phone":"phone",
        ///         "cellphone":"cellphone",
        ///         "status": true or false,
        ///         "createAt":"createAt",
        ///         "updateAt":"updateAt",
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
    }
}