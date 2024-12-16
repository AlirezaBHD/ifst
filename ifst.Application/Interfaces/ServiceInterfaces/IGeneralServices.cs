using System.Linq.Expressions;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IGeneralServices<TEntity> where TEntity : class
{
    Task UpdateEntityAsync<TDto>(
        TEntity entity,
        TDto updateDto,
        Dictionary<string, IFormFile> files= null)
        where TDto : class;


    Task<TDto> GetObjectById<TDto>(int id);

    Task<IEnumerable<TDto>> GetAllObjects<TDto>(Expression<Func<TEntity, bool>>? externalPredicate = null,
        Expression<Func<TEntity, object>>[] includes = null);

}