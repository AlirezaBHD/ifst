using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.NewsletterValidator;

public class PatchNewsletterValidator : AbstractValidator<PatchNewsletterDto>
{
    public PatchNewsletterValidator()
    {
        RuleFor(n => n.Title)!.CommonStringRules(3, 50, "تیتر");
        RuleFor(n => n.ImageFile).Cascade(CascadeMode.Stop)!.CommonImageRules(blank: true);
        RuleFor(n => n.File)!.Cascade(CascadeMode.Stop)!.CommonFileRules(blank: true, allowedExtensions: [".pdf"]);

    }
}