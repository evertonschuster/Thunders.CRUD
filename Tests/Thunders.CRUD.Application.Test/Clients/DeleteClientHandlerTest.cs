using Thunders.CRUD.Application.Clients.DeleteClient;
using Thunders.CRUD.Domain;
using Thunders.CRUD.Domain.Clients.Exceptions;
using Thunders.CRUD.Domain.Clients.Models;
using Thunders.CRUD.Domain.Clients.Repository;

namespace Thunders.CRUD.Application.Test.Clients
{
    public class DeleteClientHandlerTest
    {
        [Fact]
        public async Task Should_DeleteClient_When_ValidCommandIsProvided()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            clientRepository.GetById(Arg.Any<Guid>()).Returns(new Client("Test", "Test@teste.com", "Test"));
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var command = new DeleteClientCommand(Guid.NewGuid());
            var handler = new DeleteClientHandler(clientRepository, unitOfWork);


            await handler.Handle(command, CancellationToken.None);


            clientRepository.Received(1).GetById(Arg.Any<Guid>());
            clientRepository.Received(1).Delete(Arg.Any<Client>());
            unitOfWork.Received(1).SaveChanges();
        }

        [Fact]
        public async Task Should_ThrowException_When_ClientNotFound()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();

            var command = new DeleteClientCommand(Guid.NewGuid());
            var handler = new DeleteClientHandler(clientRepository, unitOfWork);


            Func<Task> act = async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            };


            await act.Should().ThrowAsync<ClientNotFoundException>();
            clientRepository.Received(1).GetById(Arg.Any<Guid>());
            clientRepository.Received(0).Delete(Arg.Any<Client>());
            unitOfWork.Received(0).SaveChanges();
        }
    }
}
