using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace JsonPatchSample.ifst.Application.FluentValidation.InstituteValidator;


public class PatchInstituteStatusValidation: AbstractValidator<PatchInstitutesStatusDto>
{
    public PatchInstituteStatusValidation()
    {
                                  
        RuleFor(i => i.Confirmed).Cascade(cascadeMode:CascadeMode.Stop).NotEmpty().WithMessage(".نمیتواند خالی باشد").NotNull().WithMessage(".الزامی است").CommonBoolRule("وضعیت بنیاد");

    }
}