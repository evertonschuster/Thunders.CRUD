namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public class NameNullOrWhitespaceException : BusinessExeption
    {
        public NameNullOrWhitespaceException(string property) : base("Name cannot be null or whitespace.", property)
        {
        }
    }
}
