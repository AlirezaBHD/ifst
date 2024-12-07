using FluentValidation;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

public static class CommonValidator
{
    #region Common Rule

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

    #endregion


    #region Email Rule

    public static IRuleBuilderOptions<T, string> EmailRules<T>(
        this IRuleBuilder<T, string> ruleBuilder, bool blank = false)
    {
        if (!blank)
        {
            ruleBuilder
                .NotNull().WithMessage(".نشانی پست الکرونیک الزامی است")
                .NotEmpty().WithMessage(".نشانی پست الکرونیک نمیتواند خالی باشد");
        }

        var builder = ruleBuilder
            .Must(Email.IsValidEmail).WithMessage(".نشانی پست الکرونیک معتبر نیست");

        return builder;
    }

    #endregion


    #region NationalCode Rule

    public static IRuleBuilderOptions<T, string> NationalCodeRules<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        var builder = ruleBuilder
            .NotNull().WithMessage(".کد ملی الزامی است")
            .NotEmpty().WithMessage(".کد ملی نباید خالی باشد")
            .Must(NationalCode.IsValidNationalCode).WithMessage(".کد ملی معتبر نیست");

        return builder;
    }

    #endregion


    #region Common String Rule

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

    #endregion


    #region Common HTML Rule

    public static IRuleBuilderOptions<T, string> CommonTHMLRules<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string fieldName)
    {
        return ruleBuilder
            .NotNull().WithMessage($".{fieldName} الزامی است")
            .NotEmpty().WithMessage($".{fieldName} نباید خالی باشد");
    }

    #endregion


    #region Common Image Rule

    //Cascade(Stop)
    public static IRuleBuilderOptions<T, IFormFile> CommonImageRules<T>(
        this IRuleBuilder<T, IFormFile> ruleBuilder,
        int maxSize = 5,
        string[]? allowedExtensions = null,
        string errorMessage = " فایل تصویر معتبر نیست.",
        bool blank = false)
    {
        allowedExtensions ??= new[] { ".webp", ".png", ".jpg", ".jpeg" };
        var maxSizeMb = maxSize * 1048576;

        if (!blank)
        {
            ruleBuilder
                .NotNull().WithMessage(".تصویر الزامی است")
                .NotEmpty().WithMessage(".تصویر نمیتواند خالی باشد");
        }
        
        return ruleBuilder
            .Must(file => file != null && !string.IsNullOrEmpty(file.FileName))
            .WithMessage(".نام فایل تصویر الزامی است.")
            .Must(file =>
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName)?.ToLower();
                    return extension != null && allowedExtensions.Contains(extension);
                }

                return true;
            }).WithMessage($" تصویر معتبر نیست. پسوند های معتبر: {string.Join(", ", allowedExtensions)}")
            .Must(file =>
            {
                if (file != null)
                {
                    return file.Length <= maxSizeMb;
                }

                return true;
            }).WithMessage($".حجم تصویر نمیتواند بیشتر از {maxSizeMb} مگابایت باشد");
    }

    #endregion


    #region Common File Rule

    public static IRuleBuilderOptions<T, IFormFile> CommonFileRules<T>(
        this IRuleBuilder<T, IFormFile> ruleBuilder,
        int maxSize = 5,
        string[]? allowedExtensions = null,
        string errorMessage = " فایل معتبر نیست.",
        bool blank = false)
    {
        var maxSizeMb = maxSize * 1048576;

        if (!blank)
        {
            ruleBuilder
                .NotNull().WithMessage(".فایل الزامی است")
                .NotEmpty().WithMessage(".فایل نمیتواند خالی باشد");
        }

        return ruleBuilder
            .Must(file => blank || (file != null && !string.IsNullOrEmpty(file.FileName)))
            .WithMessage(".نام فایل تصویر الزامی است.")
            .Must(file =>
            {
                if (file == null) return blank;
                var extension = Path.GetExtension(file.FileName)?.ToLower();
                return extension != null && allowedExtensions.Contains(extension);
            }).WithMessage($" تصویر معتبر نیست. پسوند های معتبر: {string.Join(", ", allowedExtensions)}")
            .Must(file =>
            {
                if (file == null) return blank;
                return file.Length <= maxSizeMb;
            }).WithMessage($".حجم تصویر نمیتواند بیشتر از {maxSizeMb} مگابایت باشد");
    }

    #endregion


    #region Common Int Rule

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

    #endregion
}