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
    public class CreateSubsidiaryCommandHandlerTests
    {
        private readonly Mock<ILogger<CreateSubsidiaryCommandHandler>> _logger;
        private readonly Mock<ISubsidiaryRepository> _subsidiaryRepository;
        private readonly Mock<IUnitOfWork> _dbContext;

        private readonly CreateSubsidiaryCommandHandler _handler;

        public CreateSubsidiaryCommandHandlerTests()
        {
            _logger = new Mock<ILogger<CreateSubsidiaryCommandHandler>>();
            _subsidiaryRepository = new Mock<ISubsidiaryRepository>();
            _dbContext = new Mock<IUnitOfWork>();
            _subsidiaryRepository.Setup(expression:x => x.UnitOfWork)
                .Returns(_dbContext.Object);

            _handler = new CreateSubsidiaryCommandHandler(_logger.Object, _subsidiaryRepository.Object);
        }
        
        [Fact]
        public async Task Handle_AddressIsNotExist_ReturnTrue()
        {
            var command = new CreateSubsidiaryCommand("name", "address", "description",
                "value", Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695"));

            _subsidiaryRepository.Setup(x => x.GetByCode(It.IsAny<string>()))
                .ReturnsAsync(null as Subsidiary);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public async Task Handle_AddressIsNotExist_AddCalled()
        {
            var command = new CreateSubsidiaryCommand("name", "address", "description",
                "value", Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695"));

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            _subsidiaryRepository.Verify(x => x.Add(
                It.Is<Subsidiary>(
                    t => t.Name == command.Name &&
                         t.Address == command.Address &&
                         t.Phone1 == command.Phone1 &&
                         t.Phone2 == command.Phone2 &&
                         t.UserId == command.UserId
                )), Times.Once);
        }
        
        [Fact]
        public async Task Handle_CodeIsNotExist_SaveEntitiesAsync()
        {
            var command = new CreateSubsidiaryCommand("name", "address", "description",
                "value", Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695"));
            //Act
            await _handler.Handle(command, default);

            //Assert
            _dbContext.Verify(x=>x.SaveEntitiesAsync(It.IsAny<CancellationToken>()), 
                Times.Once);
        }
        
        [Fact]
        public async Task Handle_UserIdIsNotExist_ReturnTrue()
        {
            var command = new CreateSubsidiaryCommand("name", "address", "description",
                "value", Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695"));

            _subsidiaryRepository.Setup(x => x.GetByCode(It.IsAny<string>()))
                .ReturnsAsync(null as Subsidiary);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public async Task Handle_UserIdIsNotExist_AddCalled()
        {
            var command = new CreateSubsidiaryCommand("name", "address", "description",
                "value", Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695"));

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            _subsidiaryRepository.Verify(x => x.Add(
                It.Is<Subsidiary>(
                    t => t.Name == command.Name &&
                         t.Address == command.Address &&
                         t.Phone1 == command.Phone1 &&
                         t.Phone2 == command.Phone2 &&
                         t.UserId == command.UserId
                )), Times.Once);
        }
        
        [Fact]
        public async Task Handle_UserIdIsNotExist_SaveEntitiesAsync()
        {
            var command = new CreateSubsidiaryCommand("name", "address", "description",
                "value", Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695"));
            //Act
            await _handler.Handle(command, default);

            //Assert
            _dbContext.Verify(x=>x.SaveEntitiesAsync(It.IsAny<CancellationToken>()), 
                Times.Once);
        }
    }
}