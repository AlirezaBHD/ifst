using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.AlbumValidator;

public class UpdateAlbumValidator : AbstractValidator<EditAlbumDto>
{
    public UpdateAlbumValidator()
    {
        RuleFor(a => a.Id).NotEmpty().WithMessage(".شناسه نمیتواند خالی باشد").NotNull().WithMessage(".شناسه الزامی است").ExclusiveBetween(1, 200000000).WithMessage("شناسه باید بین 1 و 200000000");
        RuleFor(a => a.Title).CommonStringRules(3, 50, "تیتر");
        RuleFor(a => a.Category).CommonStringRules(3, 50, "دسته بندی");
    }
}