using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;

namespace JsonPatchSample.ifst.Application.FluentValidation.ProjectValidator;

public class InstituteUpdateProjectValidator : AbstractValidator<InstituteUpdateProjectDto>
{
    public InstituteUpdateProjectValidator()
    {
        RuleFor(p => p.Name)!.CommonStringRules(3, 75, "نام پروژه");
        RuleFor(p => p.StartDate)!.CommonRules("تاریخ شروع");
        RuleFor(p => p.GatheringStartDate)!.CommonRules("تاریخ شروع جمع آوری");
        RuleFor(p => p.ImageFile)!.CommonImageRules(blank:true);
        RuleFor(p => p.CapitalRequired)!.CommonIntRules(1,1000000000, "سرمایه مورد نیاز");
        RuleFor(p => p.City)!.CommonStringRules(1,50, "شهر");
        RuleFor(p => p.Place)!.CommonStringRules(1,50, "مکان پروژه");
        RuleFor(p => p.GatheredSupport)!.CommonIntRules(1,1000000000, "سرمایه جمع شده");
        RuleFor(p => p.Summery)!.CommonStringRules(1,1000, "خلاصه پروژه");
        RuleFor(p => p.Description)!.CommonRules("خلاصه پروژه");
    }



}