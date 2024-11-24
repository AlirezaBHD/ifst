using FluentValidation;
using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.FluentValidation.PioneerValidator;


public class GetAllPioneersValidator : AbstractValidator<GetAllPioneersDto>
{
    public GetAllPioneersValidator()
    {
        RuleFor(p => p.Page)
            .NotNull().WithMessage(".شماره صفحه الزامی است").NotEmpty().WithMessage(".شماره صفحه الزامی است").GreaterThanOrEqualTo(1).WithMessage(".شماره صفحه باید بزرگتر از 0 باشد");
        
        RuleFor(p => p.PageSize)
            .NotNull().WithMessage(".اندازه صفحه الزامی است").NotEmpty().WithMessage(".اندازه صفحه الزامی است").GreaterThanOrEqualTo(1).WithMessage(".اندازه صفحه باید بزرگتر از 0 باشد");

    }
}