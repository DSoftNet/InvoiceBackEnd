using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Admin.Models;
using Invoice.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Admin.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
       private readonly IClientRepository _clientRepository;

       public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
       {
           _logger = logger;
           _clientRepository = clientRepository;
       }
       
       public async Task<IActionResult> Index(Guid userId)
       {
           return View(await GetClients(userId));
       }

       public async Task<IActionResult> LoadClient(Guid clientId)
       {
           var clientModel = new ClientModel();

           clientModel.Option = "Edit";
            
           return View("Index", clientModel);
       }

       #region Private Methods

       private async Task<ClientModel> GetClients(Guid userId)
       {
           var clientModel = new ClientModel();

           clientModel.Option = "List";

           clientModel.InputClients = new List<ClientModel.InputClient>();

           var  clients = await _clientRepository.Get(userId);

           foreach (var client in clients)
           {
               clientModel.InputClients.Add(
                   new ClientModel.InputClient(client.Id, client.FirstName, client.SecondName, client.FirstLastName,
                       client.SecondLastName, client.IdentificationType, client.Identification, client.Email,
                       client.Address, client.Phone, client.CellPhone, client.Status, client.UserId));
           }

           return clientModel;
           
       }
       #endregion

    }
}