using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.AlbumValidator;

public class CreateAlbumValidator : AbstractValidator<CreateAlbumDto>
{
    public CreateAlbumValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty().WithMessage(".عنوان الزامی است")
            .Length(3, 100).WithMessage(".عنوان باید بین 3 تا 100 کارکتر باشد");

        RuleFor(a => a.Category).CommonStringRules(3, 50, "دسته بندی");

    }
}