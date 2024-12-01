using FluentValidation;
using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.FluentValidation.AlbumValidator;

public class GetAlbumValidator : AbstractValidator<GetAlbumDto>
{
    public GetAlbumValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage(".شناسه الزامی است")
            .GreaterThan(0).WithMessage(".شناسه نمیتواند کمتر از 1 باشد");
        // .WithMessage(".شناسه نمیتواند کمتر از 1 باشد").Must(BeAValidNumber);
        
    }
    
}

