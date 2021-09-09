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

        #region Methods Update

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
                var product = await _productRepository.GetById(productModel.InputProductModel.Id);

                product.SetName(productModel.InputProductModel.Name);
                product.SetDescription(productModel.InputProductModel.Description);
                product.SetCode(productModel.InputProductModel.Code);
                product.SetPrice(productModel.InputProductModel.Price);
                product.SetIsIva(productModel.InputProductModel.IsIva);
                product.SetStock(productModel.InputProductModel.Stock);
                product.SetIsExpiration(productModel.InputProductModel.IsExpiration);
                product.SetExpirationAt(productModel.InputProductModel.ExpirationAt);
                product.SetStatus(productModel.InputProductModel.Status);

                _productRepository.Update(product);
                await _productRepository.UnitOfWork.SaveEntitiesAsync();

                productModel = await GetProducts(productModel.InputProductModel.UserId);

                return await Task.Run(() => View("Index", productModel));
            }
            else
            {
                return await Task.Run(() => View("Index", productModel));
            }
        }

        #endregion

        #region Methods Delete

        public async Task<IActionResult> Delete(Guid productId, Guid userId)
        {
            var product = await _productRepository.GetById(productId);

            _productRepository.Delete(product);
            await _productRepository.UnitOfWork.SaveEntitiesAsync();

            var productModel = await GetProducts(userId);

            return View("Index", productModel);
        }

        #endregion

        #region Methods Create

        public IActionResult LoadFormCreate(Guid userId)
        {
            var productModel = new ProductModel();
            productModel.Option = "Add";
            productModel.UserId = userId;

            return View("Index", productModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product(productModel.InputProductModel.Name,
                    productModel.InputProductModel.Description, productModel.InputProductModel.Code,
                    productModel.InputProductModel.Price, productModel.InputProductModel.IsIva,
                    productModel.InputProductModel.Stock, productModel.InputProductModel.IsExpiration,
                    productModel.InputProductModel.ExpirationAt, productModel.InputProductModel.Status,
                    productModel.UserId);

                _productRepository.Add(product);
                await _productRepository.UnitOfWork.SaveEntitiesAsync();

                productModel = await GetProducts(productModel.UserId);

                return await Task.Run(() => View("Index", productModel));
            }
            else
            {
                return await Task.Run(() => View("Index", productModel));
            }
        }

        #endregion

        #region Private Methods

        private async Task<ProductModel> GetProducts(Guid userId)
        {
            var productModel = new ProductModel();

            productModel.Option = "List";
            productModel.UserId = userId;

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