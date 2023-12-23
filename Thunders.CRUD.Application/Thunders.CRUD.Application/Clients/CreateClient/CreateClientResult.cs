namespace Thunders.CRUD.Application.Clients.CreateClient
{
    public class CreateClientResult
    {
        public CreateClientResult(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }

    }
}
