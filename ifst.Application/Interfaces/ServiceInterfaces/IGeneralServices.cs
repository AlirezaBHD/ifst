namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IGeneralServices<TEntity> where TEntity : class
{
    Task<TEntity> AddEntityAsync<TDto>(TDto dto);

    Task UpdateEntityAsync<TDto>(
        TEntity entity,
        TDto updateDto,
        Dictionary<string, IFormFile> files)
        where TDto : class;
}