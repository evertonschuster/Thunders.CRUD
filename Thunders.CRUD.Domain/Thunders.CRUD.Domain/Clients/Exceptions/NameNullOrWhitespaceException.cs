using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public sealed class NameNullOrWhitespaceException : BusinessExeption
    {
        public NameNullOrWhitespaceException(string property) : base("Name cannot be null or whitespace.", property)
        {
        }
    }
}
