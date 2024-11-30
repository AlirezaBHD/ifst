using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.NewsletterValidator;

public class AddNewsletterValidator : AbstractValidator<AddNewsletterDto>
{
    public AddNewsletterValidator()
    {
        RuleFor(n => n.Title).CommonStringRules(3, 50, "تیتر");
        RuleFor(n => n.ImageFile).CommonRules<AddNewsletterDto, IFormFile>(fieldName: "تصویر");
        RuleFor(n => n.File).CommonRules<AddNewsletterDto, IFormFile>(fieldName: "فایل");
    }
}