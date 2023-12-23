namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public class ClientNotFoundException : BusinessExeption
    {
        public ClientNotFoundException() : base("Client not found.", string.Empty)
        {
        }
    }
}
