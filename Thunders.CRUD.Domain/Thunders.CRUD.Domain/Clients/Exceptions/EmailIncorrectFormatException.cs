namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public class EmailIncorrectFormatException(string? property) : BusinessExeption("Email is not in a correct format.", property)
    {
    }
}
