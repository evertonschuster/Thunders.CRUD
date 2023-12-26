using Microsoft.EntityFrameworkCore;
using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.infrastructure
{
    internal class Repository<T>(ThunderContext context) where T : Entity
    {
        private readonly ThunderContext _context = context;

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T? GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}