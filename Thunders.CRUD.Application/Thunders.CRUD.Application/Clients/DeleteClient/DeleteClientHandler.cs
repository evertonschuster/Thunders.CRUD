using Thunders.CRUD.Domain;
using Thunders.CRUD.Domain.Clients.Exceptions;
using Thunders.CRUD.Domain.Clients.Repository;

namespace Thunders.CRUD.Application.Clients.DeleteClient
{
    public class DeleteClientHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientRepository clientRepository = clientRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var model = clientRepository.GetById(request.Id) ?? throw new ClientNotFoundException();

            clientRepository.Delete(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
