using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.Application.Clients.CreateClient
{
    public record CreateClientCommand : IRequest<CreateClientResult>
    {
        public CreateClientCommand()
        {
            Name = string.Empty;
            Email = string.Empty;
            Profession = string.Empty;
        }

        public CreateClientCommand(string name, string email, string profession)
        {
            Name = name;
            Email = email;
            Profession = profession;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Profession { get; set; }

        public Client ToModel()
        {
            return Client.Create(Name, Email, Profession);
        }
    }
}
