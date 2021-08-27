using System;
using System.Threading;
using System.Threading.Tasks;
using Invoice.Application.Commands;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Invoice.Domain.Services.Validations;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Invoice.UnitTests.Application.Commands
{
    public class CreateClientCommandHandlerTests
    {
        private readonly Mock<ILogger<CreateClientCommandHandler>> _logger;
        private readonly Mock<IUnitOfWork> _dbContext;
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly Mock<IMediator> _mediator;

        private readonly CreateClientCommandHandler _handler;

        public CreateClientCommandHandlerTests()
        {
            _logger = new Mock<ILogger<CreateClientCommandHandler>>();
            _clientRepository = new Mock<IClientRepository>();
            _dbContext = new Mock<IUnitOfWork>();
            _mediator = new Mock<IMediator>();

            _clientRepository.Setup(x => x.UnitOfWork)
                .Returns(_dbContext.Object);

            _handler = new CreateClientCommandHandler(_logger.Object, _clientRepository.Object, _mediator.Object);
        }

        [Fact]
        public async Task Handle_EmailIsNotExist_ReturnTrue()
        {
            var command = new CreateClientCommand("firstname", "secondName", "firstLastName",
                "secondLastName", "identificationType", "identification", "email",
                "address", "phone", "cellphone", true, DateTime.Now, DateTime.Now,
                Guid.NewGuid());

            _clientRepository.Setup(x => x.Get(It.IsAny<string>()))
                .ReturnsAsync(null as Client);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public async Task Handle_EmailIsNotExist_AddCalled()
        {
            var command = new CreateClientCommand("firstname", "secondName", "firstLastName",
                "secondLastName", "identificationType", "identification", "email",
                "address", "phone", "cellphone", true, DateTime.Now, DateTime.Now,
                Guid.NewGuid());

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            _clientRepository.Verify(x => x.Add(
                It.IsAny<Client>()), Times.Once);
        }

        [Fact]
        public async Task Handle_EmailIsNotExist_SaveEntitiesAsync()
        {
            var command = new CreateClientCommand("firstname", "secondName", "firstLastName",
                "secondLastName", "identificationType", "identification", "email",
                "address", "phone", "cellphone", true, DateTime.Now, DateTime.Now,
                Guid.NewGuid());

            //Act
            await _handler.Handle(command, default);

            //Assert
            _dbContext.Verify(x => x.SaveEntitiesAsync(It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task Handle_EmailExist_ThrowException()
        {
            var command = new CreateClientCommand("firstname", "secondName", "firstLastName",
                "secondLastName", "identificationType", "identification", "email",
                "address", "phone", "cellphone", true, DateTime.Now, DateTime.Now,
                Guid.NewGuid());

            var dbClient = new Mock<Client>();
            dbClient.Object.SetEmail("email");

            _clientRepository.Setup(x => x.Get(It.IsAny<string>()))
                .ReturnsAsync(dbClient.Object);

            //Assert
            await Assert.ThrowsAsync<InvoiceDomainException>(() => _handler.Handle(command,
                default));
        }
    }
}