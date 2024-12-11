namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IGenericService<TEntity> where TEntity : class
{
    Task<TEntity> AddEntityAsync<TDto>(TDto dto);

    Task UpdateEntityAsync<TDto>(
        TEntity entity,
        TDto updateDto,
        Dictionary<string,IFormFile> files)
        where TDto : class;
}