using ifst.API.ifst.Application.DTOs.FundDto;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IFundService
{
    Task<FundDto> FundDetailById(int id);
    
    Task<IEnumerable<ListFundDto>> ListFunds();
    
    Task<FundDto> CreateFunds(CreateFundDto fundDto);
    
    Task UpdateFund(int id, UpdateFundDto fundDto);

    Task DeleteFund(int id);
}