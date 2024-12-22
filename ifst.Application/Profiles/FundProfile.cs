using AutoMapper;
using ifst.API.ifst.Application.DTOs.FundDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class FundProfile : Profile
{
    public FundProfile()
    {
        CreateMap<Fund, FundDto>();
        CreateMap<Fund, ListFundDto>();
        CreateMap<CreateFundDto, Fund>();
    }
}