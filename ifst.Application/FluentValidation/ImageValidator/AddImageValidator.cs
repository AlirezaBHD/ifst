using FluentValidation;
using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.FluentValidation.ImageValidator;

public class AddImageValidator: AbstractValidator<AddImageDto>
{
    public AddImageValidator()
    {
        RuleFor(i => i.File)
            .NotNull().WithMessage(".تصویر الزامی است").NotEmpty().WithMessage(".تصویر الزامی است");
        
        RuleFor(i => i.Description).NotNull().WithMessage(".توضیحات الزامی است").NotEmpty().WithMessage(".توضیحات الزامی است").Length(3,100).WithMessage(".توضیحات باید بین 3 تا 100 کارکتر باشد");

    }
}