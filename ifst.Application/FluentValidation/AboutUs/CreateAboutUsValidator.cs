using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.AparatVideoDto;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace ifst.API.ifst.Application.FluentValidation.AboutUs;

public class CreateAboutUsValidator : AbstractValidator<CreateAboutUsDto>
{
    public CreateAboutUsValidator()
    {
        RuleFor(au => au.Introduction).CommonTHMLRules("معرفی");
        RuleFor(au => au.Statutes).CommonTHMLRules("اساسنامه");
        RuleFor(au => au.ActivityLicense).CommonTHMLRules("پروانه فعالیت");
        RuleFor(au => au.FoundingBoard).CommonTHMLRules("هیات موسس");
        RuleFor(au => au.BoardOfTrustees).CommonTHMLRules("هسات امنا");
        RuleFor(au => au.BoardOfDirectors).CommonTHMLRules("هیات مدیره");
        RuleFor(au => au.CEO).CommonTHMLRules("مدیر عامل");
        RuleFor(au => au.CommitteesAndWorkingGroups).CommonTHMLRules("کمیته ها و گارگروه ها");
        RuleFor(au => au.Archive).CommonTHMLRules("آرشیو");
        RuleFor(au => au.Reports).CommonTHMLRules("گزارشات");
        
    }
}