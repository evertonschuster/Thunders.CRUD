namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public class NameNullOrWhitespaceException : BusinessExeption
    {
        public NameNullOrWhitespaceException(string property) : base("Nome cannot be null or whitespace.", property)
        {
        }
    }
}
