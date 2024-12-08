using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Results;
using ifst.API.ifst.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Application.Extensions;
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
            obj.ThrowIfNull(_displayName);
            return obj;
        }
        
        public async Task<T> GetFirstOrNullAsync()
        {
            var obj = await _entities.FirstOrDefaultAsync();
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
        
         public async Task<PaginatedResult<T>> GetFilteredAndSortedPaginated(
            FilterAndSortPaginatedOptions options)
        {
            
            var filterCriteria = new DynamicFilterCriteria<T>();
            foreach (var filter in options.Filters)
            {
                if (typeof(T).GetProperty(filter.Key) == null)
                {
                    var errors = new List<ValidationFailure>
                    {
                        new ValidationFailure("Invalid Keyword","کلید مورد نظر یافت نشد")
                    };
            
                    throw new ValidationException("Validation Error", errors);
                }
                    
                if (!string.IsNullOrWhiteSpace(filter.Value))
                {
                    filterCriteria.AddFilter(filter.Key, filter.Value!);
                }
            }
                
            var predicate = filterCriteria.GeneratePredicate();
            var query = _entities.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // sortBy Validation
            if (!string.IsNullOrWhiteSpace(options.SortBy))
            {
                var propertyInfo = typeof(T).GetProperty(options.SortBy);
                if (propertyInfo == null)
                {
                    var errors = new List<ValidationFailure>
                    {
                        new ValidationFailure("Invalid Keyword", $"Invalid Keyword '{options.SortBy}' for {typeof(T).Name} ")
                    };

                    throw new ValidationException("Validation Error", errors);

                }

                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.PropertyOrField(parameter, options.SortBy);
                var lambda = Expression.Lambda(property, parameter);

                var methodName = options.IsDescending ? "OrderByDescending" : "OrderBy";
                var orderByMethod = typeof(Queryable).GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), property.Type);

                query = (IQueryable<T>)orderByMethod.Invoke(null, new object[] { query, lambda })!;
            }

            // Pagination
            var totalCount = await query.CountAsync();
            var items = await query.Skip((options.PageNumber - 1) * options.PageSize).Take(options.PageSize).ToListAsync();

            return new PaginatedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = options.PageNumber,
                PageSize = options.PageSize,
            };
        }

        #region Get Relational Objects with include

        public async Task<T> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var obj = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        #endregion
        

    }
}