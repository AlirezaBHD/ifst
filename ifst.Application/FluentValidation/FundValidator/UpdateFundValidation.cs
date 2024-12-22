using FluentValidation;
using ifst.API.ifst.Application.DTOs.FundDto;

namespace ifst.API.ifst.Application.FluentValidation.FundValidator;

public class UpdateFundValidation : AbstractValidator<UpdateFundDto>
{
    public UpdateFundValidation()
    {
        RuleFor(up => up.AddedAmount).GreaterThanOrEqualTo(0).WithMessage(".نمیتواند منفی باشد");

    }
}