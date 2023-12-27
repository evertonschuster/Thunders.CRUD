using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.infrastructure.UnitOfWork
{
    internal sealed class UnitOfWorkEfCore(ThunderContext context) : IUnitOfWork
    {
        private readonly ThunderContext _context = context;

        public void Dispose()
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
