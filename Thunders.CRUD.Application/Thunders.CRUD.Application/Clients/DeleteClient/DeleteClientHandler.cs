using Thunders.CRUD.Domain.Clients.Exceptions;
using Thunders.CRUD.Domain.Clients.Repositories;
using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Application.Clients.DeleteClient
{
    public class DeleteClientHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientRepository clientRepository = clientRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var model = clientRepository.GetById(request.Id) ?? throw new ClientNotFoundException();

            model.Delete();
            clientRepository.Update(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
