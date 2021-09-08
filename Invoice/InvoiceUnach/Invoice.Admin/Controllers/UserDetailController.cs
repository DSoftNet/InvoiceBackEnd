using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Admin.Models;
using Invoice.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Admin.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly ILogger<UserDetailController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ISubsidiaryRepository _subsidiaryRepository;

        public UserDetailController(ILogger<UserDetailController> logger, IProductRepository productRepository,
            IClientRepository clientRepository, ISubsidiaryRepository subsidiaryRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _subsidiaryRepository = subsidiaryRepository;
        }

        public async Task<IActionResult> Index(Guid userId)
        {
            var userDetailModel = new UserDetailModel();

            userDetailModel.UserId = userId;
            userDetailModel.ProductsTotal = await ProductTotal(userId);
            userDetailModel.ClientsTotal = await ClientTotal(userId);
            userDetailModel.SubsidiariesTotal = await SubsidiaryTotal(userId);

            return View(userDetailModel);
        }

        #region Private Methods

        private async Task<int> ProductTotal(Guid userId)
        {
            var total = await _productRepository.Get(userId);
            return total.Count;
        }

        private async Task<int> ClientTotal(Guid userId)
        {
            var total = await _clientRepository.Get(userId);
            return total.Count;
        }

        private async Task<int> SubsidiaryTotal(Guid userId)
        {
            var total = await _subsidiaryRepository.Get(userId);
            return total.Count;
        }

        #endregion
    }
}