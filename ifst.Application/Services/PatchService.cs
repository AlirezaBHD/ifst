using AutoMapper;
using FluentValidation;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Common;
using ifst.API.ifst.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Services;

public class PatchService<T, TDto> : IPatchService<T, TDto>
    where T : class
    where TDto : class
{
    private readonly IRepository<T> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<TDto> _validator;


    public PatchService(IRepository<T> repository, IMapper mapper, IValidator<TDto> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task PatchAsync(int id, JsonPatchDocument<TDto> patchDoc)
    {
        // دریافت موجودیت از دیتابیس
        var entity = await _repository.GetByIdAsync(id);

        // نگاشت موجودیت به Dto
        var dto = _mapper.Map<TDto>(entity);

        
        
        
        // اعمال تغییرات Patch به Dto
        patchDoc.ApplyTo(dto, error => { throw new Exception($"Patch error: {error.ErrorMessage}"); });
        // patchDoc.ApplyTo(dto);

        //
        await PatchDtoValidation(dto, _validator);

        
        // نگاشت Dto به موجودیت اصلی
        _mapper.Map(dto, entity);

        // ذخیره تغییرات در دیتابیس


        
    }
    public async Task PatchDtoValidation<TDto>(TDto dto, IValidator<TDto> validator)
    {
        var validationResult = await validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Validation Error", validationResult.Errors);
        }
    }
}