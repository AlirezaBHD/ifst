using FluentValidation;
using ifst.API.ifst.Application.DTOs.GeneralDto.Image;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace JsonPatchSample.ifst.Application.FluentValidation;

public class UpdatePublicImageValidator: AbstractValidator<UpdatePublicImageDto>
{
    public UpdatePublicImageValidator()
    {
        RuleFor(i => i.ImageFile)!.CommonImageRules(blank: true);
        RuleFor(i => i.Description).Length(3,50).WithMessage(".توضیحات باید بین 3 تا 50 کارکتر باشد");;
        
    }
}