using System.Linq.Expressions;
using ifst.API.ifst.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Domain.Common;


namespace ifst.API.ifst.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;
        private readonly string _displayName;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
            _displayName = DisplayNameExtensions.GetDisplayName<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var obj = await _entities.FindAsync(id);
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        public async Task<T> GetFirstOrDefaultAsync()
        {
            var obj = await _entities.FirstOrDefaultAsync();
            // obj.ThrowIfNull(_displayName);
            return obj;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var obj = await _entities.ToListAsync();
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        public async Task AddAsync(T entity) => await _entities.AddAsync(entity);

        public void Remove(T entity) => _entities.Remove(entity);

        public void Update(T entity) => _entities.Update(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var obj = await _entities.Where(predicate).ToListAsync();
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        public async Task<PaginatedResult<T>> GetAllPaginated(
            Expression<Func<T, bool>>? predicate,
            int pageNumber,
            int pageSize)
        {
            IQueryable<T> query = _entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var totalRecords = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items.ThrowIfNull(_displayName);

            return new PaginatedResult<T>
            {
                Items = items,
                TotalCount = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            
        }
    }
}