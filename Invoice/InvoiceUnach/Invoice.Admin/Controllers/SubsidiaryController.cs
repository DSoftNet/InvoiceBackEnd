using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Admin.Models;
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
            return View(await GetSubsidiarys(userId));
        }
        
        public async Task<IActionResult> LoadSubsidiary(Guid subsidiaryId)
        {
            var subsidiaryModel = new SubsidiaryModel();

            subsidiaryModel.Option = "Edit";
            
            return View("Index", subsidiaryModel);
        }

        #region Private Methods
        
        private async Task<SubsidiaryModel> GetSubsidiarys (Guid userId)
        {
            var subsidiaryModel = new SubsidiaryModel();

            subsidiaryModel.Option = "List";

            subsidiaryModel.InputSubsidiarys = new List<SubsidiaryModel.InputSubsidiary>();

            var subsidiarys = await _subsidiaryRepository.Get(userId);

            foreach (var subsidiary in subsidiarys)
            {
                subsidiaryModel.InputSubsidiarys.Add(
                    new SubsidiaryModel.InputSubsidiary(subsidiary.Id,subsidiary.Name,subsidiary.Address,
                        subsidiary.Phone1,subsidiary.Phone2,subsidiary.UserId));
            }

            return subsidiaryModel;
        }
        
        #endregion
        
    }
}