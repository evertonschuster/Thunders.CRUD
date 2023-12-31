﻿using Thunders.CRUD.Domain.Clients.Repositories;
using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Application.Clients.CreateClient
{
    public sealed class CreateClientHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateClientCommand, CreateClientResult>
    {
        private readonly IClientRepository clientRepository = clientRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task<CreateClientResult> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToModel();

            clientRepository.Add(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.FromResult(new CreateClientResult(model.Id));
        }
    }
}
