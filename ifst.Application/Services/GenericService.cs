using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class GenericService<TEntity> : IGenericService<TEntity>
    where TEntity : class
{
    #region Injection

    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    private readonly FileService _fileService;

    public GenericService(IRepository<TEntity> repository, IMapper mapper, FileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    #endregion
    

    #region Add Entity Async

    public async Task<TEntity> AddEntityAsync<TDto>(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
        await _repository.SaveAsync();
        return entity;
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
                    // ذخیره فایل (متود سرویس فایل را صدا می‌زنید)
                    var filePath = await _fileService.SaveFileAsync(file.Value, typeof(TEntity).Name);

                    // فایل را به موجودیت اضافه کنید
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
}