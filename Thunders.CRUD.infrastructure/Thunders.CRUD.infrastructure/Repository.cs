using Microsoft.EntityFrameworkCore;
using Thunders.CRUD.Domain.Commoms;

namespace Thunders.CRUD.infrastructure
{
    internal class Repository<T>(ThunderContext context) where T : Entity
    {
        private readonly ThunderContext _context = context;

        public T? GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
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