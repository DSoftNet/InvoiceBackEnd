using System.Net;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route("itemCatalog")]
    public class ItemCatalogController : ControllerBase
    {
        private readonly ILogger<ItemCatalogController> _logger;
        private readonly IMediator _mediator;
        
         public ItemCatalogController(ILogger<ItemCatalogController> logger, IMediator mediator)
                {
                    _logger = logger;
                    _mediator = mediator;
                }
         /// <summary>
         /// Added a itemCatalog
         /// </summary>
         /// <remarks>
         /// 
         /// Sample request
         ///
         ///     POST /itemCatalog
         ///     {
         ///         "name":"name",
         ///         "code":"code",
         ///         "description":"description",
         ///         "value":"value",
         ///         "status": true or false,
         ///         "codeCatalog":"codeCatalog",
         ///     }
         /// 
         /// </remarks>
         /// <param name="command"></param>
         /// <returns></returns>
         [HttpPost]
         [ProducesResponseType((int) HttpStatusCode.BadRequest)]
         [ProducesResponseType((int) HttpStatusCode.OK)]
         public async Task<IActionResult> Create([FromBody] CreateItemCatalogCommand command)
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