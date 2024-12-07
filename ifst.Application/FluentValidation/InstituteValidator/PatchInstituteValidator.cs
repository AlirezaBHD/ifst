using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace JsonPatchSample.ifst.Application.FluentValidation.InstituteValidator;

public class PatchInstituteValidator: AbstractValidator<PatchInstitutesDto>
{
    public PatchInstituteValidator()
    {
        // RuleForEach(x => x).SetValidator(new PatchValidator(allowedPaths));
        RuleFor(i => i.Name).CommonStringRules( 3,75,"نام موسسه");
        RuleFor(i => i.RequesterFullName).CommonStringRules( 3,75,"نام درخواست کننده");
        RuleFor(i => i.RequesterEmail).Cascade(CascadeMode.Stop).EmailRules(blank:true);
        RuleFor(i => i.RequesterNationalId).NationalCodeRules();
        RuleFor(i => i.RequesterNationalId).NationalCodeRules();
        RuleFor(i => i.Description).CommonTHMLRules( "توضیحات موسسه");
    }
}