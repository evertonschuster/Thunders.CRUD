using Thunders.CRUD.Domain.Clients.Exceptions;
using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.Domain.Test.Clients
{
    public class NameTest
    {
        [Fact]
        public void Should_ThrowException_When_NameIsNull()
        {
            Assert.Throws<NameNullOrWhitespaceException>(() => new Name(null!));
        }

        [Fact]
        public void Should_ThrowException_When_NameIsEmpty()
        {
            Assert.Throws<NameNullOrWhitespaceException>(() => new Name(string.Empty));
        }

        [Fact]
        public void Should_CreateName_When_ValidNameIsProvided()
        {
            var name = new Name("Valid Name");
            Assert.Equal("Valid Name", name.Value);
        }
    }
}
