using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Invoice.UnitTests.Application.Commands
{
    public class CreateItemCatalogCommandHandlerTest
    {
        private readonly Mock<ILogger<CreateItemCatalogCommandHandler>> _logger;
        private readonly Mock<IUnitOfWork> _dbContext;
        private readonly Mock<IItemCatalogRepository> _itemCatalogRepository;
        private readonly Mock<IMediator> _mediator;
        
        private readonly CreateItemCatalogCommandHandler _handler;
        
        public CreateItemCatalogCommandHandlerTest()
        {
            _logger = new Mock<ILogger<CreateItemCatalogCommandHandler>>();
            _itemCatalogRepository = new Mock<IItemCatalogRepository>();
            _dbContext = new Mock<IUnitOfWork>();
            _mediator = new Mock<IMediator>();

            _itemCatalogRepository.Setup(x => x.UnitOfWork)
                .Returns(_dbContext.Object);

            _handler = new CreateItemCatalogCommandHandler(_logger.Object, _itemCatalogRepository.Object, 
                _mediator.Object);
            
        }
         [Fact]
        public async Task Handle_CodeIsNotExist_ReturnTrue()
        {
            var command = new CreateItemCatalogCommand("name", "code", "description",
                "value", true, "codeCatalog");

            _itemCatalogRepository.Setup(x => x.GetByCode(It.IsAny<string>()))
                .ReturnsAsync(null as ItemCatalog);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public async Task Handle_CodeIsNotExist_AddCalled()
        {
            var command = new CreateItemCatalogCommand("name", "code", "description",
                "value", true, "codeCatalog");

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            _itemCatalogRepository.Verify(x => x.Add(
                It.Is<ItemCatalog>(
                    t => t.Name == command.Name &&
                         t.Code == command.Code.ToUpper() &&
                         t.Description == command.Description &&
                         t.Value == command.Value &&
                         t.Status == command.Status &&
                         t.CodeCatalog == command.CodeCatalog
                )), Times.Once);
        }
        
        [Fact]
        public async Task Handle_CodeIsNotExist_SaveEntitiesAsync()
        {
            var command = new CreateItemCatalogCommand("name", "code", "description",
                "value", true, "codeCatalog");

            //Act
            await _handler.Handle(command, default);

            //Assert
           _dbContext.Verify(x=>x.SaveEntitiesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        
        [Fact]
        public async Task Handle_CodeIsNotExist_ThrowException()
        {
            var command = new CreateItemCatalogCommand("name", "CODE", "description",
                "value", true, "codeCatalog");

            var dbItemCatalog = new Mock<ItemCatalog>();
            dbItemCatalog.Object.SetCode("CODE");
            
            _itemCatalogRepository.Setup(x => x.GetByCode(It.IsAny<string>()))
                .ReturnsAsync(dbItemCatalog.Object);

            //Act
            //Assert
            await Assert.ThrowsAsync<InvoiceDomainException>(()=> _handler.Handle(command,
                default));
        }
    }
}