using Thunders.CRUD.Domain.Clients.Repositories;

namespace Thunders.CRUD.Application.Todos.CreateTodo
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
    {
        private readonly IClientRepository clientRepository;

        public CreateTodoValidator(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title cannot be null or whitespace");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Description cannot be null or whitespace");

            RuleFor(x => x.ClientId)
                .Must(ClientExists)
                .WithMessage("Must informa a valid client");
        }

        public bool ClientExists(Guid? clientId)
        {
            if (clientId == null)
                return true;

            var client = clientRepository.GetById(clientId.Value);

            return client != null;
        }
    }
}
