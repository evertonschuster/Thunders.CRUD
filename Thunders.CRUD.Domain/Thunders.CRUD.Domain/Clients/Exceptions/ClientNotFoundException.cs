﻿using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.Domain.Clients.Exceptions
{
    public sealed class ClientNotFoundException : BusinessExeption
    {
        public ClientNotFoundException() : base("Client not found.", string.Empty)
        {
        }
    }
}
