using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.PioneerValidator;


public class UpdatePioneerValidator : AbstractValidator<UpdatePioneerDto>
{
    public UpdatePioneerValidator()
    {
        RuleFor(p => p.Name).CommonStringRules(3, 50, "نام");
        RuleFor(p => p.CityOfBirth).CommonStringRules(3, 50, "محل تولد");
        RuleFor(p => p.ProjectsDescription).CommonStringRules(3, 50, "توضیحات پروژه");

    }
}