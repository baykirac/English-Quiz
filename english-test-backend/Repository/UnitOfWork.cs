using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<T>(_context);
                _repositories[type] = repository;
            }

            return (IRepository<T>)_repositories[type];
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}
