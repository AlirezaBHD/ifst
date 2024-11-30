using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.AlbumValidator;

public class UpdateAlbumValidator : AbstractValidator<EditAlbumDto>
{
    public UpdateAlbumValidator()
    {
        RuleFor(a => a.Id).CommonIntRules(1, 2000000, "شناسه آلبوم");

        RuleFor(a => a.Title).CommonStringRules(3, 50, "تیتر");
    }
}