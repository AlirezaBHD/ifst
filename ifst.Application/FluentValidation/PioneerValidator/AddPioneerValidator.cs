using FluentValidation;
using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.FluentValidation.PioneerValidator;

public class AddPioneerValidator : AbstractValidator<AddPioneersDto>
{
    public AddPioneerValidator()
    {
        RuleFor(p => p.File)
            .NotNull().WithMessage(".تصویر الزامی است").NotEmpty().WithMessage(".تصویر الزامی است");

        RuleFor(p => p.Name).NotNull().WithMessage(".نام الزامی است").NotEmpty().WithMessage(".نام الزامی است").Length(3,50).WithMessage(".نام باید بین 3 تا 50 کارکتر باشد");
        RuleFor(p => p.CityOfBirth).NotNull().WithMessage(".نام محل تولد الزامی است").NotEmpty().WithMessage(".نام محل تولد الزامی است").Length(3,50).WithMessage(".نام محل تولد باید بین 3 تا 50 کارکتر باشد");
        RuleFor(p => p.ProjectsDescription).NotNull().WithMessage(".توضیحات پروژه الزامی است").NotEmpty().WithMessage(".توضیحات پروژه الزامی است").Length(3,500).WithMessage(".توضیحات پروژه باید بین 3 تا 500 کارکتر باشد");
    }
}