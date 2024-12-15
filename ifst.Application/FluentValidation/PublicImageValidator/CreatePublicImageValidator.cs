using FluentValidation;
using ifst.API.ifst.Application.DTOs.GeneralDto.Image;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace JsonPatchSample.ifst.Application.FluentValidation;

public class CreatePublicImageValidator : AbstractValidator<CreatePublicImageDto>
{
    public CreatePublicImageValidator()
    {
        RuleFor(i => i.ImageFile).CommonImageRules();
        RuleFor(i => i.Description).Length(3,50).WithMessage(".توضیحات باید بین 3 تا 50 کارکتر باشد");
    }
}