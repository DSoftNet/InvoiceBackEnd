﻿using System;
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
       
       #region Methods Update
       public async Task<IActionResult> LoadClient(Guid clientId)
       {
           var clientModel = new ClientModel();
           clientModel.Option = "Edit";
            
           var client = await _clientRepository.GetById(clientId);

           clientModel.InputClientModel =
               new ClientModel.InputClient
               {
                   Id = client.Id,
                   FirstName = client.FirstName,
                   SecondName = client.SecondName,
                   FirstLastName = client.FirstLastName,
                   SecondLastName = client.SecondLastName,
                   IdentificationType = client.IdentificationType,
                   Identification = client.Identification,
                   Email = client.Email,
                   Address = client.Address,
                   Phone = client.Phone,
                   CellPhone = client.CellPhone,
                   Status = client.Status,
                   UserId = client.UserId
               };

           return View("Index", clientModel);
       }

       [HttpPost]
       public async Task<IActionResult> Update(ClientModel clientModel)
       {
           if (ModelState.IsValid)
           {
               var client = await _clientRepository.GetById(clientModel.InputClientModel.Id);

               client.SetFirstName(clientModel.InputClientModel.FirstName);
               client.SetSecondName(clientModel.InputClientModel.SecondName);
               client.SetFirstLastName(clientModel.InputClientModel.FirstLastName);
               client.SetSecondLastName(clientModel.InputClientModel.SecondLastName);
               client.SetIdentificationType(clientModel.InputClientModel.IdentificationType);
               client.SetIdentification(clientModel.InputClientModel.Identification);
               client.SetEmail(clientModel.InputClientModel.Email);
               client.SetAddress(clientModel.InputClientModel.Address);
               client.SetPhone(clientModel.InputClientModel.Phone);
               client.SetCellPhone(clientModel.InputClientModel.CellPhone);
               client.SetStatus(clientModel.InputClientModel.Status);
               

               _clientRepository.Update(client);
               await _clientRepository.UnitOfWork.SaveEntitiesAsync();

               clientModel = await GetClients(clientModel.InputClientModel.UserId);

               return await Task.Run(() => View("Index", clientModel));
           }
           else
           {
               return await Task.Run(() => View("Index", clientModel));
           }
       }

       #endregion
       #region Methods Delete

       public async Task<IActionResult> Delete(Guid clientId, Guid userId)
       {
           var client = await _clientRepository.GetById(clientId);

           _clientRepository.Delete(client);
           await _clientRepository.UnitOfWork.SaveEntitiesAsync();

           var clientModel = await GetClients(userId);

           return View("Index", clientModel);
       }

       #endregion

       #region Private Methods

       private async Task<ClientModel> GetClients(Guid userId)
       {
           var clientModel = new ClientModel();
           
           clientModel.Option = "List";
           clientModel.UserId = userId;

           clientModel.InputClients = new List<ClientModel.InputClient>();

           var  clients = await _clientRepository.Get(userId);

           foreach (var client in clients)
           {
               clientModel.InputClients.Add(
                   new ClientModel.InputClient{
                       Id = client.Id,
                       FirstName = client.FirstName,
                       SecondName = client.SecondName,
                       FirstLastName = client.FirstLastName,
                       SecondLastName = client.SecondLastName,
                       IdentificationType = client.IdentificationType,
                       Identification = client.Identification,
                       Email = client.Email,
                       Address = client.Address,
                       Phone = client.Phone,
                       CellPhone = client.CellPhone,
                       Status = client.Status,
                       UserId = client.UserId
                   });
           }

           return clientModel;
           
       }
       #endregion

    }
}