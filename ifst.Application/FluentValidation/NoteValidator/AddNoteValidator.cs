using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation;

public class AddNoteValidator : AbstractValidator<AddNoteDto>
{
    public AddNoteValidator()
    {
        RuleFor(n => n.Title).CommonStringRules(3, 50, "عنوان");
        RuleFor(n => n.Image).Cascade(CascadeMode.Stop).CommonImageRules();
        RuleFor(n => n.Summery).Length(3, 100).WithMessage(".متن خلاصه یا باید بین 3 تا 100 کارکتر باشد یا خالی باشد");
        RuleFor(n => n.Body).CommonTHMLRules("بدنه");
    }
}