using FluentValidation;
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.UpdateProjectValidation;

public class AddUpdateProjectValidation : AbstractValidator<AddUpdateProjectDto>
{
    public AddUpdateProjectValidation()
    {
        RuleFor(up => up.Title).CommonStringRules(3, 50,"تیتر پروژه");
        RuleFor(up => up.Description).CommonTHMLRules("بنده بروزرسانی پروژه");
        RuleFor(up => up.Progress).Cascade(cascadeMode: CascadeMode.Stop).NotNull()
            .WithMessage(".وارد کردن درصذ پیشرفت الزامی است").NotEmpty().WithMessage(".درصد پیشرفت نمیتواند خالی باشد")
            .InclusiveBetween(1, 100).WithMessage(".درصد پیشرفت باید عددی بین 1 تا 100 باشد");
        
    }
}