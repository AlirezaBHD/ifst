using AutoMapper;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Application.Profiles;

public class NationalCodeProfile : Profile
{
    public NationalCodeProfile() {
        
        // CreateMap<string, NationalCode>().ConvertUsing(src => new NationalCode(src));
        // CreateMap<NationalCode, string>().ConvertUsing(nationalCode => nationalCode.Value);
    }
}