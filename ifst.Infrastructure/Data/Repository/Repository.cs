using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        #region Injections

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;
        private readonly string _displayName;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _entities = context.Set<T>();
            _displayName = DisplayNameExtensions.GetDisplayName<T>();
            _mapper = mapper;
        }

        #endregion

        #region Add Async

        public async Task AddAsync(T entity) => await _entities.AddAsync(entity);

        #endregion

        #region Remove

        public void Remove(T entity) => _entities.Remove(entity);

        #endregion

        #region Update

        public void Update(T entity) => _entities.Update(entity);

        #endregion

        #region Save Async

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Get By Id Async

        public async Task<T> GetByIdAsync(int id)
        {
            var obj = await _entities.FindAsync(id);
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        #endregion

        #region Get All Async

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _entities.ToListAsync();
            result.ThrowIfNull(_displayName);
            return result;
        }

        #endregion
        
        #region Get by Id Async Limited

        public async Task<T> GetByIdAsyncLimited(int id, Expression<Func<T, bool>>? predicate = null)
        {
            var obj = await _entities.FindAsync(id);
            obj.ThrowIfNull(_displayName);
            return obj;
        }


        #endregion
        
        #region Get Filtered And Sorted Paginated

        public async Task<PaginatedResult<TDto>> GetFilteredAndSortedPaginated<TDto>(
            FilterAndSortPaginatedOptions options,
            Expression<Func<T, bool>>? externalPredicate = null)
        {
            // ساختن پردیکت داخلی
            var filterCriteria = new DynamicFilterCriteria<T>();
            foreach (var filter in options.Filters)
            {
                if (typeof(T).GetProperty(filter.Key) == null)
                {
                    var errors = new List<ValidationFailure>
                    {
                        new ValidationFailure("Invalid Keyword", "کلید مورد نظر یافت نشد")
                    };

                    throw new ValidationException("Validation Error", errors);
                }

                if (!string.IsNullOrWhiteSpace(filter.Value))
                {
                    filterCriteria.AddFilter(filter.Key, filter.Value!);
                }
            }

            var internalPredicate = filterCriteria.GeneratePredicate();

            // شروع ساخت query
            var query = _entities.AsQueryable();

            // ترکیب پردیکت‌ها (داخلی و خارجی)
            if (internalPredicate != null && externalPredicate != null)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var body = Expression.AndAlso(
                    Expression.Invoke(internalPredicate, parameter),
                    Expression.Invoke(externalPredicate, parameter)
                );

                var combinedPredicate = Expression.Lambda<Func<T, bool>>(body, parameter);
                query = query.Where(combinedPredicate);
            }
            else if (internalPredicate != null)
            {
                query = query.Where(internalPredicate);
            }
            else if (externalPredicate != null)
            {
                query = query.Where(externalPredicate);
            }

            // Validation و اعمال SortBy
            if (!string.IsNullOrWhiteSpace(options.SortBy))
            {
                var propertyInfo = typeof(T).GetProperty(options.SortBy);
                if (propertyInfo == null)
                {
                    var errors = new List<ValidationFailure>
                    {
                        new ValidationFailure("Invalid Keyword",
                            $"Invalid Keyword '{options.SortBy}' for {typeof(T).Name} ")
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

            // نگاشت به TDto با ProjectTo
            var items = await query
                .Skip((options.PageNumber - 1) * options.PageSize)
                .Take(options.PageSize)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PaginatedResult<TDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = options.PageNumber,
                PageSize = options.PageSize,
            };
        }

        #endregion

        #region Get All Paginated

        public async Task<PaginatedResult<TDto>> GetAllPaginated<TDto>(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var dtoQuery = query.ProjectTo<TDto>(_mapper.ConfigurationProvider);

            var totalRecords = await dtoQuery.CountAsync();
            var items = await dtoQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items.ThrowIfNull(_displayName);

            return new PaginatedResult<TDto>
            {
                Items = items,
                TotalCount = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        #endregion

        #region Get Relational Objects with include

        public async Task<TDto> GetByIdAsyncLimited<TDto>(int id,
            Expression<Func<T, bool>>? condition = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (condition != null)
            {
                query = query.Where(condition);
            }


            var obj = await query.ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        #endregion

        #region Get All Async

        public async Task<IEnumerable<TDto>> GetAllAsyncLimited<TDto>(
            Expression<Func<T, bool>>? externalPredicate = null)
        {
            var query = _entities.AsQueryable();

            if (externalPredicate != null)
            {
                query = query.Where(externalPredicate);
            }

            var result = await query.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.ThrowIfNull(_displayName);
            return result;
        }

        #endregion

        #region Find Async

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var obj = await _entities.Where(predicate).ToListAsync();
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        #endregion
        
        //ContactInformation
        #region Get FirstOrDefault Async

        public async Task<T> GetFirstOrDefaultAsync()
        {
            var obj = await _entities.FirstOrDefaultAsync();
            obj.ThrowIfNull(_displayName);
            return obj;
        }

        #endregion

        #region Get First Or Null Async

        public async Task<T> GetFirstOrNullAsync()
        {
            var obj = await _entities.FirstOrDefaultAsync();
            return obj;
        }

        #endregion

    }
}