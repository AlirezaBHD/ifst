using FluentValidation;
using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.FluentValidation.PioneerValidator;


public class GetPioneerValidator : AbstractValidator<GetPioneersDto>
{
    public GetPioneerValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage(".شناسه الزامی است").NotEmpty().WithMessage(".شناسه الزامی است").GreaterThanOrEqualTo(1).WithMessage(".شناسه باید بزرگتر از 0 باشد");

    }
}