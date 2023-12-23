namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public class EmailNullOrWhitespaceException(string? property) : BusinessExeption("Email cannot be null or whitespace.", property)
    {
    }
}
