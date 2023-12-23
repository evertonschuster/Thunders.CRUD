﻿using Thunders.CRUD.Domain;

namespace Thunders.CRUD.infrastructure.UnitOfWork
{
    internal class UnitOfWorkEfCore(ThunderContext context) : IUnitOfWork
    {
        private readonly ThunderContext _context = context;

        public void Dispose()
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
