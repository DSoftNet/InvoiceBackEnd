using System;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Invoice.UnitTests.Application.Commands
{
    public class CreateCatalogCommandHandlerTests
    {
        private readonly Mock<ILogger<CreateCatalogCommandHandler>> _logger;
        private readonly Mock<ICatalogRepository> _catalogRepository;
        private readonly Mock<IUnitOfWork> _dbContext;

        private readonly CreateCatalogCommandHandler _handler;

        public CreateCatalogCommandHandlerTests()
        {
            _logger = new Mock<ILogger<CreateCatalogCommandHandler>>();
            _catalogRepository = new Mock<ICatalogRepository>();
            _dbContext = new Mock<IUnitOfWork>();
            _catalogRepository.Setup(x => x.UnitOfWork)
                .Returns(_dbContext.Object);

            _handler = new CreateCatalogCommandHandler(_logger.Object, _catalogRepository.Object);
        }

        [Fact]
        public async Task Handle_CodeIsNotExist_ReturnTrue()
        {
            var command = new CreateCatalogCommand("name", "code", "description",
                "value", true);

            _catalogRepository.Setup(x => x.GetByCode(It.IsAny<string>()))
                .ReturnsAsync(null as Catalog);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public async Task Handle_CodeIsNotExist_AddCalled()
        {
            var command = new CreateCatalogCommand("name", "code", "description",
                "value", true);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            _catalogRepository.Verify(x => x.Add(
                It.Is<Catalog>(
                    t => t.Name == command.Name &&
                         t.Code == command.Code.ToUpper() &&
                         t.Description == command.Description &&
                         t.Value == command.Value &&
                         t.Status == command.Status
                )), Times.Once);
        }
        
        [Fact]
        public async Task Handle_CodeIsNotExist_SaveEntitiesAsync()
        {
            var command = new CreateCatalogCommand("name", "code", "description",
                "value", true);

            //Act
            await _handler.Handle(command, default);

            //Assert
           _dbContext.Verify(x=>x.SaveEntitiesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        
        [Fact]
        public async Task Handle_CodeIsNotExist_ThrowException()
        {
            var command = new CreateCatalogCommand("name", "CODE", "description",
                "value", true);

            var dbCatalog = new Mock<Catalog>();
            dbCatalog.Object.SetCode("CODE");
            
            _catalogRepository.Setup(x => x.GetByCode(It.IsAny<string>()))
                .ReturnsAsync(dbCatalog.Object);

            //Act
            //Assert
            await Assert.ThrowsAsync<InvoiceDomainException>(()=> _handler.Handle(command,
                default));
        }
    }
}