using System.Linq.Expressions;
using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;


public class GeneralServices<TEntity> : IGeneralServices<TEntity>
    where TEntity : class
{
    #region Injection

    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    private readonly FileService _fileService;

    public GeneralServices(IRepository<TEntity> repository, IMapper mapper, FileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    #endregion
    

    #region Update Entity

    public async Task UpdateEntityAsync<TDto>(
        TEntity entity,
        TDto updateDto,
        Dictionary<string, IFormFile> files = null)
        where TDto : class
    {
        entity = _mapper.Map(updateDto, entity);

        if (files != null && files.Any())
        {
            foreach (var file in files)
            {
                if (file.Value != null)
                {
                    var filePath = await _fileService.SaveFileAsync(file.Value, typeof(TEntity).Name);

                    var property = typeof(TEntity).GetProperty(file.Key);
                    if (property != null && property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, filePath);
                    }
                }
            }
        }

        _repository.Update(entity);
        await _repository.SaveAsync();
    }

    #endregion

    
    #region Get Object By Id

    public async Task<TDto> GetObjectById<TDto>(int id)
    {
        var dtoObject = await _repository.GetByIdAsyncLimited<TDto>(id);
        return dtoObject;
    }

    #endregion
    
    
    #region Get All Objects

    public async Task<IEnumerable<TDto>> GetAllObjects<TDto>(Expression<Func<TEntity, bool>>? externalPredicate = null, Expression<Func<TEntity, object>>[] includes = null)
    {
        var dtoObject = await _repository.GetAllAsyncLimited<TDto>(externalPredicate, includes);
        return dtoObject;
    }

    #endregion
}