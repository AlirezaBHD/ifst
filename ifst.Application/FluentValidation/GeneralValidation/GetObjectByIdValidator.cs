using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.GeneralValidation;

public class GetObjectByIdValidator: AbstractValidator<GetObjectByIdDto>
{
    public GetObjectByIdValidator()
    {
        RuleFor(c => c.Id).CommonIntRules(1,2000000,"شناسه");
        
    }
}