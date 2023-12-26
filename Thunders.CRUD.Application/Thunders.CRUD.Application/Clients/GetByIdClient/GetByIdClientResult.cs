using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.Application.Clients.GetByIdClient
{
    public class GetByIdClientResult
    {
        public GetByIdClientResult(Client model)
        {
            Id = model.Id;
            Name = model.Name;
            Email = model.Email;
            Profession = model.Profession;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Profession { get; set; }
    }
}
