using FluentValidation;
using ifst.API.ifst.Application.DTOs.FundDto;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.FundValidator;

public class CreateFundValidation : AbstractValidator<CreateFundDto>
{
    public CreateFundValidation()
    {
        RuleFor(up => up.Name).CommonStringRules(3, 50,"نام صندق");
        RuleFor(up => up.GatheredAmount).GreaterThanOrEqualTo(0).WithMessage(".نمیتواند منفی باشد");

    }
}