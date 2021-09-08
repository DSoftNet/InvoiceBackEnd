using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Admin.Models;
using Invoice.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Invoice.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(Guid userId)
        {
            return View(await GetProducts(userId));
        }

        public async Task<IActionResult> LoadProduct(Guid productId)
        {
            var productModel = new ProductModel();
            productModel.Option = "Edit";

            var product = await _productRepository.GetById(productId);

            productModel.InputProductModel =
                new ProductModel.InputProduct
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Code = product.Code,
                    Price = product.Price,
                    IsIva = product.IsIva,
                    Stock = product.Stock,
                    IsExpiration = product.IsExpiration,
                    ExpirationAt = product.ExpirationAt,
                    Status = product.Status,
                    UserId = product.UserId
                };

            return View("Index", productModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
            }
            else
            {
                return await Task.Run(() => View("Index", productModel));
            }

            return View();
        }

        #region Private Methods

        private async Task<ProductModel> GetProducts(Guid userId)
        {
            var productModel = new ProductModel();

            productModel.Option = "List";

            productModel.InputProducts = new List<ProductModel.InputProduct>();

            var products = await _productRepository.Get(userId);

            foreach (var product in products)
            {
                productModel.InputProducts.Add(
                    new ProductModel.InputProduct
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Code = product.Code,
                        Price = product.Price,
                        IsIva = product.IsIva,
                        Stock = product.Stock,
                        IsExpiration = product.IsExpiration,
                        ExpirationAt = product.ExpirationAt,
                        Status = product.Status,
                        UserId = product.UserId
                    });
            }

            return productModel;
        }

        #endregion
    }
}