using FluentValidation;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

public static class CommonValidator
{
    public static IRuleBuilderOptions<T, TProperty> CommonRules<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        Func<TProperty, bool> customValidation = null,
        string errorMessage = null,
        string fieldName = null)
    {
        var builder = ruleBuilder
            .NotNull().WithMessage($"{fieldName ?? "فیلد"} الزامی است.")
            .NotEmpty().WithMessage($"{fieldName ?? "فیلد"} نباید خالی باشد.");

        if (customValidation != null)
        {
            builder = builder.Must(customValidation).WithMessage(errorMessage ?? $"{fieldName ?? "فیلد"} معتبر نیست.");
        }

        return builder;
    }

    public static IRuleBuilderOptions<T, string> EmailRules<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        var builder = ruleBuilder
            .NotNull().WithMessage(".نشانی پست الکرونیک الزامی است")
            .NotEmpty().WithMessage(".نشانی پست الکرونیک نباید خالی باشد")
            .Must(Email.IsValidEmail).WithMessage(".نشانی پست الکرونیک معتبر نیست");

        return builder;
    }

    public static IRuleBuilderOptions<T, string> NationalCodeRules<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        var builder = ruleBuilder
            .NotNull().WithMessage(".کد ملی الزامی است")
            .NotEmpty().WithMessage(".کد ملی نباید خالی باشد")
            .Must(NationalCode.IsValidNationalCode).WithMessage(".کد ملی معتبر نیست");

        return builder;
    }


    public static IRuleBuilderOptions<T, string> CommonStringRules<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        int minLength,
        int maxLength,
        string fieldName)
    {
        return ruleBuilder
            .CommonRules(null, null, fieldName)
            .Length(minLength, maxLength)
            .WithMessage($"{fieldName} باید بین {minLength} تا {maxLength} کاراکتر باشد.");
    }

    public static IRuleBuilderOptions<T, string> CommonTHMLRules<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string fieldName)
    {
        return ruleBuilder
            .NotNull().WithMessage($".{fieldName} الزامی است")
            .NotEmpty().WithMessage($".{fieldName} نباید خالی باشد");
    }

    

    public static IRuleBuilderOptions<T, IFormFile> CommonImageRules<T>(
        this IRuleBuilder<T, IFormFile> ruleBuilder,
        int maxSize = 5,
        string[]? allowedExtensions = null,
        string errorMessage = " فایل تصویر معتبر نیست.")
    {

        var maxSizeMb = maxSize * 1048576;
        allowedExtensions ??= new[] { ".webp", ".png", ".jpg", ".jpeg" };
        return ruleBuilder.Must(file =>
        {
            if (file == null || file.Length == 0)
                return false;
            var extension = Path.GetExtension(file.FileName)?.ToLower();
            return extension != null && allowedExtensions.Contains(extension);
        }).WithMessage(errorMessage)
            .Must(file => file.Length <= maxSizeMb).WithMessage($".حجم عکس نمیتواند بیشتر از {maxSizeMb} مگابایت باشد");
    }
    
    public static IRuleBuilderOptions<T, IFormFile> CommonFileRules<T>(
        this IRuleBuilder<T, IFormFile> ruleBuilder,
        int maxSize = 5,
        string[]? allowedExtensions = null,
        string errorMessage = " فایل معتبر نیست.")
    {
        var maxSizeMb = maxSize * 1048576;

        return ruleBuilder.Must(file =>
        {
            if (file == null || file.Length == 0)
                return false;
        
            var extension = Path.GetExtension(file.FileName)?.ToLower();
            return extension != null && allowedExtensions.Contains(extension);
        }).WithMessage(errorMessage).WithMessage(errorMessage)
        .Must(file => file.Length <= maxSizeMb).WithMessage($".حجم فایل نمیتواند بیشتر از {maxSizeMb} مگابایت باشد");;
    }

    public static IRuleBuilderOptions<T, int> CommonIntRules<T>(
        this IRuleBuilder<T, int> ruleBuilder,
        int minValue,
        int maxValue,
        string fieldName)
    {
        return ruleBuilder
            .GreaterThanOrEqualTo(minValue).WithMessage($"{fieldName} باید بزرگتر یا مساوی {minValue} باشد.")
            .LessThanOrEqualTo(maxValue).WithMessage($"{fieldName} باید کوچکتر یا مساوی {maxValue} باشد.");
    }
}