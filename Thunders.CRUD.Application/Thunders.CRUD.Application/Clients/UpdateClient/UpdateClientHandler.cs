﻿using Thunders.CRUD.Domain.Clients.Exceptions;
using Thunders.CRUD.Domain.Clients.Repositories;
using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Application.Clients.UpdateClient
{
    public sealed class UpdateClientHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateClientCommand, UpdateClientResult>
    {
        private readonly IClientRepository clientRepository = clientRepository;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public Task<UpdateClientResult> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var model = clientRepository.GetById(request.Id) ?? throw new ClientNotFoundException();

            model.Update(request.Email, request.Profession);
            clientRepository.Update(model);
            cancellationToken.ThrowIfCancellationRequested();
            unitOfWork.SaveChanges();

            return Task.FromResult(new UpdateClientResult(model));
        }
    }
}
