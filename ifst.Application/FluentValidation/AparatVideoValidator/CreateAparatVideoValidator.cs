using FluentValidation;
using ifst.API.ifst.Application.DTOs.AparatVideoDto;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace JsonPatchSample.ifst.Application.FluentValidation;

public class CreateAparatVideoValidator : AbstractValidator<CreateAparatVideoDto>
{
    public CreateAparatVideoValidator()
    {
        RuleFor(av => av.Title).CommonStringRules(3, 50, "عنوان");
        RuleFor(av => av.VideoScript).CommonTHMLRules("اسکیریپت ویدیو آپارات");
    }
}