using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation;

public class ContactUsValidator: AbstractValidator<ContactUsDto>
{
    public ContactUsValidator()
    {
        RuleFor(c => c.FullName).CommonStringRules(3,50,"نام");
        RuleFor(c => c.Body).CommonStringRules(3,500,"متن");
        RuleFor(c => c.Email).CommonStringRules(3,50,"ایمیل");
        RuleFor(c => c.Subject).CommonStringRules(3,50,"موضوع");
    }
}