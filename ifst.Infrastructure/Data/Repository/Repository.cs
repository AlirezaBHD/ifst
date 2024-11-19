using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ifst.API.ifst.Application.Interfaces;



namespace ifst.API.ifst.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task<T> GetByIdAsync(int id) => await _entities.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task AddAsync(T entity) => await _entities.AddAsync(entity);

        public void Remove(T entity) => _entities.Remove(entity);

        public void Update(T entity) => _entities.Update(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _entities.Where(predicate).ToListAsync();
    }
}