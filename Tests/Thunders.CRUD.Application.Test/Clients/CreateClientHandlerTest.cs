using Thunders.CRUD.Application.Clients.CreateClient;
using Thunders.CRUD.Domain;
using Thunders.CRUD.Domain.Clients.Exceptions;
using Thunders.CRUD.Domain.Clients.Models;
using Thunders.CRUD.Domain.Clients.Repository;

namespace Thunders.CRUD.Application.Test.Clients
{
    public class CreateClientHandlerTest
    {

        [Fact]
        public async Task Should_CreateClient_When_ValidCommandIsProvided()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var command = new CreateClientCommand("Valid Name", "test@example.com", "Developer");
            var handler = new CreateClientHandler(clientRepository, unitOfWork);


            var result = await handler.Handle(command, CancellationToken.None);


            result.Id.Should().NotBeEmpty();
            clientRepository.Received(1).Add(Arg.Any<Client>());
            unitOfWork.Received(1).SaveChanges();
        }

        [Fact]
        public async Task Should_CreateClient_When_EmptyNameCommandIsProvided()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var command = new CreateClientCommand("", "test@example.com", "Developer");
            var handler = new CreateClientHandler(clientRepository, unitOfWork);


            Func<Task> act = async () =>
            {
                await handler.Handle(command, CancellationToken.None); ;
            };


            await act.Should().ThrowAsync<NameNullOrWhitespaceException>();
        }

        [Fact]
        public async Task Should_CreateClient_When_EmptyEmailCommandIsProvided()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var command = new CreateClientCommand("Valid Name", "", "Developer");
            var handler = new CreateClientHandler(clientRepository, unitOfWork);


            Func<Task> act = async () =>
            {
                await handler.Handle(command, CancellationToken.None); ;
            };


            await act.Should().ThrowAsync<EmailNullOrWhitespaceException>();
        }
    }
}
