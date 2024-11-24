using FluentValidation;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.FluentValidation.AlbumValidator;

public class AlbumValidator : AbstractValidator<Album>
{
    public AlbumValidator()
    {
        RuleFor(a => a)
            .NotEmpty().WithMessage(".عنوان الزامی است");

    }
}