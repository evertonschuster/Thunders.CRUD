namespace Thunders.CRUD.Application.Clients.UpdateClient
{
    public record UpdateClientCommand : IRequest<UpdateClientResult>
    {
        public UpdateClientCommand()
        {
            Email = string.Empty;
            Profession = string.Empty;
        }

        public UpdateClientCommand(Guid id, string email, string profession)
        {
            Id = id;
            Email = email;
            Profession = profession;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Profession { get; set; }
    }
}
