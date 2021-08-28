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
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        /*
        /// <summary>
        /// Added a user
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     POST /user
        ///     {            
        ///         "firstName":"Juan",
        ///         "secondName":"secondName",
        ///         "firstLastName":"Perez",
        ///         "secondLastName":"secondLastName",
        ///         "identificationType":"identificationType",
        ///         "identification":"identification",
        ///         "email":"email",
        ///         "address":"address",
        ///         "phone":"phone",
        ///         "cellPhone":"cellPhone",
        ///         "userName":"userName",
        ///         "password":"password",
        ///         "status":"status",
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
       */
        /// <summary>
        /// Get user
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /user
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [Produces(typeof(List<UserResponse>))]
        public async Task<IActionResult> Get()
        {
            var queryResult = await _mediator.Send(new ReadUsersQuery());

            return Ok(queryResult);
        }
        
        /// <summary>
        /// Get users
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     GET /user/{code}
        /// 
        /// </remarks>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [Produces(typeof(UserResponse))]
        [Route("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var queryResult = await _mediator.Send(new ReadUserQuery(code));

            return Ok(queryResult);
        }
        
        
        /// <summary>
        /// Post a user
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request
        ///
        ///     POST /user/{code}
        ///     {            
        ///         "id":"id"
        ///             or
        ///         "identification":"identification",    
        ///     }
        /// 
        /// </remarks>
        /// <param name="codee"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateUserIdentificationCommand codee)
        {
            var commandResult = await _mediator.Send(codee);
            return Ok(commandResult);
        }
        
        
    }
}