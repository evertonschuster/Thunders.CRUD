using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunders.CRUD.Application.Todos.UpdateTodo;
using Thunders.CRUD.Domain.Clients.Models;
using Thunders.CRUD.Domain.Clients.Repositories;

namespace Thunders.CRUD.Application.Test.Todos
{
    public class UpdateTodoValidatorTest
    {
        [Fact]
        public void Validate_ShouldReturnTrue_WhenTitleAndDescriptionAreNotEmptyAndClientExists()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var validator = new UpdateTodoValidator(clientRepository);

            var client = new Client(Guid.NewGuid(), "Everton", "Everton.schuster@gmail.com", "Developer");
            clientRepository.GetById(client.Id).Returns(client);
            var command = new UpdateTodoCommand(Guid.NewGuid(), "Test Title", "Test Description", client.Id);


            var result = validator.Validate(command);


            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WhenTitleOrDescriptionIsEmptyOrClientDoesNotExist()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var validator = new UpdateTodoValidator(clientRepository);

            var command = new UpdateTodoCommand(Guid.NewGuid(), "Title", "Test Description", Guid.NewGuid());


            var result = validator.Validate(command);


            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validate_ShouldReturnTrue_WhenTitleAndDescriptionAreUnderMaxLength()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var validator = new UpdateTodoValidator(clientRepository);

            var client = new Client(Guid.NewGuid(), "Everton", "Everton.schuster@gmail.com", "Developer");
            clientRepository.GetById(client.Id).Returns(client);

            var command = new UpdateTodoCommand(Guid.NewGuid(), new string('a', 100), new string('a', 100), client.Id);


            var result = validator.Validate(command);


            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WhenTitleOrDescriptionExceedsMaxLength()
        {
            var clientRepository = Substitute.For<IClientRepository>();
            var validator = new UpdateTodoValidator(clientRepository);

            var client = new Client(Guid.NewGuid(), "Everton", "Everton.schuster@gmail.com", "Developer");
            clientRepository.GetById(client.Id).Returns(client);

            var command = new UpdateTodoCommand(Guid.NewGuid(), new string('a', 101), new string('a', 101), client.Id);


            var result = validator.Validate(command);


            result.IsValid.Should().BeFalse();
        }
    }
}
