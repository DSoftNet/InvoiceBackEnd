using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Admin.Models;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Admin.Controllers
{
    public class SubsidiaryController : Controller
    {
        private readonly ILogger<SubsidiaryController> _logger;
        private readonly ISubsidiaryRepository _subsidiaryRepository;

        public SubsidiaryController(ILogger<SubsidiaryController> logger, ISubsidiaryRepository subsidiaryRepository)
        {
            _logger = logger;
            _subsidiaryRepository = subsidiaryRepository;
        }
        
        // GET
        public async Task<IActionResult> Index(Guid userId)
        {
            return View(await GetSubsidiaries(userId));
        }
        
        public async Task<IActionResult> LoadSubsidiary(Guid subsidiaryId)
        {
            var subsidiaryModel = new SubsidiaryModel();

            subsidiaryModel.Option = "Edit";
            
            var subsidiary = await _subsidiaryRepository.GetById(subsidiaryId);
            
            subsidiaryModel.InputSubsidiaryModel= 
                new SubsidiaryModel.InputSubsidiary
                {
                    Id = subsidiary.Id,
                    Name = subsidiary.Name,
                    Address = subsidiary.Address,
                    Phone1 = subsidiary.Phone1,
                    Phone2 = subsidiary.Phone2,
                    UserId = subsidiary.UserId
                };
            
            return View("Index", subsidiaryModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(SubsidiaryModel subsidiaryModel)
        {
            if (ModelState.IsValid)
            {
            }
            else
            {
                return await Task.Run(() => View("Index", subsidiaryModel));
            }

            return View();
        }
        
        #region Private Methods
        
        private async Task<SubsidiaryModel> GetSubsidiaries (Guid userId)
        {
            var subsidiaryModel = new SubsidiaryModel();

            subsidiaryModel.Option = "List";
            subsidiaryModel.UserId = userId;

            subsidiaryModel.InputSubsidiaries = new List<SubsidiaryModel.InputSubsidiary>();

            var subsidiaries = await _subsidiaryRepository.Get(userId);

            foreach (var subsidiary in subsidiaries)
            {
                subsidiaryModel.InputSubsidiaries.Add(
                    new SubsidiaryModel.InputSubsidiary
                {
                    Id = subsidiary.Id,
                    Name = subsidiary.Name,
                    Address = subsidiary.Address,
                    Phone1 = subsidiary.Phone1,
                    Phone2 = subsidiary.Phone2,
                    UserId = subsidiary.UserId
                });
            }
            
            return subsidiaryModel;
            
        }
        
        #endregion
        
        #region Methods Create

        public IActionResult LoadFormCreate(Guid userId)
        {
            var subsidiaryModel = new SubsidiaryModel();
            subsidiaryModel.Option = "Add";
            subsidiaryModel.UserId = userId;

            return View("Index", subsidiaryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubsidiaryModel subsidiaryModel)
        {
            if (ModelState.IsValid)
            {
                var subsidiary = new Subsidiary(subsidiaryModel.InputSubsidiaryModel.Name,
                    subsidiaryModel.InputSubsidiaryModel.Address, subsidiaryModel.InputSubsidiaryModel.Phone1,
                    subsidiaryModel.InputSubsidiaryModel.Phone2,
                    subsidiaryModel.UserId);

                _subsidiaryRepository.Add(subsidiary );
                await _subsidiaryRepository.UnitOfWork.SaveEntitiesAsync();

                subsidiaryModel = await GetSubsidiaries(subsidiaryModel.UserId);

                return await Task.Run(() => View("Index", subsidiaryModel));
            }
            else
            {
                return await Task.Run(() => View("Index", subsidiaryModel));
            }
        }

        #endregion
        
    }
}