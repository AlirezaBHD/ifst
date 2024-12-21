using FluentValidation;
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.UpdateProjectValidation;

public class PatchUpdateProjectValidator : AbstractValidator<PatchUpdateProjectDto>
{
    public PatchUpdateProjectValidator()
    {
        RuleFor(dto => dto.Accepted).Cascade(cascadeMode:CascadeMode.Stop).NotEmpty().WithMessage(".نمیتواند خالی باشد").NotNull().WithMessage(".الزامی است").CommonBoolRule("وضعیت بروزرسانی پروژه");
    }
}