using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;
using ifst.API.ifst.Domain.ValueObjects;

namespace JsonPatchSample.ifst.Application.FluentValidation.InstituteValidator;

public class AddInstituteDtoValidator: AbstractValidator<CreateInstituteDto>
{
    public AddInstituteDtoValidator()
    {
        RuleFor(i => i.Name).CommonStringRules( 3,75,"نام موسسه");
        RuleFor(i => i.RequesterFullName).CommonStringRules( 3,75,"نام درخواست کننده");
        RuleFor(i => i.RequesterEmail).EmailRules();
        RuleFor(i => i.RequesterNationalId).NationalCodeRules();
        RuleFor(i => i.Image).CommonImageRules();
        RuleFor(i => i.Description).CommonTHMLRules( "توضیحات موسسه");

    }
}