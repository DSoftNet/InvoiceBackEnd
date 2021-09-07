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
          ///    /// <summary>
          /// Get itemCatalog
          /// </summary>
          /// <remarks>
          /// 
          /// Sample request
          ///
          ///     GET /itemCatalog/{code}/{codeCatalog}
          /// 
          /// </remarks>
          /// <param name="code"></param>
          /// <param name="codeCatalog"></param>
          /// <returns></returns>
          [HttpGet]
          [ProducesResponseType((int) HttpStatusCode.OK)]
          [ProducesResponseType((int) HttpStatusCode.BadRequest)]
          [Produces(typeof(ItemCatalogResponse))]
          [Route("{code}/{codeCatalog}")]
          public async Task<IActionResult> GetByCode(string code,string codeCatalog)
          {
              var queryResult = await _mediator.Send(new ReadItemCatalogQuery(code,codeCatalog));

              return Ok(queryResult);
          }

          /// <summary>
          /// Get itemsCatalog
          /// </summary>
          /// <remarks>
          /// 
          /// Sample request
          ///
          ///     GET /itemCatalog/{code}
          /// 
          /// </remarks>
          /// <param name="code"></param>
          /// <returns></returns>
          [HttpGet]
          [ProducesResponseType((int) HttpStatusCode.OK)]
          [Produces(typeof(List<ItemCatalogResponse>))]
          [Route("{code}")]
          public async Task<IActionResult> Get(string code)
          {
              var queryResult = await _mediator.Send(new ReadItemsCatalogQuery(code));

              return Ok(queryResult);
          }

    }
}