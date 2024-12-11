using System.Linq.Expressions;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstOrDefaultAsync();

        Task<T> GetFirstOrNullAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<PaginatedResult<T>> GetAllPaginated(
            Expression<Func<T, bool>>? predicate,
            int pageNumber,
            int pageSize);

        Task<PaginatedResult<T>> GetFilteredAndSortedPaginated(
            FilterAndSortPaginatedOptions options);

        Task<T> GetByIdWithIncludesAsync(int id,
            Expression<Func<T, bool>> condition = null, params Expression<Func<T, object>>[] includes);

        Task SaveAsync();


    }
}