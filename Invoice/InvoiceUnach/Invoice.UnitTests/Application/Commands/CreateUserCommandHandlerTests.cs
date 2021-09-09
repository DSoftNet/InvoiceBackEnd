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
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<ILogger<CreateUserCommandHandler>> _logger;
        private readonly Mock<IUnitOfWork> _dbContext;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IMediator> _mediator;
        
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _logger = new Mock<ILogger<CreateUserCommandHandler>>();
            _userRepository = new Mock<IUserRepository>();
            _dbContext = new Mock<IUnitOfWork>();
            _mediator = new Mock<IMediator>();
            _userRepository.Setup(x => x.UnitOfWork)
                .Returns(_dbContext.Object);

            _handler = new CreateUserCommandHandler(_logger.Object, _userRepository.Object, _mediator.Object);
        }
        
        [Fact]
        public async Task Handle_IdentificationIsNotExist_ReturnTrue()
        {
            var command = new CreateUserCommand("value", "value", "value",
                "value", "value","value","value","value",
                "value","value","value","value","value");

            _userRepository.Setup(x => x.GetByIdentification(It.IsAny<string>()))
                .ReturnsAsync(null as User);

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public async Task Handle_IdentificationIsNotExist_AddCalled()
        {
            var command = new CreateUserCommand("value", "value", "value",
                "value", "value","value","value","value",
                "value","value","value","value","value");

            //Act
            bool actual = await _handler.Handle(command, default);

            //Assert
            _userRepository.Verify(x => x.Add(
                It.Is<User>(
                    t => t.FirstName == command.FirstName &&
                         t.SecondName == command.SecondName &&
                         t.FirstLastName == command.FirstLastName &&
                         t.SecondLastName == command.SecondLastName &&
                         t.IdentificationType == command.IdentificationType &&
                         t.Identification == command.Identification &&
                         t.Email == command.Email &&
                         t.Address == command.Address &&
                         t.Phone == command.Phone &&
                         t.CellPhone == command.CellPhone &&
                         t.UserName == command.UserName &&
                         t.Password == command.Password
                )), Times.Once);
        }
        
        [Fact]
        public async Task Handle_IdentificationIsNotExist_SaveEntitiesAsync()
        {
            var command = new CreateUserCommand("value", "value", "value",
                "value", "value","value","value","value",
                "value","value","value","value","value");

            //Act
            await _handler.Handle(command, default);

            //Assert
            _dbContext.Verify(x=>x.SaveEntitiesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        
        [Fact]
        public async Task Handle_IdentificationIsNotExist_ThrowException()
        {
            var command = new CreateUserCommand("value", "value", "value",
                "value", "CODE","value","value","value",
                "value","value","value","value","value");

            var dbUser = new Mock<User>();
            dbUser.Object.SetIdentification("CODE");
            
            _userRepository.Setup(x => x.GetByIdentification(It.IsAny<string>()))
                .ReturnsAsync(dbUser.Object);

            //Act
            //Assert
            await Assert.ThrowsAsync<InvoiceDomainException>(()=> _handler.Handle(command,
                default));
        }
    }
}