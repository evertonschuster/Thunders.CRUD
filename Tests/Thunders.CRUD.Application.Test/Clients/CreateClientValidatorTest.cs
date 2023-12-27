using FluentValidation.TestHelper;
using Thunders.CRUD.Application.Clients.CreateClient;

namespace Thunders.CRUD.Application.Test.Clients
{
    public class CreateClientValidatorTest
    {
        [Fact]
        public void Handle_Should_HaveError_When_NameIsNull()
        {
            var validator = new CreateClientValidator();
            var comamnd = new CreateClientCommand();


            var result = validator.TestValidate(comamnd);


            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_NotHaveError_When_NameIsNotNull()
        {
            var validator = new CreateClientValidator();
            var comamnd = new CreateClientCommand("Everton", "Everton@gmail.com", "Developer");


            var result = validator.TestValidate(comamnd);


            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_HaveError_When_EmailIsNull()
        {
            var validator = new CreateClientValidator();
            var comamnd = new CreateClientCommand();


            var result = validator.TestValidate(comamnd);


            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_NotHaveError_When_EmailIsNotNull()
        {
            var validator = new CreateClientValidator();
            var comamnd = new CreateClientCommand("Everton", "Everton@gmail.com", "Developer");


            var result = validator.TestValidate(comamnd);


            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_HaveError_When_ProfessionIsNull()
        {
            var validator = new CreateClientValidator();
            var comamnd = new CreateClientCommand();


            var result = validator.TestValidate(comamnd);


            result.ShouldHaveValidationErrorFor(x => x.Profession);
        }

        [Fact]
        public void Should_NotHaveError_When_ProfessionIsNotNull()
        {
            var validator = new CreateClientValidator();
            var comamnd = new CreateClientCommand("Everton", "Everton@gmail.com", "Developer");


            var result = validator.TestValidate(comamnd);


            result.ShouldNotHaveValidationErrorFor(x => x.Profession);
        }
    }
}
