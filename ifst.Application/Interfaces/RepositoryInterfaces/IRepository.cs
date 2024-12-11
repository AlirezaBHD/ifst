using System.Linq.Expressions;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
     #region Add Async

        Task AddAsync(T entity);

        #endregion

        #region Remove

        void Remove(T entity);

        #endregion

        #region Update

        void Update(T entity);

        #endregion

        #region Save Async
        Task SaveAsync();
        #endregion

        #region Get By Id Async

        Task<T> GetByIdAsync(int id);

        #endregion

        #region Get All Async

        Task<IEnumerable<T>> GetAllAsync();

        #endregion


        //---

        


        #region Get FirstOrDefault Async

        Task<T> GetFirstOrDefaultAsync();

        #endregion


        #region Get First Or Null Async

        Task<T> GetFirstOrNullAsync();

        #endregion

        // GetLimited

        //---

        #region Get Filtered And Sorted Paginated

        Task<PaginatedResult<TDto>> GetFilteredAndSortedPaginated<TDto>(
            FilterAndSortPaginatedOptions options,
            Expression<Func<T, bool>>? externalPredicate = null);

        #endregion

        #region Get All Paginated

        Task<PaginatedResult<TDto>> GetAllPaginated<TDto>(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? predicate = null);

        #endregion
        
        #region Get Relational Objects with include Limited

        Task<TDto> GetByIdAsyncLimited<TDto>(int id,
            Expression<Func<T, bool>>? condition = null, params Expression<Func<T, object>>[] includes);

        #endregion
        
        #region Get All Async

        Task<IEnumerable<TDto>> GetAllAsyncLimited<TDto>(
            Expression<Func<T, bool>>? externalPredicate = null);

        #endregion

        #region Find Async

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        #endregion


    }
}