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
            
            return View("Index", productModel);
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
                    new ProductModel.InputProduct(product.Id, product.Name, product.Description, product.Code,
                        product.Price, product.IsIva, product.Stock, product.IsExpiration, product.ExpirationAt,
                        product.Status, product.UserId));
            }

            return productModel;
        }

        #endregion
    }
}