using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public sealed class EmailNullOrWhitespaceException(string? property) : BusinessExeption("Email cannot be null or whitespace.", property)
    {
    }
}
