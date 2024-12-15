using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.GeneralValidation;

public class GetObjectByIdValidator: AbstractValidator<GetObjectByIdDto>
{
    public GetObjectByIdValidator()
    {
        RuleFor(a => a.Id).NotEmpty().WithMessage(".شناسه نمیتواند خالی باشد").NotNull().WithMessage(".شناسه الزامی است").ExclusiveBetween(0, 200000000).WithMessage("شناسه باید بین 1 و 200000000");
        
    }
}