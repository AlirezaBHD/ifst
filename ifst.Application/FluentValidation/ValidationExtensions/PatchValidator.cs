using System.ComponentModel.DataAnnotations;
using System.Reflection;
using AutoMapper.Internal;
using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using System.Diagnostics.CodeAnalysis;
using FluentValidation.Results;
using ValidationException = FluentValidation.ValidationException;

namespace ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

public class PatchValidator<TDto> : AbstractValidator<JsonPatchDocument<TDto>> where TDto : class

{
    public PatchValidator()
    {
        var nullablePaths = typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(prop => !Attribute.IsDefined(prop, typeof(RequiredAttribute)))
            .Select(p => $"/{p.Name}")
            .ToList();

        var allowedPaths = typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(p => $"/{p.Name}")
            .ToList();

        RuleForEach(x => x.Operations).Cascade(CascadeMode.Stop)
            .ChildRules(ops =>
            {
                ops.RuleFor(op => op)
                    .NotEmpty().WithMessage("مسیر الزامی است.")
                    .Must(op => allowedPaths.Contains(op.path))
                    .WithMessage(path =>
                        $"مسیر '{path.path}' نامعتبر است. مسیرهای مجاز: {string.Join(", ", allowedPaths)}");

                ops.RuleFor(op => op.value)
                    .NotEmpty().When(op => op.op == "replace")
                    .WithMessage("مقدار جدید برای عملیات 'replace' الزامی است.");


                ops.RuleFor(op => op.op)
                    .NotEmpty().WithMessage("نوع عملیات الزامی است.")
                    .Must(op => op == "add" || op == "remove" || op == "replace")
                    .WithMessage("عملیات باید یکی از موارد 'add', 'remove' یا 'replace' باشد.");

                ops.RuleFor(op => op.path)
                    .Must(path => nullablePaths.Contains(path))
                    .When(op => op.op == "remove")
                    .WithMessage(op => $"مسیر '{op.path}' برای عملیات 'remove' معتبر نیست.");
            });
    }

    
}