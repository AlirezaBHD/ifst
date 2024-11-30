using FluentValidation;

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