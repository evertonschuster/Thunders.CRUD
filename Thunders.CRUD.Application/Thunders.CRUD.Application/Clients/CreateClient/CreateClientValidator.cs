namespace Thunders.CRUD.Application.Clients.CreateClient
{
    public class CreateClientValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be null or whitespace");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email cannot be null or whitespace");

            RuleFor(x => x.Profession)
                .NotEmpty()
                .NotNull()
                .WithMessage("Profession cannot be null or whitespace");
        }
    }
}
