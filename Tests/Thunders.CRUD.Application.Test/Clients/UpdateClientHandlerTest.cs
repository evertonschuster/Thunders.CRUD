using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Thunders.CRUD.Application.Clients.UpdateClient;
using Thunders.CRUD.Domain.Clients.Models;
using Thunders.CRUD.Domain.Clients.Repository;
using Thunders.CRUD.Domain;
using Thunders.CRUD.Application.Clients.DeleteClient;
using Thunders.CRUD.Domain.Clients.Exceptions;

namespace Thunders.CRUD.Application.Test.Clients
{
    public class UpdateClientHandlerTest
    {
        [Fact]
        public async Task Should_UpdateClient_When_ValidCommandIsProvided()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var handler = new UpdateClientHandler(clientRepository, unitOfWork);
            var command = new UpdateClientCommand(Guid.NewGuid(), "test@example.com", "Developer");
            var client = new Client(command.Id, "Everton", "everton@gmail.com", "Dev");


            clientRepository.GetById(command.Id).Returns(client);
            var result = await handler.Handle(command, CancellationToken.None);



            clientRepository.Received(1).GetById(command.Id);
            clientRepository.Received(1).Update(client);
            unitOfWork.Received(1).SaveChanges();
            result.Should().NotBeNull();
            result.Id.Should().Be(command.Id);
            result.Email.Should().Be(command.Email);
            result.Profession.Should().Be(command.Profession);
        }

        [Fact]
        public async Task Should_ThrowException_When_ClientNotFound()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var handler = new UpdateClientHandler(clientRepository, unitOfWork);
            var command = new UpdateClientCommand(Guid.NewGuid(), "test@example.com", "Developer");


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
